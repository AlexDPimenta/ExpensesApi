using System;

namespace com.expenses.domain.DomainModel.Base
{
    public class BillBaseModel: BaseModel
    {
        public Double Amount { get; set; }       
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
