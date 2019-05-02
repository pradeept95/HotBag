using HotBag.BaseController;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Base;
using HotBag.Services.Providers;
using HotBag.Web.GenericBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    //public class GenericTestController : GenericBaseController<TestEntity,TestEntityDto, Guid>
    //{
    //    private IAppAsyncCrudService<TestEntityDto, TestEntity, Guid> _service;
    //    public GenericTestController(IAppAsyncCrudService<TestEntityDto, TestEntity, Guid> service) : base(service)
    //    {
    //        _service = service;
    //    }

    //    [HttpGet]
    //    [Route("EM")]
    //    public async Task ExtraMethod()
    //    {

    //    }
    //}
}
