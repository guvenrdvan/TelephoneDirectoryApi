using TelephoneDirectory.Core.ResponseManager;
using Microsoft.AspNetCore.Mvc;
using System.Net;




[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{


    protected IActionResult HandleResponse(BaseResponseModel responseModel)
    {
        if (responseModel.StatusCode == (int)HttpStatusCode.OK)
        {
            return Ok(responseModel);
        }
        else if (responseModel.StatusCode == (int)HttpStatusCode.BadRequest)
        {
            return BadRequest(responseModel);
        }
        else
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, responseModel);
        }
    }

    protected IActionResult HandleResponse<T>(BaseResponseModel<T> responseModel)
    {
        if (responseModel.StatusCode == (int)HttpStatusCode.OK)
        {
            return Ok(responseModel);
        }
        else if (responseModel.StatusCode == (int)HttpStatusCode.BadRequest)
        {
            return BadRequest(responseModel);
        }
        else
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, responseModel);
        }
    }
}
