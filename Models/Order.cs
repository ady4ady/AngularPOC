using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Cars Car { get; set; }

        public Register Registration { get; set; }
    }
}
