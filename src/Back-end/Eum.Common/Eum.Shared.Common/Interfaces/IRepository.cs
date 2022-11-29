
namespace Eum.Shared.Common.Interfaces
{
	public interface IRepository<T> : IDisposable
	{
        public Task<int> Create(T input); //return created id
        public Task Delete(int id);
        public Task Update(T input);
        public Task<T> Read(int id);
        public Task<List<T>> GetAll();
    }
}

