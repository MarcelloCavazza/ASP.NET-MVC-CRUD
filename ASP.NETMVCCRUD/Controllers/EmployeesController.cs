using ASP.NETMVCCRUD.Data;
using ASP.NETMVCCRUD.Models.Domain;
using ASP.NETMVCCRUD.Models.View;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction("Add");

        }
    }
}
