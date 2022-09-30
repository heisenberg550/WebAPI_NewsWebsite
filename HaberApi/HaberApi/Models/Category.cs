using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberApi.Models
{
    public class Category : GenerateProp
    {
        public string Name { get; set; }
        public List<Article> Article { get; set; }

    }
}
