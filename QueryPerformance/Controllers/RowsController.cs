using System;
using System.Web.Mvc;

namespace QueryPerformance.Controllers
{
    public class RowsController : Controller
    {

        public ViewResult Thousand(int page = 1)
        {
            int recordsPerPage = 10;
            int totalRecords = 50;
            int totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);
            
            int startIndex = (page - 1) * recordsPerPage;
            int endIndex = Math.Min(page * recordsPerPage, totalRecords);
            
            ViewBag.CurrentPage = page;
            ViewBag.RecordsPerPage = recordsPerPage;
            ViewBag.TotalRecords = totalRecords;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartIndex = startIndex;
            ViewBag.EndIndex = endIndex;
            
            return View();
        }

        public ViewResult TenThousand()
        {
            return View();
        }

        public ViewResult HundredThousand()
        {
            return View();
        }

        public ViewResult Million()
        {
            return View();
        }

    }
}