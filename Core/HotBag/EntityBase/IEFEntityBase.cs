using System.ComponentModel.DataAnnotations;

namespace HotBag.EntityBase
{
    public interface IEFEntityBase<TPrimaryKey>
    {
        //
        // Summary:
        //     Unique identifier for this entity. 
        [Key]
        TPrimaryKey Id { get; set; } 
    }
      
}
