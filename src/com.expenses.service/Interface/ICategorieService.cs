using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.CategorieDTO;

namespace com.expenses.service.Interface
{
    public interface ICategorieService
    {
        Task<CategorieResponseDTO> CreateAsync(CategorieRequestDTO requestDTO, CancellationToken cancellationToken);
        Task<CategorieToGetDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<CategoriesToGetByNameDTO> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Guid id, CategorieToUpdateDTO requestDTO, CancellationToken cancellationToken);
    }
}
