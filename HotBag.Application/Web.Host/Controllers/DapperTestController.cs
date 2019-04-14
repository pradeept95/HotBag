using HotBag.BaseController;
using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.DapperProviders;
using HotBag.Services.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class DapperTestController : BaseApiController
    {
        private readonly IDapperTestService _testService;
        public DapperTestController(IDapperTestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<DappperTestEntityDto>> Get(long id)
        {
            return await _testService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<DappperTestEntityDto>> GetAll(string searchText)
        {
            return await _testService.GetAll(searchText); 
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<DappperTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
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
        public async Task<ResultDto<DappperTestEntityDto>> Save(DappperTestEntityDto entity)
        {
            return await _testService.Save(entity);
        }


        [HttpPut]
        [Route("Update")]

        public async Task<ResultDto<DappperTestEntityDto>> Update(DappperTestEntityDto entity)
        {
            return await _testService.Update(entity);
        }


        [HttpDelete]
        [Route("Delete")]

        public async Task Delete(long id)
        {
            await _testService.Delete(id);
        }
    }
}
