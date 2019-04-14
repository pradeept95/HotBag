using System;
using System.Linq;
using System.Threading.Tasks;
using HotBag.AutoMaper;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;
using HotBag.Data;
using HotBag.DI.Base; 
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.RepositoryFactory;
using HotBag.Services.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HotBag.Services.Providers
{
    public class TestService : ITestService, ITransientDependencies
    {
        private readonly IBaseRepository<TestEntity, Guid> _repository;
        private readonly IBaseUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public TestService(
            IRepositoryFactory<TestEntity, Guid> repository, 
            IUnitOfWorkFactory unitOfWork, 
            IObjectMapper objectMapper
        )
        {
            _repository = repository.GetRepository();
            _unitOfWork = unitOfWork.GetCurrentUnitOfWork();
            _objectMapper = objectMapper;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ResultDto<TestEntityDto>> Get(Guid id)
        {
            var result = await _repository.GetAsync(id);
            //var res = new TestEntityDto
            //{
            //    Id = result.Id,
            //    TestName = result.TestName,
            //    TestProp1 = result.TestProp1,
            //    TestProp2 = result.TestProp2,
            //    TestProp3 = result.TestProp3
            //};
            var res = _objectMapper.Map<TestEntityDto>(result);
            return new ResultDto<TestEntityDto>(res);
        }

        public async Task<ListResultDto<TestEntityDto>> GetAll(string searchText)
        {
            var result =  _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new TestEntityDto {
                    Id = x.Id,
                    TestName = x.TestName,
                    TestProp1 = x.TestProp1,
                    TestProp2 = x.TestProp2,
                    TestProp3 = x.TestProp3
                })
                .ToListAsync();

            return new ListResultDto<TestEntityDto>(finalResult, "Test summary");

        }

        public async Task<PagedResultDto<TestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new TestEntityDto
                {
                    Id = x.Id,
                    TestName = x.TestName,
                    TestProp1 = x.TestProp1,
                    TestProp2 = x.TestProp2,
                    TestProp3 = x.TestProp3
                })
                .Skip(skip) 
                .Take(maxResultCount)
                .ToListAsync();

            return new PagedResultDto<TestEntityDto>(totalCount , finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new  ResultDto<int>(await _repository.CountAsync());
        }

        public async Task<ResultDto<TestEntityDto>> Save(TestEntityDto entity)
        {
            //var saveModel = new TestEntity 
            //{ 
            //    Id = Guid.NewGuid(),
            //    TestName = entity.TestName,
            //    TestProp1 = entity.TestProp1,
            //    TestProp2 = entity.TestProp2,
            //    TestProp3 = entity.TestProp3
            //};

            var saveModel = _objectMapper.Map<TestEntity>(entity); 
            var result = await _repository.InsertAsync(saveModel);
            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<TestEntityDto>(result);
            return new ResultDto<TestEntityDto>(res);
        }

        public async Task<ResultDto<TestEntityDto>> Update(TestEntityDto entity)
        {
            //    var updateModel = new TestEntity
            //    {
            //        Id = entity.Id,
            //        TestName = entity.TestName,
            //        TestProp1 = entity.TestProp1,
            //        TestProp2 = entity.TestProp2,
            //        TestProp3 = entity.TestProp3
            //    };

            var updateModel = _objectMapper.Map<TestEntity>(entity);
 
            var result = await _repository.UpdateAsync(updateModel);
            await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<TestEntityDto>(result);
            return new ResultDto<TestEntityDto>(res);
        }
    }
}
