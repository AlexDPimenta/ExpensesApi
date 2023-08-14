using System.Collections.Generic;

namespace com.expenses.datacomunication.DTO.CategorieDTO
{
    public class CategoriesToGetByNameDTO
    {
        public int Count { get; set; }
        public IEnumerable<CategorieToGetDTO> Categories { get; set; }
    }
}
