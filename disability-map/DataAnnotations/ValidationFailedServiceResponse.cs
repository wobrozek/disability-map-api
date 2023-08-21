using disability_map.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace disability_map.DataAnnotations
{
    public class ValidationFailedServiceResponse : ObjectResult
    {
        public ValidationFailedServiceResponse(ModelStateDictionary modelState) 
            : base(new ServiceResponse<string>() {Message = modelState.First().Value.Errors.First().ErrorMessage.ToString(), Success=false})
        {
            StatusCode = StatusCodes.Status400BadRequest; //change the http status code to 422.
        }
    }
}
