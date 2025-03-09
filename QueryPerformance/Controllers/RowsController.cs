using System.Web.Mvc;
using QueryPerformance.Models;
using QueryPerformance.Repositories.Implementations;
using QueryPerformance.Repositories.Interfaces;
using QueryPerformance.Data;
using QueryPerformance.Helpers;

namespace QueryPerformance.Controllers
{
    public class RowsController : Controller
    {
        private readonly IGenericRepository<OneThousandRows> _oneThousandRowsRepository;

        public RowsController()
        {
            _oneThousandRowsRepository = new GenericRepository<OneThousandRows>(new SqlServerDbContext());
        }

        public ViewResult Thousand(int page = 1, int recordsPerPage = 10, int groupSize = 5)
        {
            var rows = _oneThousandRowsRepository.GetAllRows();

            var pagedRows = PaginatedList<OneThousandRows>
                                                          .Create(rows, page, recordsPerPage, groupSize);

            return View(pagedRows);
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
