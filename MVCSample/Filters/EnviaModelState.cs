using System.Web.Mvc;

namespace MVCSample.Filters
{
    public class EnviaModelState : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid)
                return;
            
            const string chaveTempData = "_ModelState";

            filterContext.Controller.TempData[chaveTempData] = filterContext.Controller.ViewData.ModelState;    
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}