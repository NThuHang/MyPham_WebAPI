using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPham_WebAPP.Controllers
{
    public class KhachHangsController : Controller
    {
        // GET: KhachHangs
        public ActionResult Index()
        {
            return View();
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
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

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhachHangs/Edit/5
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

        // GET: KhachHangs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhachHangs/Delete/5
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
