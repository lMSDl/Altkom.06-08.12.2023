using Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;

namespace Services.Bogus
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IEnumerable<T> _entities;

        public Service(BaseFaker<T> faker)
        {
            _entities = faker.Generate(15);
        }

        public IEnumerable<T> Read()
        {
            return _entities.ToList();
        }
    }
}
