using System;
using com.expenses.domain.DomainModel.Base;

namespace com.expenses.domain.DomainModel.Expense
{
    public class ExpenseModel: BillBaseModel
    {
        public Guid CategoryId { get; set; }        
    }
}
