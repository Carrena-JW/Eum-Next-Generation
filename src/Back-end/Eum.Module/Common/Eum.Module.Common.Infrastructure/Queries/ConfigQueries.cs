using Dapper;
using Eum.Module.Common.Shared.Interfaces;
using Eum.Shared.Common.Bases;
using Eum.Shared.Common.CommonViewModels;
using Microsoft.Data.SqlClient;

namespace Eum.Module.Common.Infrastructure.Queries;

public class ConfigQueries : QueryBase, IConfigQueries
{
    //life time scope 
    public ConfigQueries() : base("EumBoard")
    {
    }

}