using System;
using System.Collections.Generic;
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
            jobs = new InMemoryJobsSet();
            locations = new InMemoryLocationSet();
            departments = new InMemoryDepartmentSet();
            employees = new InMemoryEmployeeSet();


            jobs.Add(new Job {JobId = "DEV", JobTitle = "Developer", MaxSalary = 2000, MinSalary = 1000});
            jobs.Add(new Job { JobId = "TST", JobTitle = "Tester", MaxSalary = 2000, MinSalary = 1000 });
            jobs.Add(new Job { JobId = "BID", JobTitle = "Bid", MaxSalary = 2000, MinSalary = 1000 });
            jobs.Add(new Job { JobId = "CEO", JobTitle = "Ceo", MaxSalary = 2000, MinSalary = 1000 });

            locations.Add(new Location
            {
                City = "Bucuresti",
                LocationId = 1,
                PostalCode = "1234",
                StateProvince = "Sector 1",
                StreetAddress = "Bd Timisoara"
            });
            locations.Add(new Location
            {
                City = "Iasi",
                LocationId = 2,
                PostalCode = "1233",
                StateProvince = "A",
                StreetAddress = "Bd Unirii"
            });

            departments.Add(new Department()
            {
                DepartmentId = 1,
                DepartmentName = "Solutii",
                Location = new Location
                {
                    City = "Bucuresti",
                    LocationId = 1,
                    PostalCode = "1234",
                    StateProvince = "Sector 1",
                    StreetAddress = "Bd Timisoara"
                }
            });
            employees.Add(new Employee()
            {
                EmployeeId = 1,
                FirstName = "Ion",
                LastName = "Popescu",
                CommisionPercent = 23,
                Email = "Popescu@email.com",
                HireDate = DateTime.Now.AddYears(-2),
                PhoneNumber = "123123123",
                Salary = 1234
            });
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}