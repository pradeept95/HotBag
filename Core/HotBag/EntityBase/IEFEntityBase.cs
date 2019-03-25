namespace HotBag.EntityBase
{
    public interface IEFEntityBase<TPrimaryKey>
    {
        //
        // Summary:
        //     Unique identifier for this entity. 
        TPrimaryKey Id { get; set; }
    }
      
}
