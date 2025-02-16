using System;
using System.Web.Mvc;
using QueryPerformance.Models;
using QueryPerformance.Repositories.Implementations;
using QueryPerformance.Repositories.Interfaces;
using QueryPerformance.Data;

namespace QueryPerformance.Controllers
{
    public class RowsController : Controller
    {
        private readonly IGenericRepository<Person> _personRepository;

        public RowsController()
        {
            _personRepository = new GenericRepository<Person>(new SqlServerDbContext());
        }

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

            var persons = _personRepository.GetAll();
            
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