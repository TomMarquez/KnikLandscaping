using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikLandscaping.Models
{
    public class KnikLandScapingSeedData
    {
        private KinkLandscapingContext _context;

        public KnikLandScapingSeedData(KinkLandscapingContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Testimonials.Any())
            {
                var testimonial1 = new Testimonial()
                {
                    FirstName = "John",
                    LastName = "JingleHeimerSmith",
                    Content = "This is the best place!!!"
                };

                _context.Testimonials.Add(testimonial1);

                var testimonial2 = new Testimonial()
                {
                    FirstName = "Dude",
                    LastName = "DudeMcDudeFace",
                    Content = "It's aight. The guy Trustin who works there kind of smells funny!"
                };

                _context.Testimonials.Add(testimonial2);

                await _context.SaveChangesAsync();
            }
        }
    }
}
