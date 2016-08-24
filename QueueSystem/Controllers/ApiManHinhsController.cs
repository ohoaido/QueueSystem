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

namespace QueueSystem.Controllers
{
    public class ApiManHinhsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ManHinhs1
        public IQueryable<ManHinh> GetManHinhs()
        {
            return db.ManHinhs;
        }

        // GET: api/ManHinhs1/5
        [ResponseType(typeof(ManHinh))]
        public async Task<IHttpActionResult> GetManHinh(int id)
        {
            ManHinh manHinh = await db.ManHinhs.FindAsync(id);
            if (manHinh == null)
            {
                return NotFound();
            }

            return Ok(manHinh);
        }

        // PUT: api/ManHinhs1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutManHinh(int id, ManHinh manHinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manHinh.ID)
            {
                return BadRequest();
            }

            db.Entry(manHinh).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManHinhExists(id))
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

        // POST: api/ManHinhs1
        [ResponseType(typeof(ManHinh))]
        public async Task<IHttpActionResult> PostManHinh(ManHinh manHinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ManHinhs.Add(manHinh);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = manHinh.ID }, manHinh);
        }

        // DELETE: api/ManHinhs1/5
        [ResponseType(typeof(ManHinh))]
        public async Task<IHttpActionResult> DeleteManHinh(int id)
        {
            ManHinh manHinh = await db.ManHinhs.FindAsync(id);
            if (manHinh == null)
            {
                return NotFound();
            }

            db.ManHinhs.Remove(manHinh);
            await db.SaveChangesAsync();

            return Ok(manHinh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManHinhExists(int id)
        {
            return db.ManHinhs.Count(e => e.ID == id) > 0;
        }
    }
}