using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication22sep.Models.EntityLayer
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

        public User User { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}