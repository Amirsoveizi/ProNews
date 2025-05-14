using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProNews.Controllers
{
    public class LinqController : Controller
    {
        List<string> names = new List<string> { "John", "Samuel", "Liam", "Olivia", "Noah", "Ava", "Sam", "Sophia", "James", "Isabella" };
        // GET: Linq
        public ActionResult Index()
        {
            return View(names);
        }

        public ActionResult SortDescending()
        {
            var sortedNames = (from name in names
                               orderby name descending
                               select name).ToList();
            return PartialView("_List",sortedNames);
        }

        public ActionResult ShowNamesWithS()
        {
            var namesWithS = names.Where(name => name.StartsWith("S", StringComparison.OrdinalIgnoreCase) && name.Length > 3).ToList();

            return PartialView("_List", namesWithS);
        }

        public ActionResult Last3Names()
        {
            var last3Names = (from name in names
                              let index = names.IndexOf(name)
                              where index >= names.Count - 3
                              select name
                              ).ToList();

            return PartialView("_List", last3Names);
        }

        public ActionResult FirstAndLast()
        {
            var firstAndLast = (from name in names
                                let index = names.IndexOf(name)
                                where index == 0 || index == names.Count - 1
                                select name
                                ).ToList();


            return PartialView("_List", firstAndLast);
        }
    }
}