using Eum.Module.Organization.Shared.Interfaces.Repositories;
using Eum.Module.Organization.Shared.Models.Entities;
using Eum.Shared.Common.Bases;
using Eum.Shared.Common.Enums;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Eum.Module.Organization.Infrastructure.Repositories;

public class CompanyExtentionRepository<T> : RepositoryBase, ICompanyExtentionRepository<T> where T : CompanyExtentionEntity
{
    private const string targetTable = "T_EO_COMPANY_EXTENTIONS";
    
    public CompanyExtentionRepository() : base("EumOrganization")
    {
    }

    public async Task<int> CreateCompanyExtention(T payload)
    {
        using var c = new SqlConnection(connectionStrings);
        c.OpenAsync();
        
        var q = CreateQuerySet(QueryCommandType.Create, targetTable, payload);
        return (await c.QueryAsync<int>(q, ExceptNullValueProperty(payload))).FirstOrDefault();

    }

    public async Task UpdateCompanyExtention(T paylod)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCompanyExtention(string identity)
    {
        throw new NotImplementedException();
    }
}