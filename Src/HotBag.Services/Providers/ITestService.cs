using HotBag.Core.EntityDto;
using HotBag.ResultWrapper.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Services.Providers
{
    public interface ITestService
    {
        Task<ListResultDto<TestEntityDto>> GetAll(string searchText);
        Task<PagedResultDto<TestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<TestEntityDto>> Get(Guid id);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<TestEntityDto>> Save(TestEntityDto entity);
        Task<ResultDto<TestEntityDto>> Update(TestEntityDto entity);
        Task Delete(Guid id);
    }
}
