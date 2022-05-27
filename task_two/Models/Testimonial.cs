using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Testimonial
    {

        [Key]
        public int Id { get; set; }
        public string ContactText { get; set; }

       
        public int Reviwe { get; set; } 
        
        public int? Id_regester { get; set; }
        public bool active { get; set; }


    }
}
