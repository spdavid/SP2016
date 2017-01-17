using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErrorHandling.Helpers
{
    public class SomeClassHelper
    {

        public static void SomeMethod()
        {
            try
            {
                // do soe code
            }
            catch (Exception ex)
            {

                LoggingHelper.LogException("error on some method", ex);
            }

        }
    }
}