using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPi.Shared
{
    public class Item

    {   
        public int ItemId  { get; set; }
        [Required]
        public string Task { get; set; }
        [Range(1,100)]
        public int Status { get; set; }
        [Range(1,100)]
        public int Priority { get; set; }
       
    }
}
