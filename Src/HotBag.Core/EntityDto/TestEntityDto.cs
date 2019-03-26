using HotBag.AutoMaper.Attributes;
using HotBag.Core.Entity;
using HotBag.EntityBase;
using System;

namespace HotBag.Core.EntityDto
{
    [AutoMapTo(typeof(TestEntity))]
    public class TestEntityDto {
        public Guid Id { get; set; }
        public string TestName { get; set; }
        public string TestProp1 { get; set; }
        public int TestProp2 { get; set; }
        public DateTime TestProp3 { get; set; }
    }
}
