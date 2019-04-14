using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.ResultWrapper.ResponseModel;
using System.Threading.Tasks;

namespace HotBag.Services
{
    public abstract class AppServiceBase<TEntityDto, TEntity, TPrimaryKey> : IAppServiceBase<TEntityDto, TPrimaryKey>, ITransientDependencies
        where TEntity : IEntityBase<TPrimaryKey>
        where TEntityDto : IEntityBaseDto<TPrimaryKey>
    {
        public abstract Task Delete(TPrimaryKey id);

        public abstract Task<ResultDto<TEntityDto>> Get(TPrimaryKey id);

        public abstract Task<ListResultDto<TEntityDto>> GetAll(string searchText);

        public abstract Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);

        public abstract Task<ResultDto<int>> GetCount();

        public abstract Task<ResultDto<TEntityDto>> Save(TEntityDto entity);

        public abstract Task<ResultDto<TEntityDto>> Update(TEntityDto entity);
    }


}
