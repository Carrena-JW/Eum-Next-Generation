using System;
namespace Eum.Common.Interfaces
{
	public interface IRepository<T> : IDisposable
	{
        public Task<T> Create(T input);
        public Task<T> Delete(int id);
        public Task<T> Update(int id);
        public Task<T> Read(int id);
        public Task<List<T>> GetAll();
    }
}

