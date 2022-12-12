using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Organization.Shared.Interfaces.Repositories;

public interface ICompanyExtentionRepository<T> : IRepository<T> where T : IEntity
{
    Task<int> CreateCompanyExtention(T payload);
    Task UpdateCompanyExtention(T paylod);
    Task DeleteCompanyExtention(string identity);
}