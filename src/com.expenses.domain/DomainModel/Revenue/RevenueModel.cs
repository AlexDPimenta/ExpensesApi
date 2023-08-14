using System;
using com.expenses.domain.DomainModel.Base;

namespace com.expenses.domain.DomainModel.Revenue
{
    public class RevenueModel: BillBaseModel
    {
        public Guid CustomerId { get; set; }
        public string InvoiceId { get; set; }


    }
}
