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
    public class ChiTietHDsController : ApiController
    {
        private MyPhamEntities db = new MyPhamEntities();

        // GET: api/ChiTietHDs
        public IQueryable<ChiTietHD> GetChiTietHDs()
        {
            return db.ChiTietHDs;
        }

        // GET: api/ChiTietHDs/5
        [ResponseType(typeof(ChiTietHD))]
        public IHttpActionResult GetChiTietHD(string id)
        {
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return NotFound();
            }

            return Ok(chiTietHD);
        }

        // PUT: api/ChiTietHDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietHD(string id, ChiTietHD chiTietHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHD.ID_Chi_Tiet)
            {
                return BadRequest();
            }

            db.Entry(chiTietHD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHDExists(id))
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

        // POST: api/ChiTietHDs
        [ResponseType(typeof(ChiTietHD))]
        public IHttpActionResult PostChiTietHD(ChiTietHD chiTietHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHDs.Add(chiTietHD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChiTietHDExists(chiTietHD.ID_Chi_Tiet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chiTietHD.ID_Chi_Tiet }, chiTietHD);
        }

        // DELETE: api/ChiTietHDs/5
        [ResponseType(typeof(ChiTietHD))]
        public IHttpActionResult DeleteChiTietHD(string id)
        {
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return NotFound();
            }

            db.ChiTietHDs.Remove(chiTietHD);
            db.SaveChanges();

            return Ok(chiTietHD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHDExists(string id)
        {
            return db.ChiTietHDs.Count(e => e.ID_Chi_Tiet == id) > 0;
        }
    }
}