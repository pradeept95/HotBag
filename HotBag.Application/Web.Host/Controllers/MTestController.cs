using HotBag.BaseController;
using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.MongoProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class MTestController : BaseApiController
    {
        private readonly IMTestService _testService;
        public MTestController(IMTestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<MTestEntityDto>> Get(Guid id)
        {
            return await _testService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<MTestEntityDto>> GetAll(string searchText)
        {
            return await _testService.GetAll(searchText);
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<MTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
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
        public async Task<ResultDto<MTestEntityDto>> Save(MTestEntityDto entity)
        {
            return await _testService.Save(entity);
        }


        [HttpPut]
        [Route("Update")]

        public async Task<ResultDto<MTestEntityDto>> Update(MTestEntityDto entity)
        {
            return await _testService.Update(entity);
        }


        [HttpDelete]
        [Route("Delete")]

        public async Task Delete(Guid id)
        {
            await _testService.Delete(id);
        }
    }
}
