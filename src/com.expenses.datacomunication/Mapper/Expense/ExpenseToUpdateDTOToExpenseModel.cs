using AutoMapper;
using com.expenses.datacomunication.DTO.ExpenseDTO;
using com.expenses.domain.DomainModel.Expense;

namespace com.expenses.datacomunication.Mapper.Expense
{
    public class ExpenseToUpdateDTOToExpenseModel: Profile
    {
        public ExpenseToUpdateDTOToExpenseModel()
        {
            CreateMap<ExpenseToUpdateDTO, ExpenseModel>();
        }
    }
}
