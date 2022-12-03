using FluentResults;

namespace ms_partnership.Interfaces
{
    public interface IBaseGuid<in T, out A>
    {
        Result IdValidate(Guid id);
        A Add(T obj);
        A SearchById(Guid id);
        IEnumerable<A> SearchAll();
        bool Remove(Guid id);
    }
}