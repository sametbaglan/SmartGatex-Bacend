using Microsoft.AspNetCore.Mvc;
using SmartGatex.DataAccess.Dtos.ResponsesDtos;

namespace SmartGatex.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
        [NonAction]
        public IActionResult FailurActionResult<T>(ResponseDto<T> response)
        {
            if (response.StatusCode == 400)
                return new ObjectResult(null)
                {
                    Value = response.Errors
                };
            return new ObjectResult(response)
            {
                Value = response.StatusCode

            };
        }
    }
}
