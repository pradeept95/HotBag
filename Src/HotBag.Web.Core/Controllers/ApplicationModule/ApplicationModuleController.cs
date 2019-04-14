using HotBag.AppUserDto;
using HotBag.Authorization;
using HotBag.Authorization.Attribute;
using HotBag.BaseController;
using HotBag.Core.EntityDto.Authenticate;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Host.Controllers
{
    public class ApplicationModuleController : BaseApiController
    {
        private readonly IApplicationModuleService _appUserService;
        public ApplicationModuleController(IApplicationModuleService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<ApplicationModuleDto>> Get(long id)
        {
            return await _appUserService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<HotBagApplicationModuleDto>> GetAll(string searchText)
        {
            return await _appUserService.GetAll(searchText); 
        }

        [HttpGet]
        [Route("GetAllPaged")]

        public async Task<PagedResultDto<HotBagApplicationModuleDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
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
        [Route("SaveOrUpdate")]
        //[HotBagAuthorize(HotBagClaimTypes.Permission, "AppUser.Create, AppUser.Read", RequiredAllPermission : false)]
        public async Task<ResultDto<ApplicationModuleDto>> SaveOrUpdate(ApplicationModuleDto entity)
        {
            return await _appUserService.SaveOrUpdate(entity);
        }
         
        [HttpDelete]
        [Route("Delete")]

        public async Task Delete(long id)
        {
            await _appUserService.Delete(id);
        }
    }
}
