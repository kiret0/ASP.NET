using System.Web.Mvc;

namespace Prodavalnik.Web
{
    using System;
    using System.Web;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           filters.Add(new HandleErrorAttribute());
        }

        
    }
}
