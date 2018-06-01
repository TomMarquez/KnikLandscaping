using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikLandscaping.Models
{
    public class KinkLandscapingContext : DbContext
    {
        public KinkLandscapingContext(IConfiguration configure, DbContextOptions options) 
            : base(options)
        {
            _config = configure;
        }

        public DbSet<Testimonial> Testimonials { get; set; }
        private IConfiguration _config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:KnikLandscapingConnection"]);
        }
    }
}
