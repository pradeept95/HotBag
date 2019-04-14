using HotBag.Autofill.Attribute;
using HotBag.AutoMaper.Attributes;
using HotBag.Core.EntityDto;
using HotBag.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Core.Entity
{
    [AutoMap(typeof(TestEntityDto))]
    public class TestEntity : EntityBase<Guid>
    {    
        public string TestName { get; set; }
        public string TestProp1 { get; set; }
        public int TestProp2 { get; set; }

        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime TestProp3 { get; set; }
    }
}
