using HotBag.BaseController;
using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<TestEntityDto>> Get(Guid id)
        {
            return await _testService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<TestEntityDto>> GetAll(string searchText)
        {
            return await _testService.GetAll(searchText); 
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<TestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            return await _testService.GetAllPaged(skip, maxResultCount, searchText);
        }

        [HttpGet]
        [Route("Count")]
        public async Task<ResultDto<int>> GetCount()
        {
            return await _testService.GetCount();
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ResultDto<TestEntityDto>> Save(TestEntityDto entity)
        {
            return await _testService.Save(entity);
        }


        [HttpPost]
        [Route("Update")]

        public async Task<ResultDto<TestEntityDto>> Update(TestEntityDto entity)
        {
            return await _testService.Update(entity);
        }
    }
}
