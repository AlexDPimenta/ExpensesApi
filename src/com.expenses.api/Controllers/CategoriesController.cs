using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO.CategorieDTO;
using com.expenses.service.Interface;

namespace com.expenses.api.Controllers
{
    public class CategoriesController: MainController
    {
        private readonly ICategorieService _service;

        public CategoriesController(ICategorieService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CategorieRequestDTO requestDTO, CancellationToken cancellationToken)
        {            
            var categorie = await _service.CreateAsync(requestDTO, cancellationToken);         

            return Created("", categorie);
        }

        [HttpGet("{categorieID:Guid}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid categorieID, CancellationToken cancellationToken)
        {
            var categorie = await _service.GetByIdAsync(categorieID, cancellationToken);

            if (categorie == null)
                return BadRequest();

            return Ok(categorie);
        }

        [HttpGet("{NAME}")]        
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByNameAsync(string NAME, CancellationToken cancellationToken)
        {
            var categories = await _service.GetByNameAsync(NAME, cancellationToken);

            if (categories == null)
                return BadRequest();

            return Ok(categories);
        }

        [HttpPut("{categorieID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid categorieID, CategorieToUpdateDTO categorie, CancellationToken cancellationToken)
        {
            var response = await _service.UpdateAsync(categorieID, categorie, cancellationToken);
            if (!response)
                return BadRequest();

            return Ok();
        }
    }
}
