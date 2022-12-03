namespace ms_partnership.Interfaces
{
    public interface IUpdate<in T, out A>
    {
        A Update(Guid id, T obj);
    }
}