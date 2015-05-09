using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi.Controller
{
    public class EmployeesController : ApiController
    {

        private readonly IHrContext context;

            public EmployeesController(IHrContext context)
            {
                this.context = context;
            
            }

        // GET: api/Employees
            public IEnumerable<Employee> Get()
            {
                return context.Employees;
            }

        // GET: api/Employees/5
        public IHttpActionResult Get(string id)
        {
            var employeeDB = context.Employees.Find(id);
            if (employeeDB != null)
            {
                return Ok(employeeDB);
            }
            return NotFound();
        }

        // POST: api/Employees
        public IHttpActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (context.Jobs.Contains(employee.Job))
                {
                    if (context.Employees.Contains(employee.Manager))
                    {
                        if (context.Departments.Contains(employee.Department))
                        {
                            var addedemployee = context.Employees.Add(employee);

                            return CreatedAtRoute("DefaultApi", new { controller = "Employees", id = addedemployee.EmployeeId }, addedemployee);

                        }
                        return BadRequest("Departamentul nu exista!");
                    }
                    return BadRequest("Managerul nu exista!");
                }
                return BadRequest("Jobul nu exista!");


            }
            return BadRequest();
            
        }


        // PUT: api/Employees/5
        public IHttpActionResult Put(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (context.Jobs.Contains(employee.Job))
                {
                    if (context.Employees.Contains(employee.Manager))
                    {
                        if (context.Departments.Contains(employee.Department))
                        {
                            var dbemployee = context.Employees.Find(employee.EmployeeId);
                            if (dbemployee != null)
                            {
                                Mapper.Map(employee, dbemployee);

                                return Ok(context.SaveChanges());
                            }
                            return NotFound();
                        }
                        return BadRequest("Departamentul nu exista!");
                    }
                    return BadRequest("Managerul nu exista!");
                }
                return BadRequest("Jobul nu exista!");

               
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Employees/{id}/{newFirstName}")]
        public IHttpActionResult ChangeName(string id, string newFirstName)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.FirstName = newFirstName;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newDepartment}")]
        public IHttpActionResult ChangeDepartment(string id, Department newDepartment)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.Department = newDepartment;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newJob}")]
        public IHttpActionResult ChangeJob(string id, Job newJob)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.Job = newJob;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newEmail}")]
        public IHttpActionResult ChangeEmail(string id, string newEmail)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.Email = newEmail;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newPhoneNuber}")]
        public IHttpActionResult ChangePhoneNumber(string id, string newPhoneNumber)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.PhoneNumber = newPhoneNumber;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newSalary}")]
        public IHttpActionResult ModifySalary(string id, decimal newSalary)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.Salary = newSalary;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newManager}")]
        public IHttpActionResult ChangeManager(string id, Employee newManager)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.Manager = newManager;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("api/Employees/{id}/{newCommisionPercent}")]
        public IHttpActionResult ModifyCommisionPercent(string id, decimal newCommisionPercent)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                dbemployee.CommisionPercent = newCommisionPercent;
                return Ok(context.SaveChanges());
            }
            return BadRequest();

        }






        // DELETE: api/Employees/5
        public IHttpActionResult Delete(string id)
        {
            var dbemployee = context.Employees.Find(id);
            if (dbemployee != null)
            {
                return Ok(context.Employees.Remove(dbemployee));
            }
            return NotFound();
        }
    }
}
