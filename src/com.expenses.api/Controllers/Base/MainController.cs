using Microsoft.AspNetCore.Mvc;

namespace com.expenses.api.Controllers.Base
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class MainController : ControllerBase
    {
       
    }
}
