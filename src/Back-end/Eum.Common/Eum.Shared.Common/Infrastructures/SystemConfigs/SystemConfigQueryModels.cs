namespace Eum.Shared.Common.Infrastructures.SystemConfigs;

public record SysmConfigQueryVieModel
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string Category { get; set; }   
}