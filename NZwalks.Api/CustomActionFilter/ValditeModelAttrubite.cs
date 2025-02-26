using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZwalks.Api.CustomActionFilter
{
    public class ValditeModelAttrubite : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            
            }
        }
    }
}
