using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NETMVCCRUD.Models.View
{
    public class UpdateEmployeeViewModel
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public long Salary { get; set; }
            public DateTime CreatedDate { get; set; }
    }
}
