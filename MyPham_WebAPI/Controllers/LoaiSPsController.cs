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
    public class LoaiSPsController : ApiController
    {
        // Hiện thị all loại sản phẩm
        public HttpResponseMessage GetLoaiSPs()
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                var result = db.LoaiSPs;
                return Request.CreateResponse(HttpStatusCode.OK, result.ToList());
            }

        }

        // Get theo mã loại 
        public LoaiSP GetLoaiSP(string id)
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                LoaiSP s = db.LoaiSPs.SingleOrDefault(x => x.ID_Loai == id);
                if (s != null)
                    return s;
                else
                    return null;
            }
        }

        //Hiển thị sản phẩm theo mã loại
        public IHttpActionResult GetSP_Loai(string id)
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                List<SanPham> dshh = db.SanPhams.ToList();
                List<SanPham> dshhout = new List<SanPham>();
                foreach (SanPham hh in dshh)
                {
                    if (hh.ID_Loai.Equals(id))
                        dshhout.Add(hh);
                }
                if (dshhout == null)
                {
                    return NotFound();
                }
                return Ok(dshhout);
            }
        }
        // Thêm loại sản phẩm
        [HttpPost]
        public HttpResponseMessage PostLoaiSP([FromBody] LoaiSP LoaiSP)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    db.LoaiSPs.Add(LoaiSP);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // Sửa loại sản phẩm
        [HttpPut]
        public HttpResponseMessage PutLoaiSP(string id, [FromBody] LoaiSP LoaiSP)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    var s = db.LoaiSPs.SingleOrDefault(x => x.ID_Loai == id);
                    if (s != null)
                    {
                        s.Ten_Loai = LoaiSP.Ten_Loai;
                        s.ID_Cha = LoaiSP.ID_Cha;
                        s.MoTa = LoaiSP.MoTa;
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

        // DELETE: api/LoaiSP/5
        [HttpDelete]
        public HttpResponseMessage DeleteLoaiSP(string id)
        {
            try
            {
                using (MyPhamEntities db = new MyPhamEntities())
                {
                    LoaiSP s = db.LoaiSPs.SingleOrDefault(x => x.ID_Loai == id);
                    db.LoaiSPs.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Get các LoaiSP theo TenLoai 
        public IHttpActionResult GetLoaiSP_TenLoai(string tenloai)
        {
            using (MyPhamEntities db = new MyPhamEntities())
            {
                List<LoaiSP> dshh = db.LoaiSPs.ToList();
                List<LoaiSP> dshhout = new List<LoaiSP>();
                LoaiSP lh = db.LoaiSPs.FirstOrDefault(e => e.Ten_Loai == tenloai);
                foreach (LoaiSP hh in dshh)
                {
                    if (hh.ID_Loai.Equals(lh.ID_Loai))
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