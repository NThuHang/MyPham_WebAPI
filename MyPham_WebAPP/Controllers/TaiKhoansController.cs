using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPham_WebAPP.Controllers
{
    public class TaiKhoansController : Controller
    {
        // GET: TaiKhoans
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaiKhoans/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoans/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaiKhoans/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoans/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
