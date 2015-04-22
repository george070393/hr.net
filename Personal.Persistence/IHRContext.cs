using System.Data.Entity;
using Personal.Entities;

namespace Personal.Persistence
{
    interface IHrContext
    {
        DbSet<Job> Jobs { get; }
        DbSet<Location> Locations { get; }
        DbSet<Department> Departments { get; }
        DbSet<Employee> Employees { get; }

        int SaveChanges();
    }
}
