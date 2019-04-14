using HotBag.AppUserDto;
using HotBag.BaseController;
using HotBag.Services.Identity;
using HotBag.ResultWrapper.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly IRoleService _appUserService;
        public RoleController(IRoleService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<HotBagRoleDto>> Get(long id)
        {
            return await _appUserService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<HotBagRoleDto>> GetAll(string searchText)
        {
            return await _appUserService.GetAll(searchText); 
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<HotBagRoleDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
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
        public async Task<ResultDto<HotBagRoleDto>> Save(HotBagRoleDto entity)
        {
            return await _appUserService.Save(entity);
        }


        [HttpPut]
        [Route("Update")] 
        public async Task<ResultDto<HotBagRoleDto>> Update(HotBagRoleDto entity)
        {
            return await _appUserService.Update(entity);
        }


        [HttpDelete]
        [Route("Delete")] 
        public async Task Delete(long id)
        {
            await _appUserService.Delete(id);
        }
    }
}
