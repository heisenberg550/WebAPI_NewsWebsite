using HaberApi.Models;
using HaberApi.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaberApi.Controllers
{
    public class UserController : ApiController
    {

        DataContext db = new DataContext();

        public IEnumerable<User> Get()
        {
            var user = db.User.Where(x => x.IsDelete == false).ToList();
            return user;
        }

        
        public IHttpActionResult Get(int id)
        {
            var user = db.User.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            if (user != null)
            {
                return Ok(user);// 200 kodu döner yani başarılı
            }
            else
            {
                return NotFound();// 404 kodu değer bulunamadı
            }
        }

        public IHttpActionResult Post([FromBody] User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            //var user = db.User.Find(id);
            var user = db.User.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            if (user != null)
            {
                user.IsDelete = true;
                db.SaveChanges();
                return Ok(user.Name + "  Başarılı Bir Şekilde Silindi.");

            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody] User user)
        {
            var edituser = db.User.FirstOrDefault(x => x.Id == user.Id && x.IsDelete == false);
            if (edituser != null)
            {
                edituser.Name = user.Name;
                edituser.SurName = user.SurName;
                edituser.Description = user.Description;
                edituser.Status = user.Status;
                db.SaveChanges();

                return Ok(edituser.Name + " " + edituser.SurName
                    + "Adlı   Başarılı Bir Şekilde Güncellendi");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
