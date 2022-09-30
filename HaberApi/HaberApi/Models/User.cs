using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberApi.Models
{
    public class User:GenerateProp
    {

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsSub { get; set; }
        public bool IsWriter { get; set; }

        public List<Article> Article { get; set; }
    }
}
