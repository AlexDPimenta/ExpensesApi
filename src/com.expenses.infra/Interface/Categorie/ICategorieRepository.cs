using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Categorie;

namespace com.expenses.infra.Interface.Categorie
{
    public interface ICategorieRepository: IRepositoryBase<CategorieModel>
    {
        Task<IEnumerable<CategorieModel>> GetCategoriesByName(string name, CancellationToken cancellationToken); 
    }
}
