using CopyData.DbContexts;
using CopyData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CopyData.Controllers
{
    public class HomeController : Controller
    {
        private readonly SampleContext _context;
        public HomeController(SampleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TableData(int currentPageIndex, string Searchdata)
        {
            var PaginationData = GetDataDB(currentPageIndex, Searchdata);

            return Json(PaginationData);
        }

        private DataModel GetDataDB(int CurrentPageIndex, string searchdata)
        {
            int Max = 10;
            var DATA = new DataModel();


            if (CurrentPageIndex == 0 && searchdata == null)
            {
                CurrentPageIndex = 1;

                DATA.GetEmployees = (from employee in _context.Employees
                                     select employee).OrderBy(m => m.Employee1).Skip((CurrentPageIndex - 1) * Max).
                                       Take(Max).ToList();

                double pagecount = (double)((decimal)_context.Employees.Count() / Convert.ToDecimal(Max));
                DATA.PageCount = (int)Math.Ceiling(pagecount);
                DATA.CurrentPageIndex = CurrentPageIndex;
            }
            else if (searchdata != null)
            {
                DATA.GetEmployees = (from employee in _context.Employees
                                     select employee).Where(m => m.EmpName.StartsWith(searchdata)).ToList();

                double pagecount = (double)((decimal)_context.Employees.Where(m => m.EmpName.StartsWith(searchdata)).Count() / Convert.ToDecimal(Max));
                DATA.PageCount = (int)Math.Ceiling(pagecount);
                DATA.CurrentPageIndex = CurrentPageIndex;
            }
            else
            {
                DATA.GetEmployees = (from employee in _context.Employees
                                     select employee).OrderBy(m => m.Employee1).Skip((CurrentPageIndex - 1) * Max).
                                      Take(Max).ToList();

                double pagecount = (double)((decimal)_context.Employees.Count() / Convert.ToDecimal(Max));
                DATA.PageCount = (int)Math.Ceiling(pagecount);
                DATA.CurrentPageIndex = CurrentPageIndex;
            }

            return DATA;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}