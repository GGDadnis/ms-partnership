using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Interfaces;
using ms_partnership.Models.Entities;
using ms_partnership.Models.Entities.Dtos.Login;
using ms_partnership.Service;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace ms_partnership.Domain
{
    public class LoginDomain : ILogin
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly HashPassword _hashpassword;

        public LoginDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _hashpassword = new HashPassword();
        }

        public ReadLoginDto Add(AddLoginDto dto)
        {
            byte[] salting = RandomNumberGenerator.GetBytes(128 / 8);
            string saltToString = Convert.ToBase64String(salting);
            string spicePassword = dto.Password + saltToString;
            var hPassword = _hashpassword.HashingPassword(spicePassword);
            
            Login login = new Login()
            {
                Email = dto.Email,
                Password = hPassword,
                Role = dto.Role,
                Professional = dto.Professional,
                Salt = saltToString,
                CompanyId = dto.CompanyId,
                UserId = dto.UserId
            };

            _context.Logins.Add(login);
            _context.SaveChanges();

            ReadLoginDto loginDto = _mapper.Map<ReadLoginDto>(login);
            return loginDto;
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
            Login login = _context.Logins.FirstOrDefault(login => login.Id == id);
            if (login != null)
            {
                _context.Remove(login);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ReadLoginDto> SearchAll()
        {
            var lista = _context.Logins.ToList();
            IEnumerable<ReadLoginDto> readLoginDtos = _mapper.Map<List<ReadLoginDto>>(lista);
            return readLoginDtos;
        }

        public ReadLoginDto SearchById(Guid id)
        {
            Login login = _context.Logins.FirstOrDefault(login => login.Id == id);
            ReadLoginDto loginDto = _mapper.Map<ReadLoginDto>(login);
            return loginDto;
        }

        public ReadLoginDto Update(Guid id, UpdateLoginDto dto)
        {
            Login login = _context.Logins.FirstOrDefault(login => login.Id == id);
            if(login != null)
            {
                _mapper.Map(dto, login);
                ReadLoginDto loginDto = _mapper.Map<ReadLoginDto>(login);
                _context.SaveChanges();
                return loginDto;
            }
            return null;
        }
    }
}