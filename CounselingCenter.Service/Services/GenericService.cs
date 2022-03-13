using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CounselingCenter.Core.Repositories;
using CounselingCenter.Core.Services;
using CounselingCenter.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace CounselingCenter.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TDto : class where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity is null)
                return Response<TDto>.Fail("Entity with id not found", 404, true);

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(entity), 200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());

            return Response<IEnumerable<TDto>>.Success(entities, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var list = _genericRepository.Where(expression);
            return Response<IEnumerable<TDto>>.Success(
                ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return Response<TDto>.Success(newDto, 200);
        }

        public async Task<Response<NoDataDto>> RemoveAsync(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity is null)
                return Response<NoDataDto>.Fail("Entity with id not found", 404, true);

            _genericRepository.Remove(isExistEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<NoDataDto>> UpdateAsync(TDto entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity is null)
                return Response<NoDataDto>.Fail("Entity with id not found", 404, true);

            var updatedEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            _genericRepository.Update(updatedEntity);
            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }
    }
}