using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class MangePage
    {
        [Key]
        public int Id { get; set; }

        public string AboutUs { get; set; }
        public string ContactUs { get; set; }
        public string pharmacyName { get; set; }
        public string Pharmacylocation { get; set; }
        public string SocialMedia { get; set; }




    }
}
