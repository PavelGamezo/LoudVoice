using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LoudVoiceAPI.Common.Error
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<ErrorOr.Error> errors)
        {
            if (errors.Count == 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            return Problem(errors.First());
        }

        private IActionResult Problem(ErrorOr.Error firstError)
        {
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Failure => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,

            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }

        private IActionResult ValidationProblem(List<ErrorOr.Error> errors)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelState.AddModelError(
                    error.Code,
                    error.Description);
            }

            return ValidationProblem(modelState);
        }
    }
}
