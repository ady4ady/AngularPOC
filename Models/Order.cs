using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderIdCode { get; set; }

        public int CarId { get; set; }

        public virtual Cars Car { get; set; }

        public int RegistrationId { get; set; }

        public virtual Register Registration { get; set; }
    }
}
