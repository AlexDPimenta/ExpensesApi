using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO;
using com.expenses.service.Interface.Login;

namespace com.expenses.api.Controllers
{
    public class AuthController : MainController
    {
        private readonly ILoginService _service;

        public AuthController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]        
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AuthAsync([FromBody] AuthLoginRequestDTO request, CancellationToken cancellationToken)
        {
            var token = await _service.CreateAsync(request, cancellationToken);
            if (token == null)
                return BadRequest();
         
            return Ok(token);
        }

        [HttpPost("sso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AuthSsoAsync([FromBody] AuthLoginSSoRequestDTO request, CancellationToken cancellationToken)
        {
            var token = await _service.GenerateAsync(request, cancellationToken);
            if (token == null)
                return BadRequest();

            return Ok(token);
        }



    }
}
