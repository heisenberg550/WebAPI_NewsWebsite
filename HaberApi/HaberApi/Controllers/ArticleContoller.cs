﻿using HaberApi.Models;
using HaberApi.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaberApi.Controllers
{
    public class ArticleContoller: ApiController
    {
        DataContext db = new DataContext();

        public IEnumerable<Article> Get()
        {
            var article = db.Article.Where(x => x.IsDelete == false).ToList();
            return article;
        }

        public IHttpActionResult Get(int id)
        {
            var article = db.Article.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (article != null)
            {
                return Ok(article);

            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetbyYazarID(int id)
        {
            var article = db.Article.FirstOrDefault(x => x.UserId == id && x.IsDelete == false);
            if (article != null)
            {
                return Ok(article);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Article article)
        {
            db.Article.Add(article);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var article = db.Article.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (article != null)
            {
                article.IsDelete = true;
                db.SaveChanges();
                return Ok(" Başarıyla Silinmiştir");
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody] Article article)
        {
            var editarticle = db.Article.FirstOrDefault(x => x.Id == article.Id && x.IsDelete == false);
            if (editarticle != null)
            {
                editarticle.Title = article.Title;
                editarticle.Description = article.Description;
                editarticle.Status = article.Status;
                editarticle.Content = article.Content;
                editarticle.CategoryId = article.CategoryId;
                editarticle.UserId = article.UserId;
                db.SaveChanges();
                return Ok("Kitap Başarılı bir şekilde güncelledi.");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
