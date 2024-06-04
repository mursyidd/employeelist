using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace test.web.Models;

public class EmployeeModel
{
    [Key]
    [Required]
    public int id { get; set; }

    [Display(Name = "Employee Name")]
    public string? username { get; set; }
    [Display(Name = "Phone No")]
    public string? phone_no { get; set; }
    [Display(Name = "Mail")]
    public string? mail { get; set; }
    [Display(Name = "Skill set")]
    public string? skill_set { get; set; }
    [Display(Name = "Hobby")]
    public string? hobby { get; set; }
}

class EmployeeDb : DbContext
{
    public EmployeeDb(DbContextOptions options) : base(options) { }
    public DbSet<EmployeeModel> EmployeeModels { get; set; } = null!;
}