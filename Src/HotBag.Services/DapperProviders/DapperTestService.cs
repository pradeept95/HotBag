using System;
using System.Linq;
using System.Threading.Tasks;
using HotBag.Autofill;
using HotBag.AutoMaper;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;
using HotBag.Dapper.Repository;
using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.EntityFrameworkCore.UnitOfWork;
using HotBag.ResultWrapper.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace HotBag.Services.DapperProviders
{
    public class DapperTestService : IDapperTestService, ITransientDependencies
    {
        private readonly IDapperRepository<DapperTestEntity, long> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public DapperTestService(IDapperRepository<DapperTestEntity, long> repository, IUnitOfWork unitOfWork, IObjectMapper objectMapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task Delete(long id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ResultDto<DappperTestEntityDto>> Get(long id)
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
            var res = _objectMapper.Map<DappperTestEntityDto>(result);
            return new ResultDto<DappperTestEntityDto>(res);
        }

        public async Task<ListResultDto<DappperTestEntityDto>> GetAll(string searchText)
        {
            var result = await _repository.GetListAsync();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = result
                .Select(x => new DappperTestEntityDto
                {
                    Id = x.Id,
                    TestName = x.TestName,
                    TestProp1 = x.TestProp1,
                    TestProp2 = x.TestProp2,
                    TestProp3 = x.TestProp3
                })
                .ToList();

            return new ListResultDto<DappperTestEntityDto>(finalResult, "Test summary");

        }

        public async Task<PagedResultDto<DappperTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            var result = await _repository.GetListAsync();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            var totalCount = result.Count();
            var finalResult = result
                .Select(x => new DappperTestEntityDto
                {
                    Id = x.Id,
                    TestName = x.TestName,
                    TestProp1 = x.TestProp1,
                    TestProp2 = x.TestProp2,
                    TestProp3 = x.TestProp3
                })
                .Skip(skip) 
                .Take(maxResultCount)
                .ToList();

            return new PagedResultDto<DappperTestEntityDto>(totalCount , finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new  ResultDto<int>(await _repository.RecordCountAsync());
        }

        public async Task<ResultDto<DappperTestEntityDto>> Save(DappperTestEntityDto entity)
        {
            //var saveModel = new TestEntity 
            //{ 
            //    Id = Guid.NewGuid(),
            //    TestName = entity.TestName,
            //    TestProp1 = entity.TestProp1,
            //    TestProp2 = entity.TestProp2,
            //    TestProp3 = entity.TestProp3
            //};

            var saveModel = _objectMapper.Map<DapperTestEntity>(entity);
             
            var result = await _repository.InsertAsync(saveModel);
            //await _unitOfWork.SaveChangesAsync();
            entity.Id = result;
            //var res = _objectMapper.Map<DappperTestEntityDto>(result);
            return new ResultDto<DappperTestEntityDto>(entity);
        }

        public async Task<ResultDto<DappperTestEntityDto>> Update(DappperTestEntityDto entity)
        {
            //    var updateModel = new TestEntity
            //    {
            //        Id = entity.Id,
            //        TestName = entity.TestName,
            //        TestProp1 = entity.TestProp1,
            //        TestProp2 = entity.TestProp2,
            //        TestProp3 = entity.TestProp3
            //    };

            var updateModel = _objectMapper.Map<DapperTestEntity>(entity);
 
            var result = await _repository.UpdateAsync(updateModel); 
            //await _unitOfWork.SaveChangesAsync();
            //var res = _objectMapper.Map<DappperTestEntityDto>(result);
            return new ResultDto<DappperTestEntityDto>(entity);
        }
    }
}
