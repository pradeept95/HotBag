using HotBag.BaseController;
using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Base;
using HotBag.Web.Core.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static HotBag.Web.GenericTypeControllerFeatureProvider;

namespace HotBag.Web.GenericBase
{
    [GenericControllerName]
    [Route("api/app/v1/[controller]")]
    [ApiController]
    public class GenericBaseController<TEntity, TEntityDto, TPrimaryKey> 
        where TEntity : IEntityBase<TPrimaryKey>
        where TEntityDto : IEntityBaseDto<TPrimaryKey> 
    {
        private readonly IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> _service;
        public GenericBaseController(IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultDto<TEntityDto>> Get(TPrimaryKey id)
        {
            return await _service.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ListResultDto<TEntityDto>> GetAll(string searchText)
        {
            return await _service.GetAll(searchText);
        }

        [HttpGet]
        [Route("GetAllPaged")] 
        public async Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            return await _service.GetAllPaged(skip, maxResultCount, searchText);
        }

        [HttpGet]
        [Route("Count")]
        public async Task<ResultDto<int>> GetCount()
        {
            return await _service.GetCount();
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ResultDto<TEntityDto>> Save(TEntityDto entity)
        {
            return await _service.Save(entity);
        }


        [HttpPut]
        [Route("Update")] 
        public async Task<ResultDto<TEntityDto>> Update(TEntityDto entity)
        {
            return await _service.Update(entity);
        }

        [HttpDelete]
        [Route("Delete")] 
        public async Task Delete(TPrimaryKey id)
        {
            await _service.Delete(id);
        }
    }
}
