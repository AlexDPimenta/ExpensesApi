using System;
using System.Text.Json.Serialization;

namespace com.expenses.datacomunication.DTO.CategorieDTO
{
    public class CategorieToUpdateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
