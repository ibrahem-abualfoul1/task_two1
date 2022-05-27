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
        public string NameBill { get; set; }
        public double Price { get; set; }
        public int? Id_regester { get; set; }
        public int PhoneNumber { get; set; }
       
        public bool activebill { get; set; }

       
        public DateTime DateBill { get; set; }


        
        public virtual Prodact IdProdactTrans { get; set; }
        
      

    }
}
