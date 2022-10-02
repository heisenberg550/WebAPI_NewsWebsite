using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApplication22sep.Models;
using WebApplication22sep.Models.EntityLayer;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace WebApplication22sep.Controllers
{
    [RoutePrefix("Home/User")]
    [Route("{action=Index}/{id?}")]
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Index()
        {
            List<User> user = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.GetAsync("api/user").Result;
                    user = mesaj.Content.ReadAsAsync<List<User>>().Result;

                    ViewBag.message = "Api bağlantısı başarılı.";
                }
                catch (Exception)
                {




                    ViewBag.message = "Api bağlantısı başarısız.";

                }


            }
            return View(user);
        }



        [HttpGet]
        public ActionResult Detail()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Detail(int UserId)
        {
            User user = new User();

            if (UserId != 0 || UserId > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/user/" + UserId).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            user = mesaj.Content.ReadAsAsync<User>().Result;
                            ViewBag.message = "Api bağlantısı başarılı.";

                        }
                        else
                        {
                            ViewBag.message = UserId + "Api bağlantısı başarısız.";
                        }
                    }
                    catch (Exception)
                    {

                        ViewBag.message = "Api bağlantısı başarısız.";

                    }
                }
            }

            return View(user);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            User user = new User();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.GetAsync("api/user/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            user = mesaj.Content.ReadAsAsync<User>().Result;
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

            return View(user);


        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            User edituser = new User();

            edituser.Id = user.Id;
            edituser.Name = user.Name;
            edituser.SurName = user.SurName;
            edituser.Description = user.Description;
            edituser.Status = user.Status;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PutAsJsonAsync("api/User/", edituser).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        edituser = mesaj.Content.ReadAsAsync<User>().Result;
                        ViewBag.message = "Api bağlantısı başarılı.";

                    }
                    else
                    {
                        ViewBag.message = edituser.Id + "Api bağlantısı başarısız.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }
            }

            return View(edituser);


        }

        [HttpGet]
        public ActionResult Login()
        {
            List<User> user = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.GetAsync("api/user").Result;
                    user = mesaj.Content.ReadAsAsync<List<User>>().Result;

                    ViewBag.message = "Api bağlantısı başarılı.";
                }
                catch (Exception)
                {




                    ViewBag.message = "Api bağlantısı başarısız.";

                }


            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            User LoginUser = new User();

            LoginUser.Id = user.Id;
            LoginUser.Name = user.Name;
            LoginUser.SurName = user.SurName;
            LoginUser.Description = user.Description;
            LoginUser.Status = user.Status;
            LoginUser.IsAdmin=user.IsAdmin; 
            LoginUser.IsWriter =user.IsWriter; 
            LoginUser.IsSub=user.IsSub; 


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PutAsJsonAsync("api/User/", LoginUser).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        LoginUser = mesaj.Content.ReadAsAsync<User>().Result;
                        ViewBag.message = "Api bağlantısı başarılı.";

                    }
                    else
                    {
                        ViewBag.message = LoginUser.Id + "Api bağlantısı başarısız.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.message = "Api bağlantısı başarısız.";

                }
            }

            return View(LoginUser);


        }

        public ActionResult Delete(int Id)
        {
            User user = new User();

            if (Id != 0 || Id > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44359/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage mesaj = new HttpResponseMessage();
                    try
                    {
                        mesaj = client.DeleteAsync("api/user/" + Id).Result;


                        if (mesaj.IsSuccessStatusCode)
                        {
                            user = mesaj.Content.ReadAsAsync<User>().Result;
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

            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            User postuser = new User();


            postuser.Name = user.Name;
            postuser.SurName = user.SurName;
            postuser.Description = user.Description;
            postuser.Status = user.Status;
            postuser.IsAdmin = user.IsAdmin;
            postuser.IsDelete = user.IsDelete;
            postuser.IsSub = user.IsSub;
            postuser.IsWriter = user.IsWriter;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mesaj = new HttpResponseMessage();
                try
                {
                    mesaj = client.PostAsJsonAsync("api/user/", postuser).Result;


                    if (mesaj.IsSuccessStatusCode)
                    {
                        postuser = mesaj.Content.ReadAsAsync<User>().Result;
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