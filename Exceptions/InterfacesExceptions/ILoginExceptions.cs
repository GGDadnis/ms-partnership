using FluentResults;

namespace ms_partnership.Exceptions.InterfacesExceptions
{
    public interface ILoginExceptions
    {
        Result NeedToHaveUserOrCompany(Guid? user, Guid? company);
        Result BlockCopycat(string user_email);
        Result BlockCopycatAtUpdate(Guid user_id, string user_email);
    }
}