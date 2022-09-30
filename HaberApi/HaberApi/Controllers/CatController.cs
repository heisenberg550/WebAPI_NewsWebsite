using HaberApi.Models;
using HaberApi.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HaberApi.Controllers
{
    public class CatController : ApiController
    {

        DataContext db = new DataContext();

        public IEnumerable<Category> Get()
        {
            var category = db.Category.Where(x => x.IsDelete == false).ToList();
            return category;
        }

        public IHttpActionResult Get(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (category != null)
            {

                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (category != null)
            {
                category.IsDelete = true;
                db.SaveChanges();
                return Ok("Raf Başarılı Bir Şekilde Silindi");
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody] Category category)
        {
            var edittur = db.Category.FirstOrDefault(x => x.Id == category.Id && x.IsDelete == false);
            if (edittur != null)
            {

                edittur.Name = category.Name;
                edittur.Description = category.Description;
                edittur.Status = category.Status;
                edittur.IsDelete = category.IsDelete;
                db.SaveChanges();
                return Ok("Raf Başarılı bir şekilde güncellendi.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}