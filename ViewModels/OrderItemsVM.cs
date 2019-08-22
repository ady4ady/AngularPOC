using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.ViewModels
{
    public class OrderItemsVM
    {
        public List<int> OrderId { get; set; }

        public List<int> CarId { get; set; }        
    }
}
