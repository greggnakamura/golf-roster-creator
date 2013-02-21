using System.Web;
using System.Web.Mvc;

namespace Golf_Roster_Creator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}