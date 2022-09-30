using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication22sep.Models.EntityLayer;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApplication22sep.Controllers
{
    [RoutePrefix("Home/cat")]
    [Route("{action=Index}/{id?}")]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> category = new List<Category>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.GetAsync("api/cat").Result;
                    category = mesaj.Content.ReadAsAsync<List<Category>>().Result;

                    ViewBag.message = "Api bağlantısı başarılı.";
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }


            }
            return View(category);
        }



        [HttpGet]
        public ActionResult Detail()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Detail(int CategoryId)
        {
            Category category = new Category();

            if (CategoryId != 0 || CategoryId > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/cat/" + CategoryId).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            category = mesaj.Content.ReadAsAsync<Category>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = CategoryId + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }

            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Category category = new Category();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/cat/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            category = mesaj.Content.ReadAsAsync<Category>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = Id + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }

            return View(category);


        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category editcategory = new Category();

            editcategory.Id = category.Id;
            editcategory.Name = category.Name;
            editcategory.Description = category.Description;
            editcategory.Status = category.Status;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PutAsJsonAsync("api/cat/", editcategory).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        editcategory = mesaj.Content.ReadAsAsync<Category>().Result;
                        ViewBag.message = "Api bağlantısı başarılı.";

                    }
                    else
                    {
                        ViewBag.message = editcategory.Id + "Api bağlantısı başarısız.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }
            }

            return View(editcategory);


        }

        public ActionResult Delete(int Id)
        {
            Category category = new Category();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.DeleteAsync("api/cat/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            category = mesaj.Content.ReadAsAsync<Category>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = Id + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Add()
        {

            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            Category postcategory = new Category();

            postcategory.Name = category.Name;
            postcategory.Description = category.Description;
            postcategory.Status = category.Status;
            postcategory.IsDelete = category.IsDelete;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PostAsJsonAsync("api/cat/", postcategory).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        postcategory = mesaj.Content.ReadAsAsync<Category>().Result;
                        ViewBag.message = "Api bağlantısı başarılı.";

                    }
                    else
                    {
                        ViewBag.message = "Api bağlantısı başarısız.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }
            }

            return RedirectToAction("Index");

        }


    }
}