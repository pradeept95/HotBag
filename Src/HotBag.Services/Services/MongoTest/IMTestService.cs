using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Services.MongoProviders
{
    public interface IMTestService
    {
        Task<ListResultDto<MTestEntityDto>> GetAll(string searchText);
        Task<PagedResultDto<MTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<MTestEntityDto>> Get(Guid id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<MTestEntityDto>> Save(MTestEntityDto entity);
        Task<ResultDto<MTestEntityDto>> Update(MTestEntityDto entity);
        Task Delete(Guid id);
    }
}
