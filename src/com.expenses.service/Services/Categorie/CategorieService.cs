using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.CategorieDTO;
using com.expenses.domain.DomainModel.Categorie;
using com.expenses.infra.Interface.Categorie;
using com.expenses.service.Interface;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Categorie
{
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notification;

        public CategorieService(ICategorieRepository repository, IMapper mapper, NotificationContext notification)
        {
            _repository = repository;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<CategorieResponseDTO> CreateAsync(CategorieRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<CategorieModel>(requestDTO);
            var response = await _repository.AddAsync(request, cancellationToken);
            return new CategorieResponseDTO { CategorieId = response.Id };
        }

        public async Task<CategorieToGetDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var categorie = await _repository.GetByIdAsync(id, cancellationToken);
            if (categorie == null)
            {
                _notification.AddNotification("categorieId", "Categorie not found!");
                return null;    
            }
            return _mapper.Map<CategorieToGetDTO>(categorie);
        }

        public async Task<CategoriesToGetByNameDTO> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetCategoriesByName(name, cancellationToken);
            if (!categories.Any())
            {
                _notification.AddNotification("Name", "Categories not found!");
                return default(CategoriesToGetByNameDTO);   
            }
            var response = _mapper.Map<IEnumerable<CategorieToGetDTO>>(categories);
            return new CategoriesToGetByNameDTO { Count = response.Count(), Categories = response};
        }

        public async Task<bool> UpdateAsync(Guid id, CategorieToUpdateDTO requestDTO, CancellationToken cancellationToken)
        {
            requestDTO.Id = id;
            var response = await _repository.UpdateAsync(_mapper.Map<CategorieModel>(requestDTO), cancellationToken);
            if(response == null)
            {
                _notification.AddNotification("categorieID", "Categorie not found!");
                return false;
            }
            return true;            
        }
    }
}
