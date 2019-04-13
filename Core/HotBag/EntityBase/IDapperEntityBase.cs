using System.ComponentModel.DataAnnotations;

namespace HotBag.EntityBase
{
    public interface IDapperEntityBase<TPrimaryKey>
    {
        //
        // Summary:
        //     Unique identifier for this entity. 
        [Key]
        TPrimaryKey Id { get; set; }
    }

}
