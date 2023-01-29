using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.User;
using ms_partnership.Service;

namespace ms_partnership.Domain
{
    public class UserDomain : IUser
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AmazonS3Service _amazonS3Service;


        public UserDomain(AppDbContext context, IMapper mapper, AmazonS3Service amazonS3Service)
        {
            _context = context;
            _mapper = mapper;
            _amazonS3Service = amazonS3Service;
        }
        public ReadUserDto Add(AddUserDto dto)
        {
            if (!String.IsNullOrEmpty(dto.AvatarImg))
                dto.AvatarImg = SendBase64ImageToS3(dto.AvatarImg);
            var user = _mapper.Map<User>(dto);
            if (!dto.AvatarImg.Contains("ERROR")){
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
            return userDto;
        }

        public Result IdValidate(Guid id)
        {
            if (id == null)
            {
                return Result.Fail("");
            }
            return Result.Ok();
        }

        public bool Remove(Guid id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                if (!String.IsNullOrEmpty(user.AvatarImg)){
                    var response = _amazonS3Service.DeleteAsync(user.AvatarImg);
                    while (!response.IsCompleted){}
                    if (!response.IsCompletedSuccessfully)
                        user.AvatarImg = "DELETE_ERROR";
                }
                if (!user.AvatarImg.Contains("ERROR")){
                    _context.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public IEnumerable<ReadUserDto> SearchAll()
        {
            var lista = _context.Users.Where(user => user.Active == true).ToList();
            IEnumerable<ReadUserDto> readUserDtos = _mapper.Map<List<ReadUserDto>>(lista);
            return readUserDtos;
        }

        public ReadUserDto SearchById(Guid id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
            return userDto;
        }

        public ReadUserDto Update(Guid id, UpdateUserDto dto)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user != null)
            {
                if (!String.IsNullOrEmpty(dto.AvatarImg)){
                    dto.AvatarImg = SendBase64ImageToS3(dto.AvatarImg);
                    if (!String.IsNullOrEmpty(user.AvatarImg))
                        _amazonS3Service.DeleteAsync(user.AvatarImg);
                }
                _mapper.Map(dto, user);
                ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
                if (!dto.AvatarImg.Contains("ERROR"))
                    _context.SaveChanges();
                return userDto;
            }
            return null;
        }

        public ReadUserDto LogicalRemove(Guid id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user != null)
            {
                if (!String.IsNullOrEmpty(user.AvatarImg)){
                    var response = _amazonS3Service.DeleteAsync(user.AvatarImg);
                    while (!response.IsCompleted){}
                    if (!response.IsCompletedSuccessfully)
                        user.AvatarImg = "DELETE_ERROR";
                    else
                        user.AvatarImg = "DELETED";
                }
                user.Active = false;
                ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
                if (!user.AvatarImg.Contains("ERROR"))
                    _context.SaveChanges();
                return userDto;
            }
            return null;
        }

        private string SendBase64ImageToS3(string base64Image){
            // Converter imagem base64
            Stream filestream;
            try{
                filestream = ConvertBase64Image(base64Image);
            }catch{
                return "CONVERTION_ERROR";
            }
            // Obter o formato da imagem original
            int length = base64Image.LastIndexOf(';') - base64Image.LastIndexOf("image/") - 6;
            var formatoImagem = base64Image.Substring(base64Image.LastIndexOf("image/") + 6, length);
            // Gerar um nome do arquivo a partir de um Guid
            var key = Guid.NewGuid().ToString() + '.' + formatoImagem;
            // Enviar imagem para a S3 e aguardar a resposta
            var response = _amazonS3Service.SendAsync(filestream, key);
            while (!response.IsCompleted){}
            if (response.IsCompletedSuccessfully)
                return response.Result;
            return "SEND_ERROR";
        }

         private Stream ConvertBase64Image(string base64Image){
            var contentBase64 = base64Image.Substring(base64Image.LastIndexOf(',') + 1);
            byte[] bytes = Convert.FromBase64String(contentBase64);
            Stream filestream = new MemoryStream(bytes);
            return filestream;
        }
    }
}