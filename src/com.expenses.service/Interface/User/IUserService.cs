using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.UserDTO;

namespace com.expenses.service.Interface.User
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateUserAsync(UserRequestDTO request, CancellationToken cancellationToken);


        Task<UserResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
