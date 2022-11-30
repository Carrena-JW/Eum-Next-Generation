namespace Eum.Shared.Common.Bases;

public abstract class EntityBase
{
    private int _Id;
    public int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }

    public string CreatedId { get; set; }
    public string UpdatedId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

}

