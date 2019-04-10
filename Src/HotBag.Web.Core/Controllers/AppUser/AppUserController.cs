using HotBag.AppUserDto;
using HotBag.BaseController;
using HotBag.Core.EntityDto;
using HotBag.EntityFrameworkCore.Services.Identity;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class AppUserController : BaseApiController
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<HotBagUserDto>> Get(Guid id)
        {
            return await _appUserService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<HotBagUserDto>> GetAll(string searchText)
        {
            return await _appUserService.GetAll(searchText); 
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<HotBagUserDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            return await _appUserService.GetAllPaged(skip, maxResultCount, searchText);
        }

        [HttpGet]
        [Route("Count")]
        public async Task<ResultDto<int>> GetCount()
        {
            return await _appUserService.GetCount();
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ResultDto<HotBagUserDto>> Save(HotBagUserDto entity)
        {
            return await _appUserService.Save(entity);
        }


        [HttpPut]
        [Route("Update")]

        public async Task<ResultDto<HotBagUserDto>> Update(HotBagUserDto entity)
        {
            return await _appUserService.Update(entity);
        }


        [HttpDelete]
        [Route("Delete")]

        public async Task Delete(Guid id)
        {
            await _appUserService.Delete(id);
        }
    }
}
