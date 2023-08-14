using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel;

namespace com.expenses.infra.Interface
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task RemoveAsync(T entity, CancellationToken cancellationToken);
    }
}
