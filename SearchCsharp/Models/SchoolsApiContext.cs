using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchCsharp.Models
{
    public class SchoolsApiContext : DbContext

    {
        public SchoolsApiContext(DbContextOptions<SchoolsApiContext> options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

    }
}
