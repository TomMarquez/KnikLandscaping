using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikLandscaping.Models
{
    public class KinkLandscapingContext : DbContext
    {
        public KinkLandscapingContext()
        {

        }

        public DbSet<Testimonials> Testimonials { get; set; }

    }
}
