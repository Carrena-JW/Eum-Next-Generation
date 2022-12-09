namespace Eum.Module.Calendar.Infrastructure.Repositories;

public class EumTemplateRepository<T> : RepositoryBase, IEumTemplateRepository<T> where T : EumTemplateEntity
{
    private const string targetTable = "{TABLE_NAME}";

    public EumTemplateRepository() : base("EumEumTemplate")
    {
    }
}