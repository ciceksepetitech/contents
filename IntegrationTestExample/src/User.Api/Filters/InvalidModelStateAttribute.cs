using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace User.Api.Filters
{
    public class InvalidModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                var responseObj = new
                {
                    Messages = errors
                };

                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}