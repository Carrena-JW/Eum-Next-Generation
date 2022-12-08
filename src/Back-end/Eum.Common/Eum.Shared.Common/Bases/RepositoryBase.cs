using System.Dynamic;

namespace Eum.Shared.Common.Bases;

public class RepositoryBase : DatabaseRepositoryBase
{
    //WRITE REPOSITORY
    public RepositoryBase(string conStr) : base(conStr)
    {
    }

    protected string CreateQuerySet(QueryCommandType qt, string tableName, object payload = null, int? id = null)
    {
        var sb = new StringBuilder();
        var hasValuePropertyNames = payload.GetType().GetProperties().AsEnumerable()
            .Where(p => p.GetValue(payload) != null).Select(p => p.Name);

        var firstPropName = hasValuePropertyNames.FirstOrDefault();
        var lastPropName = hasValuePropertyNames.Last();

        switch (qt)
        {
            case QueryCommandType.Create:
                sb.AppendLine($"INSERT INTO [{tableName}](");
                //column
                foreach (var p in hasValuePropertyNames)
                    sb.AppendLine($"[{p}]{(lastPropName != p ? "," : string.Empty)}");

                sb.AppendLine(")");
                sb.AppendLine("OUTPUT INSERTED.Id"); //output ID
                sb.AppendLine("VALUES(");
                //input value
                foreach (var p in hasValuePropertyNames)
                    sb.AppendLine($"@{p}{(lastPropName != p ? "," : string.Empty)}");

                sb.AppendLine(")");
                break;
            case QueryCommandType.Update:
                //sb.AppendLine
                sb.AppendLine($"UPDATE [{tableName}]");

                //업데이트에서는 id 는 제외 한다
                hasValuePropertyNames = hasValuePropertyNames.Where(r => r.ToLowerInvariant() != "id");

                if (firstPropName.ToLowerInvariant() == "id") firstPropName = hasValuePropertyNames.FirstOrDefault();

                foreach (var p in hasValuePropertyNames)
                    sb.AppendLine(
                        $"{(firstPropName != p ? string.Empty : "SET")} [{p}] = @{p}{(lastPropName != p ? "," : string.Empty)}");
                break;
            case QueryCommandType.Delete:
                sb.AppendLine($"DELETE FROM [{tableName}]");
                break;
        }

        if (id.HasValue && qt != QueryCommandType.Create) sb.AppendLine("WHERE [id] = @id");

        return sb.ToString();
    }

    protected object ExceptNullValueProperty(object payload)
    {
        var properties = payload.GetType().GetProperties().AsEnumerable();
        var hasValueProperties = properties.Where(p => p.GetValue(payload) != null).Select(p => p.Name);

        dynamic result = new ExpandoObject();
        IDictionary<string, object> catedResult = result;

        foreach (var pName in hasValueProperties)
        {
            var prop = properties.Where(pp => pp.Name == pName).FirstOrDefault();
            catedResult.Add(pName, prop.GetValue(payload)); // Adding dynamically named property
        }

        return result;
    }
}