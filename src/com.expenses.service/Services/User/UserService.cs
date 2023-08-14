using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.UserDTO;
using com.expenses.domain.DomainModel.User;
using com.expenses.domain.Validators.User;
using com.expenses.infra.Interface.User;
using com.expenses.service.Interface.User;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private UserValidator _validator;

        public UserService(IUserRepository repository, IMapper mapper, NotificationContext notificationContext)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _validator = new UserValidator();
        }

        public async Task<UserResponseDTO> CreateUserAsync(UserRequestDTO request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserModel>(request);
            var valid = _validator.Validate(user);
            if (!valid.IsValid)
            {
                _notificationContext.AddNotifications(valid);
                return null;
            }
                
            var userCreated = await _repository.AddAsync(user, cancellationToken);

            return new UserResponseDTO { Id = userCreated.Id };
        }

        public async Task<UserResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(id, cancellationToken);

            if(user == null)
            {
                _notificationContext.AddNotification("Id", "User not found!");
                return null;
            }

            return _mapper.Map<UserResponseDTO>(user);
        }
    }
}
