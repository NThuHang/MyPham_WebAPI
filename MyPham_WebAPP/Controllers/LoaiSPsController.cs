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
    public class LoaiSPsController : Controller
    {
        string url = "https://localhost:44336/api/LoaiSPs/";
        // GET: LoaiSPs
        public ActionResult Index()
        {
            IEnumerable<LoaiSP> LoaiSPs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = client.GetAsync("GetLoaiSPs");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    LoaiSPs = JsonConvert.DeserializeObject<List<LoaiSP>>(data);
                }
            }

            return View(LoaiSPs);
        }

        // GET: LoaiSPs/Details/5
        public ActionResult Details(string id)
        {
            IEnumerable<SanPham> sp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("GetSP_Loai/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    sp = JsonConvert.DeserializeObject<List<SanPham>>(data);
                }
            }
            return View(sp);
        }

        // GET: LoaiSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSPs/Create
        [HttpPost]
        public ActionResult Create(LoaiSP lsp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                string data = JsonConvert.SerializeObject(lsp);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("PostLoaiSP", content);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Vui Lòng Nhập Lại! Mã đã tồn tại");

            return View(lsp);
        }

        // GET: LoaiSPs/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new HttpClient())
            {
                LoaiSP s = null;
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("GetLoaiSP/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<LoaiSP>(data);
                }
                return View("Edit", s);
            }
        }

        [HttpPost]
        public ActionResult Edit(LoaiSP s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                string data = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var putTask = client.PutAsync("PutLoaiSP/" + s.ID_Loai, content);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Vui lòng nhập lại thông tin");

            return View(s);
        }
        // GET: LoaiSPs/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("deleteLoaiSP/" + id.ToString());
                deleteTask.Wait();


                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
