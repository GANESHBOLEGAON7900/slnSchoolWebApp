using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolWebApp.Utility
{

    //Authentication Filter
    //Authorization Filter
    //Action Filter
    //Result Filter
    //Exception Filter
    //Resource Filter

    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("OnAuthorization");
        }
    }

    public class CustomException : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine(context.Exception.Message.ToString());
        }
    }

    public class CustomAction : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("-- OnActionExecuted -- ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("-- OnActionExecuting -- ");
        }
    }

    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("--OnResourceExecuting--");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("--OnResourceExecuted--");
        }

    }


}
