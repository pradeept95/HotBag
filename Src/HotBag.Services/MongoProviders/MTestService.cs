using HotBag.AutoMaper;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;
using HotBag.DI.Base;
using HotBag.MongoDb.Repository;
using HotBag.ResultWrapper.ResponseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotBag.Services.MongoProviders
{
    public class MTestService : IMTestService, ITransientDependencies
    {
        private readonly IMongoRepository<MTestEntity, Guid> _repository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectMapper _objectMapper;
        public MTestService(IMongoRepository<MTestEntity, Guid> repository, IObjectMapper objectMapper)
        {
            _repository = repository;
            //_unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            //await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ResultDto<MTestEntityDto>> Get(Guid id)
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
            var res = _objectMapper.Map<MTestEntityDto>(result);
            return new ResultDto<MTestEntityDto>(res);
        }

        public async Task<ListResultDto<MTestEntityDto>> GetAll(string searchText)
        {
            var result = _repository.GetAll();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            //var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new MTestEntityDto
                {
                    Id = x.Id,
                    TestName = x.TestName,
                    TestProp1 = x.TestProp1,
                    TestProp2 = x.TestProp2,
                    TestProp3 = x.TestProp3
                })
                .ToListAsync();

            return new ListResultDto<MTestEntityDto>(finalResult, "Test summary");

        }

        public async Task<PagedResultDto<MTestEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
        {
            var result = await _repository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
            }

            

            var totalCount = await result.CountAsync();
            var finalResult = await result
                .Select(x => new MTestEntityDto
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

            return new PagedResultDto<MTestEntityDto>(totalCount, finalResult, skip + maxResultCount < totalCount, "Total Data With summary");
        }

        public async Task<ResultDto<int>> GetCount()
        {
            return new ResultDto<int>(await _repository.CountAsync());
        }

        public async Task<ResultDto<MTestEntityDto>> Save(MTestEntityDto entity)
        {
            //var saveModel = new TestEntity 
            //{ 
            //    Id = Guid.NewGuid(),
            //    TestName = entity.TestName,
            //    TestProp1 = entity.TestProp1,
            //    TestProp2 = entity.TestProp2,
            //    TestProp3 = entity.TestProp3
            //};

            var saveModel = _objectMapper.Map<MTestEntity>(entity);
            var result = await _repository.InsertAsync(saveModel);
            //await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<MTestEntityDto>(result);
            return new ResultDto<MTestEntityDto>(res);
        }

        public async Task<ResultDto<MTestEntityDto>> Update(MTestEntityDto entity)
        {
            //    var updateModel = new TestEntity
            //    {
            //        Id = entity.Id,
            //        TestName = entity.TestName,
            //        TestProp1 = entity.TestProp1,
            //        TestProp2 = entity.TestProp2,
            //        TestProp3 = entity.TestProp3
            //    };

            var updateModel = _objectMapper.Map<MTestEntity>(entity);

            var result = await _repository.UpdateAsync(updateModel);
            //await _unitOfWork.SaveChangesAsync();
            var res = _objectMapper.Map<MTestEntityDto>(result);
            return new ResultDto<MTestEntityDto>(res);
        }
    }
  
}
