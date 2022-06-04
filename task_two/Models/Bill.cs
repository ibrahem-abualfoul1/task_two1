using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Bill
    {

        [Key]
        public int IdBill { get; set; }
        [Required(ErrorMessage = "Please enter name bil")]

        public string NameBill { get; set; }
        public double Price { get; set; }
        public int? Id_regester { get; set; }
        [Required(ErrorMessage = "Please enter phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int PhoneNumber { get; set; }
       
        public bool activebill { get; set; }

       
        public DateTime DateBill { get; set; }


        
        
      

    }
}
