using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchCsharp.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Semestre { get; set; }

    }

}
