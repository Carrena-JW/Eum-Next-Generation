using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Organization.Shared.Interfaces.Repositories;

public interface ICompanyRepository<T> : IRepository<T> where T : IEntity
{
    Task<int> CreateCompany(T payload);
    Task UpdateCompany(T paylod);
    Task DeleteCompany(string identity);
}