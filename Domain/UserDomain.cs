using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.User;

namespace ms_partnership.Domain
{
    public class UserDomain : IUser
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadUserDto Add(AddUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            _context.Users.Add(user);
            _context.SaveChanges();
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
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ReadUserDto> SearchAll()
        {
            var lista = _context.Users.ToList();
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
                _mapper.Map(dto, user);
                ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);
                _context.SaveChanges();
                return userDto;
            }
            return null;
        }
    }
}