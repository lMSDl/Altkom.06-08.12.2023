namespace Services.Interfaces
{
    public interface IAsyncService<T>
    {
        Task<IEnumerable<T>> ReadAsync();
    }
}
