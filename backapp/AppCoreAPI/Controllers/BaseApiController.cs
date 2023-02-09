using BLL.DTO.MainDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    [SwaggerResponse(statusCode: StatusCodes.Status401Unauthorized, type: typeof(ErrorDetails))]
    [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(ErrorDetails))]
    [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(ErrorDetails))]
    public class BaseApiController : ControllerBase
    {
    }
}
