using System;
using System.Text.Json.Serialization;

namespace com.expenses.datacomunication.DTO.ExpenseDTO
{
    public class ExpenseToUpdateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Double Amount { get; set; }
        [JsonIgnore]
        public Guid CategorieId { get; set; }
        public string Description { get; set; }        
        public DateTime AccrualDate { get; set; }        
        public DateTime TransactionDate { get; set; }
    }
}
