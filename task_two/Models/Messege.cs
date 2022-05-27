using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Messege
    {
        [Key]
        public int IdMessege { get; set; }
        [Required(ErrorMessage = "Please enter NameMessege")]
        public string NameMessege { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string SenderEmail { get; set; }
        public string ResivedEmail { get; set; }
        [Required(ErrorMessage = "Please enter Subject")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter ContactMessege")]

        public string ContactMessege { get; set; }




    }
}
