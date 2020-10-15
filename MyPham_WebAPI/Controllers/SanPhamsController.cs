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
    public class SanPhamsController : ApiController
    {
        // GET: api/SanPham
        public HttpResponseMessage GetSanPhams()
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                var result = db.SanPhams;
                return Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            }

        }

        // GET: api/SanPham/5
        public SanPham GetSanPham(string id)
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                SanPham s = db.SanPhams.SingleOrDefault(x => x.ID_SP == id);
                if (s != null)
                    return s;
                else
                    return null;
            }
        }

        // POST: api/SanPham
        [HttpPost]
        public HttpResponseMessage PostSanPham([FromBody] SanPham SanPham)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    db.SanPhams.Add(SanPham);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/SanPham/5
        [HttpPut]
        public HttpResponseMessage PutSanPham(string id, [FromBody] SanPham SanPham)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    var s = db.SanPhams.SingleOrDefault(x => x.ID_SP == id);
                    if (s != null)
                    {
                        s.Ten_SP = SanPham.Ten_SP;
                        s.ID_Loai = SanPham.ID_Loai;
                        s.HinhAnh = SanPham.HinhAnh;
                        s.Mota = SanPham.Mota;
                        s.So_Luong = SanPham.So_Luong;
                        s.NoiDung = SanPham.NoiDung;
                        s.ThuongHieu = SanPham.ThuongHieu;

                        db.SaveChanges();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // DELETE: api/SanPham/5
        [HttpDelete]
        public HttpResponseMessage DeleteSanPham(string id)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    SanPham s = db.SanPhams.SingleOrDefault(x => x.ID_SP == id);
                    db.SanPhams.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Get các SanPham sắp hết ( SoLuongCon <10)
        public IHttpActionResult GetSP_SapHet()
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                List<SanPham> dshh = db.SanPhams.ToList();
                List<SanPham> dshhout = new List<SanPham>();
                foreach (SanPham hh in dshh)
                {
                    if (hh.So_Luong < 10)
                        dshhout.Add(hh);
                }
                if (dshhout == null)
                {
                    return NotFound();
                }
                return Ok(dshhout);
            }
        }
    }
}