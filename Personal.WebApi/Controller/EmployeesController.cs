﻿using System;
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
            var addedemployee = context.Employees.Add(employee);

            return CreatedAtRoute("DefaultApi", new { controller = "Employees", id = addedemployee.EmployeeId }, addedemployee);

        }


        // PUT: api/Employees/5
        public IHttpActionResult Put(Employee employee)
        {
            if (ModelState.IsValid)
            {


                var dbemployee = context.Employees.Find(employee.EmployeeId);
                if (dbemployee != null)
                {
                    Mapper.Map(employee, dbemployee);

                    return Ok(context.SaveChanges());
                }
                return NotFound();
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
