using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Bill
    {

        [Key]
        public int IdBill { get; set; }
        public int PhoneNumber { get; set; }
        public int Discounte { get; set; }

        public string NameBill { get; set; }
        public string Numberitems { get; set; }

        public DateTime DateBill { get; set; }




    }
}
