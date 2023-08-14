using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO;
using com.expenses.datacomunication.DTO.AuthLoginDTO;
using com.expenses.domain.DomainModel.Login;
using com.expenses.domain.Validators.Login;
using com.expenses.infra.Interface.Login;
using com.expenses.service.Interface.Login;
using com.expenses.service.Token;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private LoginValidator _loginValidator;
        public LoginService(ILoginRepository repository, IMapper mapper, 
            NotificationContext notificationContext)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _loginValidator = new LoginValidator();
        }

        public async Task<AuthLoginResponseDTO> CreateAsync(AuthLoginRequestDTO request, 
            CancellationToken cancellationToken)
        {
            var login = await _repository.GetByLogin(request.Login,cancellationToken);
            var loginMap = _mapper.Map<LoginModel>(request);
            var loginValidate = _loginValidator.Validate(loginMap);
            if (!loginValidate.IsValid)
            {
                _notificationContext.AddNotifications(loginValidate);
                return null;
            }

            if (login != null)
            {
                _notificationContext.AddNotification("Login", "Login is unique, please inform another login!");
                return null;
            }

            await _repository.AddAsync(_mapper.Map<LoginModel>(request),
                cancellationToken);

             return new AuthLoginResponseDTO {  Token = TokenService.GenerateToken(loginMap) };            
        }

        public async Task<AuthLoginResponseDTO> GenerateAsync(AuthLoginSSoRequestDTO request, CancellationToken cancellationToken)
        {
            var login = await _repository.GetByLogin(request.Login, cancellationToken);

            if(!TokenService.ValidateJwtToken(request.AppToken)) 
            {
                _notificationContext.AddNotification("AppToken", "Token is not valid");
                return null;
            }

            if (login != null)
                return new AuthLoginResponseDTO { Token = TokenService.GenerateToken(login) };
            
            _notificationContext.AddNotification("Login", "login not found");

            return null;
        }
    }
}
