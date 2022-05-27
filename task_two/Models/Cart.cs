using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Models
{

    public class Cart
    {
        public int id { get; set; }

        public int? id_user {get; set ;} 
        
        
        public bool order {get; set ;}
        public virtual Prodact CartProdactTrans { get; set; }


    }


}
