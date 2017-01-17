using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErrorHandling.Helpers
{
    [AttributeUsage(
       AttributeTargets.Class | AttributeTargets.Method,
       Inherited = true,
       AllowMultiple = true)]
    public class CustomErrorHandlingAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // logging. 
           // HttpContext.Current.Response.Redirect("/Error");
            //throw new NotImplementedException();
        }
    }
}