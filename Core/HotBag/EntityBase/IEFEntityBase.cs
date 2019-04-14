using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.EntityBase
{
    public interface IEFEntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        //
        // Summary:
        //     Unique identifier for this entity. 
        [Key]
        TPrimaryKey Id { get; set; } 
    } 
}
