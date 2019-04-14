using HotBag.Autofill.Attribute;
using HotBag.AutoMaper.Attributes;
using HotBag.Core.EntityDto;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.Core.Entity
{
    [AutoMap(typeof(DappperTestEntityDto))]
    public class DapperTestEntity : IDapperEntityBase<long>
    {  
        public long Id { get; set; }
        public string TestName { get; set; }
        public string TestProp1 { get; set; }
        public int TestProp2 { get; set; }

        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime TestProp3 { get; set; }
    }
}
