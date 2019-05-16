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

        public List<SummaryVM> viewModelSummaryList = new List<SummaryVM>();

        public SummaryVM testRaf = new SummaryVM();
        
        public SummaryController(KLoveCompanyCRUDContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            var departments = await _context.Department.ToListAsync();

            var innerJoinQuery =
                from employee in employees
                join department in departments on employee.DepartmentId equals department.Id
                select new { Department = department.Name, EId = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName,
                             Address1 = employee.AddressLine1, Address2 = employee.AddressLine2,
                             City = employee.City, State = employee.State, Zip = employee.Zip,
                             Email1 = employee.Email1, Email2 = employee.Email2}; //produces flat sequence

            //not pretty, but will do for now.  Git err dun.
            foreach (var row in innerJoinQuery)
            {
                var viewModelSummary = new SummaryVM();
                viewModelSummary.Department = row.Department;
                viewModelSummary.EId = row.EId;
                viewModelSummary.FirstName = row.FirstName;
                viewModelSummary.LastName = row.LastName;
                viewModelSummary.AddressLine1 = row.Address1;
                viewModelSummary.AddressLine2 = row.Address2;
                viewModelSummary.City = row.City;
                viewModelSummary.State = row.State;
                viewModelSummary.Zip = row.Zip;
                viewModelSummary.Email1 = row.Email1;
                viewModelSummary.Email2 = row.Email2;
                testRaf.summaryVMs.Add(viewModelSummary);
            }

            //return View(viewModelSummaryList);
            return View(testRaf);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("Edit", "JoinedEmployee", new { id });
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
            //return View("~/Views/Summary/Index.cshtml");
        }

    }
}