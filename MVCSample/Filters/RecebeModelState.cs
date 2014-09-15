using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Filters
{
    public class RecebeModelState : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            const string chaveTempData = "_ModelState";

            var modelState = filterContext.Controller.TempData[chaveTempData];

            if(modelState == null)
                return;            
            
            filterContext.Controller.ViewData.ModelState.Merge((ModelStateDictionary)modelState);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}