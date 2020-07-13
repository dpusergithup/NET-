using System.Web;
using System.Web.Mvc;
using 代码熟练度练习2.Models;

namespace 代码熟练度练习2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionFilterAtrribut());
        }
    }
}
