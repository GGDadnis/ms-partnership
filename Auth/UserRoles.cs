using Microsoft.EntityFrameworkCore;

namespace ms_partnership.Auth
{
    [Keyless]
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Company = "Company";
    }
}