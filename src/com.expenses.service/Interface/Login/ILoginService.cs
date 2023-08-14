using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO;
using com.expenses.datacomunication.DTO.AuthLoginDTO;

namespace com.expenses.service.Interface.Login
{
    public interface ILoginService
    {
        Task<AuthLoginResponseDTO> CreateAsync(AuthLoginRequestDTO request, CancellationToken cancellationToken);

        Task<AuthLoginResponseDTO> GenerateAsync(AuthLoginSSoRequestDTO request, CancellationToken cancellationToken);
    }
}
