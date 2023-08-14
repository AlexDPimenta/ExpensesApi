using AutoMapper;
using com.expenses.datacomunication.DTO.RevenueDTO;
using com.expenses.domain.DomainModel.Revenue;

namespace com.expenses.datacomunication.Mapper.Revenue
{
    public class RevenuToUpdateDTOToRevenueModel: Profile
    {
        public RevenuToUpdateDTOToRevenueModel()
        {
            CreateMap<RevenueToUpdateDTO, RevenueModel>()
                .ForMember(c => c.CustomerId, d => d.Ignore());
        }
    }
}
