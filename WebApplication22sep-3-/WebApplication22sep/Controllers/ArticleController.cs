using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication22sep.Models.EntityLayer;

namespace WebApplication22sep.Controllers
{
    [RoutePrefix("Home/Article")]
    [Route("{action=Index}/{id?}")]
    public class ArticleController : Controller
    {
        public ActionResult Index()
        {
            List<Article> article = new List<Article>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.GetAsync("api/article").Result;
                    article = mesaj.Content.ReadAsAsync<List<Article>>().Result;

                    ViewBag.message = "Api bağlantısı başarılı.";
                }
                catch (Exception)
                {
                    ViewBag.message = "Api bağlantısı başarısız.";
                }
            }
            return View(article);
        }

        //[HttpGet]
        public ActionResult Detail(int ArticleId)
        {
            Article article = new Article();
            if (ArticleId != 0 || ArticleId > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/article/" + ArticleId).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            article = mesaj.Content.ReadAsAsync<Article>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = ArticleId + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult Details(int ArticleId)
        {
            Article article = new Article();

            if (ArticleId != 0 || ArticleId > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/article/" + ArticleId).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            article = mesaj.Content.ReadAsAsync<Article>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = ArticleId + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }

            return View(article);
        }


       [HttpGet]
        public ActionResult Edit(int Id)
        {
            Article article = new Article();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/article/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            article = mesaj.Content.ReadAsAsync<Article>().Result;
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

            return View(article);


        }
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            Article editarticle = new Article();

            editarticle.Id = article.Id;
            editarticle.Title = article.Title;
            editarticle.Content = article.Content;
            editarticle.UserId = article.UserId;
            editarticle.CategoryId = article.CategoryId;
            editarticle.IsDeleted = article.IsDeleted;
      


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PutAsJsonAsync("api/Article/", editarticle).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        editarticle = mesaj.Content.ReadAsAsync<Article>().Result;
                        ViewBag.message = "Api bağlantısı başarılı.";

                    }
                    else
                    {
                        ViewBag.message = editarticle.Id + "Api bağlantısı başarısız.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }
            }

            return View(editarticle);


        }

        public ActionResult Delete(int Id)
        {
            Article article = new Article();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.DeleteAsync("api/article/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            article = mesaj.Content.ReadAsAsync<Article>().Result;
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

            Article article = new Article();
            return View(article);
        }
        [HttpPost]
        public ActionResult Add(Article article)
        {
            Article postarticle = new Article();


            postarticle.Title = article.Title;
            postarticle.Content = article.Content;
            postarticle.IsDeleted = article.IsDeleted;
            postarticle.UserId = article.UserId;
            postarticle.CategoryId = article.CategoryId;

              

          

      
        




            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PostAsJsonAsync("api/article/", postarticle).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        postarticle = mesaj.Content.ReadAsAsync<Article>().Result;
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