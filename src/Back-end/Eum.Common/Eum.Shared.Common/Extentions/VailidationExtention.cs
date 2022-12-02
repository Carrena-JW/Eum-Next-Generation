
namespace Eum.Shared.Common.Extentions;

public static class ValidationExtensions
{
   
    public static void Required<T>(this object sender, Expression<Func<T>> expr,
        [CallerMemberName] string memberName = "")
    {
        var memberExpr = expr.Body as MemberExpression;
        if (memberExpr == null) throw new ArgumentNullException("expr");
        var value = expr.Compile()();
        var prop = memberExpr.Member.Name;
        ThrowIfValueIsEmptyOrNull(memberName, value, prop);
    }

    private static void ThrowIfValueIsEmptyOrNull<T>(string memberName, T value, string prop)
    {
        if ((value is string && string.IsNullOrWhiteSpace(Convert.ToString(value))) ||
           
            (value is null))
        {
            throw new ArgumentNullException($"{memberName}()[{typeof(T).Name} {prop}] can not be null.");
        }
    }
}