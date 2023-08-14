using System.Collections.Generic;

namespace com.expenses.datacomunication.DTO.ResportsDTO
{
    public class AmountsByMonthDTO
    {
        public IEnumerable<AmountByMonth> Revenue { get; set; }
        public double MaxRevenueAmount { get; set; }
    }

    public class AmountByMonth
    {
        public string MonthName { get; set; }
        public double MonthRevenue { get; set; }
    }
}
