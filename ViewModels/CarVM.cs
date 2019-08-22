using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.ViewModels
{
    public class CarVM
    {
        public int CarId { get; set; }

        public string CarName { get; set; }

        public decimal CarPrice{ get; set; }
    }
}
