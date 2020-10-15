using MyPham_WebAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyPham_WebAPP.Controllers
{
    public class SanPhamsController : Controller
    {
        string url = "https://localhost:44336/api/SanPhams/";
        // GET: SanPhams
        public ActionResult Index()
        {
            IEnumerable<SanPham> SanPhams = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("GetSanPhams");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    SanPhams = JsonConvert.DeserializeObject<List<SanPham>>(data);
                }
            }

            return View(SanPhams);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new HttpClient())
            {
                SanPham s = null;
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("GetSanPham/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<SanPham>(data);
                }
                return View("Details", s);
            }
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhams/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                string data = JsonConvert.SerializeObject(sp);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("PostSanPham", content);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Server Error. Please contact administrator!");

            return View(sp);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                SanPham s = null;
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("GetSanPham/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<SanPham>(data);
                }
                return View("Edit", s);
            }
        }

        // POST: SanPhams/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.PutAsync("PutSanPham/" + s.ID_Loai, content);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(s);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteSanPham/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        // POST: SanPhams/Delete/5
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
