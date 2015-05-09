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
    public class LocationsController : ApiController
    {
        private readonly IHrContext context;

            public LocationsController(IHrContext context)
            {
                this.context = context;
            
            }

        // GET: api/Locations
            public IEnumerable<Location> Get()
            {
                return context.Locations;
            }

        // GET: api/Locations/5
            public IHttpActionResult Get(string id)
            {
                var locationDB = context.Locations.Find(id);
                if (locationDB != null)
                {
                    return Ok(locationDB);
                }
                return NotFound();
            }

        // POST: api/Locations
            public IHttpActionResult Post(Location location)
            {
                var addedlocation = context.Locations.Add(location);

                return CreatedAtRoute("DefaultApi", new { controller = "Locations", id = addedlocation.LocationId }, addedlocation);

            }

        // PUT: api/Locations/5
            public IHttpActionResult Put(Location location)
            {
                if (ModelState.IsValid)
                {


                    var dblocation = context.Locations.Find(location.LocationId);
                    if (dblocation != null)
                    {
                        Mapper.Map(location, dblocation);

                        return Ok(context.SaveChanges());
                    }
                    return NotFound();
                }
                return BadRequest();
            }

        // DELETE: api/Locations/5
            public IHttpActionResult Delete(string id)
            {
                var dblocation = context.Locations.Find(id);
                if (dblocation != null)
                {
                    return Ok(context.Locations.Remove(dblocation));
                }
                return NotFound();
            }
    }
}
