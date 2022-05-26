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

        public string NameMessege { get; set; }
        public string SenderEmail { get; set; }
        public string ResivedEmail { get; set; }
        public string Subject { get; set; }
        public string ContactMessege { get; set; }




    }
}
