using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberApi.Models.EntityModel
{
    public class DataContext: DbContext
    {

        public DataContext() : base("DbConnectionn") { }
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
