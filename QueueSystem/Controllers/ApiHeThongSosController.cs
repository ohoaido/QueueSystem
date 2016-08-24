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
    public class ApiHeThongSosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/HeThongSoes
        public IQueryable<HeThongSo> GetHeThongSos()
        {
            return db.HeThongSos;
        }

        // GET: api/HeThongSoes/5
        [ResponseType(typeof(HeThongSo))]
        public async Task<IHttpActionResult> GetHeThongSo(int id)
        {
            HeThongSo heThongSo = await db.HeThongSos.FindAsync(id);
            if (heThongSo == null)
            {
                return NotFound();
            }

            return Ok(heThongSo);
        }

        // PUT: api/HeThongSoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHeThongSo(int id, HeThongSo heThongSo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heThongSo.ID)
            {
                return BadRequest();
            }

            db.Entry(heThongSo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeThongSoExists(id))
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

        // POST: api/HeThongSoes
        [ResponseType(typeof(HeThongSo))]
        public async Task<IHttpActionResult> PostHeThongSo(HeThongSo heThongSo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HeThongSos.Add(heThongSo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = heThongSo.ID }, heThongSo);
        }

        // DELETE: api/HeThongSoes/5
        [ResponseType(typeof(HeThongSo))]
        public async Task<IHttpActionResult> DeleteHeThongSo(int id)
        {
            HeThongSo heThongSo = await db.HeThongSos.FindAsync(id);
            if (heThongSo == null)
            {
                return NotFound();
            }

            db.HeThongSos.Remove(heThongSo);
            await db.SaveChangesAsync();

            return Ok(heThongSo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeThongSoExists(int id)
        {
            return db.HeThongSos.Count(e => e.ID == id) > 0;
        }
    }
}