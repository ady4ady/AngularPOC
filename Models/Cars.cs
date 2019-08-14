using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public string CarName { get; set; }

        public decimal CarPrice { get; set; }
    }
}
