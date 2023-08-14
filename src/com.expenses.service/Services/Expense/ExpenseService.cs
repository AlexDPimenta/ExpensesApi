using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.ExpenseDTO;
using com.expenses.domain.DomainModel.Expense;
using com.expenses.infra.Interface.Categorie;
using com.expenses.infra.Interface.Expense;
using com.expenses.service.Interface.Expense;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notification;
        private readonly ICategorieRepository _categorieRepo;

        public ExpenseService(IExpenseRepository repository, IMapper mapper, NotificationContext notification, ICategorieRepository categorieRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _notification = notification;
            _categorieRepo = categorieRepo;
        }

        public async Task<ExpenseResponseDTO> CreateAsync(ExpenseRequestDTO expenseRequestDTO, CancellationToken cancellationToken)
        {
            var categorie = await  _categorieRepo.GetByIdAsync(expenseRequestDTO.CategoryId, cancellationToken);
            if(categorie == null)
            {
                _notification.AddNotification("categorieID", "Categorie not found!");
                return null;
            }
            var response = await _repository.AddAsync(_mapper.Map<ExpenseModel>(expenseRequestDTO), cancellationToken);
            return new ExpenseResponseDTO { ExpenseId = response.Id };
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetByIdAsync(id, cancellationToken);
            if(expense == null)
            {
                _notification.AddNotification("expenseId", "Expense not found");
                return false;
            }
            await _repository.RemoveAsync(expense, cancellationToken);
            return true;
        }       

        public async Task<bool> UpdateAsync(ExpenseToUpdateDTO expenseDTO, CancellationToken cancellationToken)
        {
            var expense = await _repository.GetByIdAsync(expenseDTO.Id, cancellationToken);
            if (expense == null)
            {
                _notification.AddNotification("expenseID", "Expense not found!");
                return false;
            }

            var expenseModel = _mapper.Map<ExpenseModel>(expenseDTO);
            expenseModel.CategoryId = expense.CategoryId;
            await _repository.UpdateAsync(expenseModel, cancellationToken);
            
            
            return true;
        }
    }
}
