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
    public class QuanLiesController : ApiController
    {
        private MyPhamEntities db = new MyPhamEntities();

        // GET: api/QuanLies
        public IQueryable<QuanLy> GetQuanLies()
        {
            return db.QuanLies;
        }

        // GET: api/QuanLies/5
        [ResponseType(typeof(QuanLy))]
        public IHttpActionResult GetQuanLy(string id)
        {
            QuanLy quanLy = db.QuanLies.Find(id);
            if (quanLy == null)
            {
                return NotFound();
            }

            return Ok(quanLy);
        }

        // PUT: api/QuanLies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuanLy(string id, QuanLy quanLy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quanLy.ID_QL)
            {
                return BadRequest();
            }

            db.Entry(quanLy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanLyExists(id))
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

        // POST: api/QuanLies
        [ResponseType(typeof(QuanLy))]
        public IHttpActionResult PostQuanLy(QuanLy quanLy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuanLies.Add(quanLy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuanLyExists(quanLy.ID_QL))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = quanLy.ID_QL }, quanLy);
        }

        // DELETE: api/QuanLies/5
        [ResponseType(typeof(QuanLy))]
        public IHttpActionResult DeleteQuanLy(string id)
        {
            QuanLy quanLy = db.QuanLies.Find(id);
            if (quanLy == null)
            {
                return NotFound();
            }

            db.QuanLies.Remove(quanLy);
            db.SaveChanges();

            return Ok(quanLy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuanLyExists(string id)
        {
            return db.QuanLies.Count(e => e.ID_QL == id) > 0;
        }
    }
}