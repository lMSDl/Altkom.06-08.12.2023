using Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;

namespace Services.Bogus
{
    public class AsyncService<T> : IAsyncService<T> where T : class
    {
        private readonly IEnumerable<T> _entities;

        public AsyncService(BaseFaker<T> faker)
        {
            _entities = faker.Generate(15);
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            await Task.Delay(2500);
            return _entities.ToList();
        }
    }
}
