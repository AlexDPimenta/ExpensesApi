using AutoMapper;
using com.expenses.datacomunication.DTO.UserDTO;
using com.expenses.domain.DomainModel.User;

namespace com.expenses.datacomunication.Mapper.User
{
    public class UserRequestDTOToUserModel: Profile
    {
        public UserRequestDTOToUserModel()
        {
            CreateMap<UserRequestDTO, UserModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
    }
}
