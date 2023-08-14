using AutoMapper;
using com.expenses.datacomunication.DTO;
using com.expenses.domain.DomainModel.Login;

namespace com.expenses.datacomunication.Mapper.AuthLogin
{
    public class AuthLoginRequestDtoToLoginModel: Profile
    {
        public AuthLoginRequestDtoToLoginModel()
        {
            CreateMap<AuthLoginRequestDTO, LoginModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
        
    }
}
