using Microsoft.AspNetCore.Mvc;
using Stock.Core.Models;

namespace Stock.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBaseController : ControllerBase
    {
        public IActionResult Result<T>(Response<T> response)
        {
            if (response.StatusCode == (int)ResultCodes.NoContent)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            else
            {
                return new ObjectResult(response) { StatusCode = response.StatusCode };
            }
        }
    }
}