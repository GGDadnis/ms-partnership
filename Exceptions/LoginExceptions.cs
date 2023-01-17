using AutoMapper;
using FluentResults;
using ms_partnership.Data;
using ms_partnership.Exceptions.InterfacesExceptions;

namespace ms_partnership.Exceptions
{
    public class LoginExceptions : ILoginExceptions
    {
        private readonly AppDbContext? _context;
        private readonly IMapper? _mapper;

        public LoginExceptions(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Result BlockCopycat(string user_email)
        {
            var email = _context.Logins.FirstOrDefault(login => login.Email == user_email);

            if(email != null)
            {
                return Result.Fail("Email already in use.");
            }
            
            return Result.Ok();
        }

        public Result BlockCopycatAtUpdate(Guid user_id, string user_email)
        {
            var email = _context.Logins.FirstOrDefault(login => login.Email == user_email);

            var idEqualsEmail = _context.Logins.FirstOrDefault(login => login.Id == user_id
            && login.Email == user_email);

            if (idEqualsEmail != null)
            {
                return Result.Ok();
            }

            if (idEqualsEmail == null)
            {
                if(email != null)
                {
                    return Result.Fail("Email already in use.");
                }

                return Result.Ok();
            }

            return Result.Ok();
        }
    }
}