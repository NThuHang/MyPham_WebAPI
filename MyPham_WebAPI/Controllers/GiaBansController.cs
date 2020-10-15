using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyPham_WebAPI.Models;

namespace MyPham_WebAPI.Controllers
{
    public class GiaBansController : ApiController
    {
        private MyPhamEntities db = new MyPhamEntities();

        // GET: api/GiaBans
        public IQueryable<GiaBan> GetGiaBans()
        {
            return db.GiaBans;
        }

        // GET: api/GiaBans/5
        [ResponseType(typeof(GiaBan))]
        public IHttpActionResult GetGiaBan(string id)
        {
            GiaBan giaBan = db.GiaBans.Find(id);
            if (giaBan == null)
            {
                return NotFound();
            }

            return Ok(giaBan);
        }

        // PUT: api/GiaBans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiaBan(string id, GiaBan giaBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaBan.ID_GB)
            {
                return BadRequest();
            }

            db.Entry(giaBan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaBanExists(id))
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

        // POST: api/GiaBans
        [ResponseType(typeof(GiaBan))]
        public IHttpActionResult PostGiaBan(GiaBan giaBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GiaBans.Add(giaBan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GiaBanExists(giaBan.ID_GB))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = giaBan.ID_GB }, giaBan);
        }

        // DELETE: api/GiaBans/5
        [ResponseType(typeof(GiaBan))]
        public IHttpActionResult DeleteGiaBan(string id)
        {
            GiaBan giaBan = db.GiaBans.Find(id);
            if (giaBan == null)
            {
                return NotFound();
            }

            db.GiaBans.Remove(giaBan);
            db.SaveChanges();

            return Ok(giaBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiaBanExists(string id)
        {
            return db.GiaBans.Count(e => e.ID_GB == id) > 0;
        }
    }
}