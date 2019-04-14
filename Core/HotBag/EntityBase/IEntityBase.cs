namespace HotBag.EntityBase
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }

    public interface IEntityBaseDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
