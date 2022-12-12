using Eum.Module.Organization.Shared.Interfaces.Repositories;
using Eum.Module.Organization.Shared.Models.Entities;
using Eum.Shared.Common.Bases;
using Eum.Shared.Common.Enums;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Eum.Module.Organization.Infrastructure.Repositories;

public class CompanyRepository<T> : RepositoryBase, ICompanyRepository<T> where T : CompanyEntity
{
    private const string targetTable = "T_EO_COMPANY";
    
    public CompanyRepository() : base("EumOrganization")
    {
    }

    public async Task<int> CreateCompany(T payload)
    {
        using var c = new SqlConnection(connectionStrings);
        await c.OpenAsync();
        
        var q = CreateQuerySet(QueryCommandType.Create, targetTable, payload);
        return (await c.QueryAsync<int>(q, ExceptNullValueProperty(payload))).FirstOrDefault();

    }

    public async Task UpdateCompany(T paylod)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCompany(string identity)
    {
        throw new NotImplementedException();
    }
}