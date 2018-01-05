using System.Reflection;
using System.Web.Http.Filters;

namespace ApiHelperPage.Filters
{
    public class ApiVersionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            actionExecutedContext.Response.Headers.Add("X-API-Version", assemblyVersion);
        }

    }
}