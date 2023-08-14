using AutoMapper;
using com.expenses.datacomunication.DTO.CategorieDTO;
using com.expenses.domain.DomainModel.Categorie;

namespace com.expenses.datacomunication.Mapper.Categorie
{
    public class CategorieToUpdateDTOToCategorieModel: Profile
    {
        public CategorieToUpdateDTOToCategorieModel()
        {
            CreateMap<CategorieToUpdateDTO, CategorieModel>();
        }
    }
}
