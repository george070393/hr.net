using System.Data.Entity;
using Personal.Entities;

namespace Personal.Persistence
{
    public class InMemoryHrContext : IHrContext
    {
        private readonly DbSet<Job> jobs;
        private readonly DbSet<Location> locations;
        private readonly DbSet<Department> departments;
        private readonly DbSet<Employee> employees;

        public DbSet<Job> Jobs
        {
            get { return jobs; }
        }

        public DbSet<Location> Locations
        {
            get { return locations; }
        }

        public DbSet<Department> Departments
        {
            get { return departments; }
        }

        public DbSet<Employee> Employees
        {
            get { return employees; }
        }

        public InMemoryHrContext()
        {
            jobs = new InMemoryDbSet<Job>();
            locations = new InMemoryDbSet<Location>();
            departments = new InMemoryDbSet<Department>();
            employees = new InMemoryDbSet<Employee>();
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}