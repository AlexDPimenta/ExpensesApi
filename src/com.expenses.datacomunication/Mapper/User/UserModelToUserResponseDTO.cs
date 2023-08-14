using AutoMapper;
using com.expenses.datacomunication.DTO.UserDTO;
using com.expenses.domain.DomainModel.User;

namespace com.expenses.datacomunication.Mapper.User
{
    public class UserModelToUserResponseDTO: Profile
    {
        public UserModelToUserResponseDTO()
        {
            CreateMap<UserModel, UserResponseDTO>();
        }
    }
}
