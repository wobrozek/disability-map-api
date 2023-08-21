using Microsoft.AspNetCore.Mvc.Filters;

namespace disability_map.DataAnnotations
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedServiceResponse(context.ModelState);
            }
        }
    }
}
