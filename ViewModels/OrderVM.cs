using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }

        public string OrderIdCode { get; set; }

        public List<int> CarId { get; set; }        

        public int UserId { get; set; }

        public List<int> OrderIdList { get; set; }

        public List<CarVM> CarsOrdered { get; set; }
    }
}
