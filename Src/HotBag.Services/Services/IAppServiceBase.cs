using HotBag.EntityBase;
using HotBag.ResultWrapper.ResponseModel;
using System.Threading.Tasks;

namespace HotBag.Services
{
    public interface IAppServiceBase<TEntityDto, TPrimaryKey> 
        where TEntityDto : IEntityBaseDto<TPrimaryKey>
    {
        Task<ListResultDto<TEntityDto>> GetAll(string searchText);
        Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<TEntityDto>> Get(TPrimaryKey id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<TEntityDto>> Save(TEntityDto entity);
        Task<ResultDto<TEntityDto>> Update(TEntityDto entity);
        Task Delete(TPrimaryKey id);
    }


}
