using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KLoveCompanyCRUD.Models;
using KLoveCompanyCRUD.View_Models;

namespace KLoveCompanyCRUD.Controllers
{
    public class SummaryController : Controller
    {
        private readonly KLoveCompanyCRUDContext _context;

        private SummaryVM viewModelSummary = new SummaryVM();

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public SummaryController(KLoveCompanyCRUDContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            var departments = await _context.Department.ToListAsync();
            viewModelSummary.AddressLine1 = employees[0].AddressLine1;
            viewModelSummary.Name = departments[0].Name;
            return View(viewModelSummary);
        }
    }
}