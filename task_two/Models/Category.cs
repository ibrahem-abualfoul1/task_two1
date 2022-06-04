using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Please enter NameCategory")]

        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public string Describtion { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile_Category{ get; set; }
        public virtual ICollection<Prodact> Productes { get; set; }



    }
}
