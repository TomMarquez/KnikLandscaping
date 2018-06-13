using KnikLandscaping.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnikLandscaping.ViewModels
{
    public class TestimonialsViewModel
    {
        //public int ID{ get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //[Required]
        //[StringLength(500, MinimumLength = 5)] //min length arbitrary...may need to change this
        //public string Content { get; set; }

        public List<Testimonial> testimonials { get; set; }
    }
}
