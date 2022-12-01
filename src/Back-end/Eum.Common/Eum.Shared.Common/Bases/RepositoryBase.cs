namespace Eum.Shared.Common.Bases;

public class RepositoryBase : DatabaseRepositoryBase
{
    //WRITE REPOSITORY
    public RepositoryBase(string conStr) : base(conStr) { }
    protected string CreateQuerySet(QueryCommandType qt, string tableName, object parameter = null, int? id = null)
    {
        var sb = new StringBuilder();
        var properties = parameter.GetType().GetProperties().AsEnumerable().Select(p => p.Name);
        
        var firstPropName = properties.FirstOrDefault();
        var lastPropName = properties.Last();

        switch (qt)
        {
            case QueryCommandType.Create:
                sb.AppendLine($"INSERT INTO [{tableName}](");
                sb.AppendLine("OUTPUT INSERTED.Id"); //output ID
                //column
                foreach(var p in properties)
                {
                    sb.AppendLine($"[{p}]{(lastPropName != p ? "," : string.Empty)}");
                }

                sb.AppendLine(")");
                sb.AppendLine("VALUES(");
                //input value
                foreach (var p in properties)
                {
                    sb.AppendLine($"@{p}{(lastPropName != p ? "," : string.Empty)}");
                }

                sb.AppendLine(")");
                break;
            case QueryCommandType.Update:
                //sb.AppendLine
                sb.AppendLine($"UPDATE [{tableName}]");
                foreach(var p in properties)
                {
                    sb.AppendLine($"{(firstPropName != p ? string.Empty:"SET")} [{p}] = {p}{((lastPropName != p ? "," : string.Empty))}");
                }
                break;
            case QueryCommandType.Delete:
                sb.AppendLine($"DELETE FROM [{tableName}]");
                break;
            default:
                break;
        }

        if (id.HasValue && qt != QueryCommandType.Create)
        {
            sb.AppendLine("WHERE [id] = @id");
        }

        return sb.ToString();
    }
}
