using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Prodact
    {
        [Key]
        public int IdProdact { get; set; }
        public string NameProdact { get; set; }
        public string Describtion { get; set; }

        public DateTime DateProdact { get; set; }

        public int Price { get; set; }
        public int Units { get; set; }
        public int IdCategory { get; set; }

        public virtual Category Catigory { get; set; }


    }
}
