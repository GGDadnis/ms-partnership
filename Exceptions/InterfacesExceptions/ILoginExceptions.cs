using FluentResults;

namespace ms_partnership.Exceptions.InterfacesExceptions
{
    public interface ILoginExceptions
    {
        Result BlockCopycat(string user_email);
    }
}