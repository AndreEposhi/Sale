using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Sale.Core.Controller
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected IActionResult CustomResponse(object result = null)
        {
            if (IsValid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected IActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }
        protected bool IsValid()
            => !Errors.Any();

        protected void AddError(string error)
            => Errors.Add(error);

        protected void ClearError()
            => Errors.Clear();
    }
}