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
    public class AddJoinedEmployeeController : Controller
    {
        private readonly KLoveCompanyCRUDContext _context;

        //public List<SummaryVM> viewModelSummaryList = new List<SummaryVM>();

        //public SummaryVM testRaf = new SummaryVM();

        public AddEmployeeVM viewModelAddEmployee = new AddEmployeeVM();


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public AddJoinedEmployeeController(KLoveCompanyCRUDContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            var departments = await _context.Department.ToListAsync();

            var listOfDepartments = from department in departments
                                    select new
                                    {
                                        DepartmentName = department.Name,
                                        DepartmentId = department.Id
                                    };


            //not pretty, but will do for now.  Git err dun.
            foreach (var row in listOfDepartments)
            {
                viewModelAddEmployee.Departments.Add(row.DepartmentName, row.DepartmentId.ToString());
            }

            //return View(viewModelSummaryList);
            return View(viewModelAddEmployee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FirstName,LastName,AddressLine1,AddressLine2,City,State,Zip,Email1,Email2")] Employee employee)
        public async Task<IActionResult> Create(AddEmployeeVM dept,[Bind("FirstName,LastName,AddressLine1,AddressLine2,City,State,Zip,Email1,Email2")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                //Employee employee = new Employee();
                //employee.AddressLine1 = 
                //var test = viewModel.Name;
                string tst = Request.Form["Departments"][0];
                //employee.
                //_context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}