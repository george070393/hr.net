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
    public class DepartmentsController : ApiController
    {

        private readonly IHrContext context;

            public DepartmentsController(IHrContext context)
            {
                this.context = context;
            
            }
        // GET: api/Departments
            public IEnumerable<Department> Get()
            {
                return context.Departments;
            }

        // GET: api/Departments/5
            public IHttpActionResult Get(string id)
            {
                var departmentDB = context.Departments.Find(id);
                if (departmentDB != null)
                {
                    return Ok(departmentDB);
                }
                return NotFound();
            }


        // POST: api/Departments
            public IHttpActionResult Post(Department department)
            {
                var addeddepartment = context.Departments.Add(department);

                return CreatedAtRoute("DefaultApi", new { controller = "Departments", id = addeddepartment.DepartmentId }, addeddepartment);

            }

        // PUT: api/Departments/5
            public IHttpActionResult Put(Department department)
            {
                if (ModelState.IsValid)
                {


                    var dbdepartment = context.Departments.Find(department.DepartmentId);
                    if (dbdepartment != null)
                    {
                        Mapper.Map(department, dbdepartment);

                        return Ok(context.SaveChanges());
                    }
                    return NotFound();
                }
                return BadRequest();
            }

        // DELETE: api/Departments/5
            public IHttpActionResult Delete(string id)
            {
                var dbdepartment = context.Departments.Find(id);
                if (dbdepartment != null)
                {
                    return Ok(context.Departments.Remove(dbdepartment));
                }
                return NotFound();
            }
    }
}
