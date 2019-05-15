using HotBag.Autofill.Attribute;
using HotBag.AutoMaper.Attributes;
using HotBag.Core.EntityDto;
using HotBag.EntityBase;
using HotBag.Web.Core.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Core.Entity
{
    //[AutoMap(typeof(TestEntityDto))]
    public class TestEntity : EntityBase<Guid>
    {    
        public string TestName { get; set; }
        public string TestProp1 { get; set; }
        public int TestProp2 { get; set; }

        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime TestProp3 { get; set; }
    }

    //[GeneratedController("api/book")]
    [GeneratedController(typeof(BookDto), typeof(Guid))]
    public class Book : EntityBase<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }
    }

    public class BookDto : EntityBaseDto<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }
    }

    //[GeneratedController("api/v1/album")]
    [GeneratedController(typeof(AlbumDto), typeof(Guid))]
    public class Album : EntityBase<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }

    public class AlbumDto : EntityBaseDto<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }

    [GeneratedController(typeof(PradeepDto), typeof(Guid))]
    public class Pradeep : EntityBase<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }
    
    public class PradeepDto : EntityBaseDto<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }


    [GeneratedController(typeof(UnitDto), typeof(Guid))]
    public class Unit : EntityBase<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }

    public class UnitDto : EntityBaseDto<Guid>
    {
        public string Title { get; set; }

        public string Artist { get; set; }
    }
}
