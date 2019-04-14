namespace HotBag.EntityBase
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }

}
