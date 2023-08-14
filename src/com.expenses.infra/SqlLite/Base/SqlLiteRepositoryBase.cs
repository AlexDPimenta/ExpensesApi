using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface;

namespace com.expenses.infra.SqlLite.Base
{
    public class SqlLiteRepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : BaseModel
    {
        private readonly ExpensesContext _context;
        public IUnitOfWork _unitOfWork => _context; 

        public SqlLiteRepositoryBase(ExpensesContext context)
        {
            _context = context;            
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity);
            await _unitOfWork.saveAsync();

            return entity;
        }
                                                       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken) =>
           await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);        

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _unitOfWork.saveAsync();
        }
              

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            var entry = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (entry == null)
                return null;

            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _unitOfWork.saveAsync();

            return entity;
        }
            
    }
}
