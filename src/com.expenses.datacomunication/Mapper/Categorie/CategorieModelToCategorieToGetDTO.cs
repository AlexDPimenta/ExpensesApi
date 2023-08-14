using AutoMapper;
using com.expenses.datacomunication.DTO.CategorieDTO;
using com.expenses.domain.DomainModel.Categorie;

namespace com.expenses.datacomunication.Mapper.Categorie
{
    public class CategorieModelToCategorieToGetDTO: Profile
    {
        public CategorieModelToCategorieToGetDTO()
        {
            CreateMap<CategorieModel, CategorieToGetDTO>();
        }
    }
}
