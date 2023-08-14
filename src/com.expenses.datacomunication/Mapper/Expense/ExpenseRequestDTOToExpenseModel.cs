using AutoMapper;
using com.expenses.datacomunication.DTO.ExpenseDTO;
using com.expenses.domain.DomainModel.Expense;

namespace com.expenses.datacomunication.Mapper.Expense
{
    public class ExpenseRequestDTOToExpenseModel: Profile
    {
        public ExpenseRequestDTOToExpenseModel()
        {
            CreateMap<ExpenseRequestDTO, ExpenseModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
    }
}
