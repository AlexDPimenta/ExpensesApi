using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.ExpenseDTO;

namespace com.expenses.service.Interface.Expense
{
    public interface IExpenseService
    {
        Task<ExpenseResponseDTO> CreateAsync(ExpenseRequestDTO expenseRequestDTO, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(ExpenseToUpdateDTO expenseDTO, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
