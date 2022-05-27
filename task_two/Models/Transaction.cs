using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }

       public int idbill { get; set; }
        public string NameBill { get; set; }
        public double Price { get; set; }
        public int? IdUser { get; set; }

        public DateTime DateBill { get; set; }

        public bool activebill { get; set; }

        public virtual Account Accountid { get; set; }

    }
}
