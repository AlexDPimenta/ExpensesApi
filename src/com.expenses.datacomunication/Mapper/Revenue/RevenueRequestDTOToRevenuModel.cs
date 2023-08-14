using AutoMapper;
using com.expenses.datacomunication.DTO.RevenueDTO;
using com.expenses.domain.DomainModel.Revenue;

namespace com.expenses.datacomunication.Mapper.Revenue
{
    public class RevenueRequestDTOToRevenuModel: Profile
    {
        public RevenueRequestDTOToRevenuModel()
        {
            CreateMap<RevenueRequestDTO, RevenueModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
    }
}
