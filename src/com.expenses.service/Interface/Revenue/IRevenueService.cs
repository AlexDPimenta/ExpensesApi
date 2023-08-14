using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.RevenueDTO;

namespace com.expenses.service.Interface.Revenue
{
    public interface IRevenueService
    {
        Task<RevenueResponseDTO> CreateAsync(RevenueRequestDTO revenueRequestDTO, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(RevenueToUpdateDTO revenueDto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid revenueId, CancellationToken cancellationToken);
    }
}
