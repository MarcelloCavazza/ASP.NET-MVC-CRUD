using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETMVCCRUD.Models
{
    [Table("Employees")]
    public class Employees
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Column("Password")]
        public string Password { get; set; }
        [Display(Name = "Salary")]
        [Column("Salary")]
        public long Salary { get; set; }
        [Display(Name = "CreatedAt")]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "UpdatedAt")]
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
