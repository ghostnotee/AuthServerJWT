using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SharedLibrary.Dtos;

namespace CounselingCenter.Core.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression);
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> RemoveAsync(int id);
        Task<Response<NoDataDto>> UpdateAsync(TDto entity,int id);
    }
}