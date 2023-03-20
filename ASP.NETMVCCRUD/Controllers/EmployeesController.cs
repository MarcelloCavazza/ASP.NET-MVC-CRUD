using ASP.NETMVCCRUD.Data;
using ASP.NETMVCCRUD.Models.Domain;
using ASP.NETMVCCRUD.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyDbContext myDbContext;

        public EmployeesController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employees> listOfEmployees = await myDbContext.Employees.ToListAsync();
            return View(listOfEmployees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            Employees employees = new Employees()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Password = addEmployeeRequest.Password,
                Salary = addEmployeeRequest.Salary,
            };

            await myDbContext.Employees.AddAsync(employees);
            await myDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel updatedEmployee)
        {
            Employees verifyEmployee = await myDbContext.Employees.FindAsync(updatedEmployee.Id);

            if(verifyEmployee != null)
            {
                verifyEmployee.Name = updatedEmployee.Name;
                verifyEmployee.Salary = updatedEmployee.Salary;
                verifyEmployee.Email = updatedEmployee.Email;
                verifyEmployee.Password = updatedEmployee.Password;
                verifyEmployee.UpdatedAt = DateTime.Now;


                await myDbContext.SaveChangesAsync();
            }

            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            Employees employee = await myDbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == Id);
            if(employee != null)
            {
                UpdateEmployeeViewModel model = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Email = employee.Email,
                    Password = employee.Password,
                    Salary = employee.Salary,
                    Name = employee.Name,
                };


                return await Task.Run(() => View("View", model));
            }


            return View("View");

        }
    }
}
