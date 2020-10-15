using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPham_WebAPP.Controllers
{
    public class HoaDonsController : Controller
    {
        // GET: HoaDons
        public ActionResult Index()
        {
            return View();
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDons/Create
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

        // GET: HoaDons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoaDons/Edit/5
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

        // GET: HoaDons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoaDons/Delete/5
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
