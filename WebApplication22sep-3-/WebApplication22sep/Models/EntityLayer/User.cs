using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication22sep.Models.EntityLayer
{
    public class User
    {
       

        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Description { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool Status { get; set; }

        public bool IsDelete { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSub { get; set; }
        public bool IsWriter { get; set; }

       
    }
}