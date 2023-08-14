using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Categorie;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Categorie;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class CategorieRepository : SqlLiteRepositoryBase<CategorieModel>, ICategorieRepository
    {
        private readonly ExpensesContext _context;
        public CategorieRepository(ExpensesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategorieModel>> GetCategoriesByName(string name, CancellationToken cancellationToken)
            => await _context.Categories.Where(c => c.Name.Equals(name)).ToListAsync();        
    }
}
