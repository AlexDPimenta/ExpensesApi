using AutoMapper;
using com.expenses.datacomunication.DTO.CategorieDTO;
using com.expenses.domain.DomainModel.Categorie;

namespace com.expenses.datacomunication.Mapper.Categorie
{
    public class CategorieRequestDTOToCategorieModel: Profile
    {
        public CategorieRequestDTOToCategorieModel()
        {
            CreateMap<CategorieRequestDTO, CategorieModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
    }
}
