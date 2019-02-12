using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdmxPractiseApplication.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
            : base("name=EdmxConnection")
        {

        }

        public System.Data.Entity.DbSet<EdmxPractiseApplication.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<EdmxPractiseApplication.Models.Book> Books { get; set; }

    }
}