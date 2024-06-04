using Microsoft.EntityFrameworkCore;

class EmployeeDb : DbContext
{
    public EmployeeDb(DbContextOptions<EmployeeDb> options)
        : base(options) { }

    public DbSet<Employee> Employee => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>()
            .HasData(
            new Employee { Id = 1, username = "Ali", mail = "ali123@example.com", phone_no = "0145261224", skill_set = "Expertise in Adobe Photoshop", hobby = "Playing games", is_deleted = 0 },
            new Employee { Id = 2, username = "Abu", mail = "abu321@example.com", phone_no = "0126710449", skill_set = "Expertise in AutoCAD", hobby = "Reading books", is_deleted = 0 },
            new Employee { Id = 3, username = "Halim", mail = "Halim666@example.com", phone_no = "019222252", skill_set = "Expertise in Business", hobby = "Climbing mountain", is_deleted = 0 }
            );
    }
}