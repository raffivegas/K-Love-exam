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
    public class JoinedEmployeeController : Controller
    {
        private readonly KLoveCompanyCRUDContext _context;
        private List<string> _departments;

        public AddEmployeeVM viewModelAddEmployee;

        public JoinedEmployeeController(KLoveCompanyCRUDContext context)
        {
            _context = context;
            //viewModelAddEmployee = new AddEmployeeVM();
            //GetMoreContext(ref viewModelAddEmployee);
        }

        private void GetMoreContext(ref AddEmployeeVM viewModelAddEmployee)
        {
            throw new NotImplementedException();
        }

        // GET: Employees
        public async Task<IActionResult> Create()
        {
            var employees = await _context.Employee.ToListAsync();
            var departments = await _context.Department.ToListAsync();
            viewModelAddEmployee = new AddEmployeeVM();

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
        public async Task<IActionResult> Create([Bind("DepartmentId,FirstName,LastName,AddressLine1,AddressLine2,City,State,Zip,Email1,Email2")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Summary");
            }
            return View();
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            viewModelAddEmployee = new AddEmployeeVM();
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

            viewModelAddEmployee.AddressLine1 = employee.AddressLine1;
            viewModelAddEmployee.AddressLine2 = employee.AddressLine2;
            viewModelAddEmployee.City = employee.City;
            viewModelAddEmployee.State = employee.State;
            viewModelAddEmployee.Zip = employee.Zip;
            viewModelAddEmployee.Email1 = employee.Email1;
            viewModelAddEmployee.Email2 = employee.Email2;
            viewModelAddEmployee.FirstName = employee.FirstName;
            viewModelAddEmployee.LastName = employee.LastName;
            viewModelAddEmployee.DepartmentId = employee.DepartmentId;
            viewModelAddEmployee.EId = employee.Id;

            return View(viewModelAddEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,FirstName,LastName,AddressLine1,AddressLine2,City,State,Zip,Email1,Email2")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Summary");
            }
            return View("~/Views/Summary/Index.cshtml");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

    }
}
