using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string RoleName { get; set; }

      

    }
}
