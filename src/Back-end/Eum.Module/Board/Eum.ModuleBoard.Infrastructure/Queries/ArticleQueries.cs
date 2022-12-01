
using System.Collections.Generic;
using AutoMapper;
using Dapper;
using Eum.Module.Board.Shared.DTO;
using Eum.Shared.Common.Interfaces;
using Microsoft.Data.SqlClient;

namespace Eum.Module.Board.Infrastructure.Queries;

public class ArticleQueries : QueryBase, IArticleQueries
{
    //repositort 면 싱글톤이 유리하지 않나

    private readonly IMapper _mapper;
    private readonly SqlConnection _connection;

    public ArticleQueries(IMapper mapper) : base("EumBoard")
    {
        _mapper = mapper;
        _connection.ConnectionString
        if(_connection.State)
    }


    public virtual async Task<IEnumerable<T>> GetArticles<T>() where T : ArticleQueryModel
    {

        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();

        var query =
@"
Select * from vw_article
";

        var result = await connection.QueryAsync<dynamic>(query);
        return result.Cast<T>().AsEnumerable();
    }

    public virtual async Task<IEnumerable<T>> GetArticleById<T>(int id) where T: ArticleQueryModel
    {
        using var connection = new SqlConnection(base.connectionStrings);
        connection.Open();


        var query =
@"
Select * from [vw_article]
where [id] = @id
";

        var result = await connection.QueryAsync<dynamic>(query,new { id });


        return _mapper.Map<IEnumerable<T>>(result);
    }
}
