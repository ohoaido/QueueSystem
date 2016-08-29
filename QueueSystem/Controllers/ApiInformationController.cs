using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using QueueSystem.Models;
using System.Web.Http.Cors;

namespace QueueSystem.Controllers
{
    public class ApiInformationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApiInformation
        [EnableCors(origins: "http://meditech.top", headers: "*", methods: "*")]
        public IQueryable<Information> GetInformations()
        {
            return db.Informations;
        }

        // GET: api/ApiInformation/5
        [ResponseType(typeof(Information))]
        public async Task<IHttpActionResult> GetInformation(int id)
        {
            Information information = await db.Informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            return Ok(information);
        }

        // PUT: api/ApiInformation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInformation(int id, Information information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != information.ID)
            {
                return BadRequest();
            }

            db.Entry(information).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiInformation
        [ResponseType(typeof(Information))]
        public async Task<IHttpActionResult> PostInformation(Information information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Informations.Add(information);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = information.ID }, information);
        }

        // DELETE: api/ApiInformation/5
        [ResponseType(typeof(Information))]
        public async Task<IHttpActionResult> DeleteInformation(int id)
        {
            Information information = await db.Informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            db.Informations.Remove(information);
            await db.SaveChangesAsync();

            return Ok(information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformationExists(int id)
        {
            return db.Informations.Count(e => e.ID == id) > 0;
        }
    }
}