using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.ViewModels
{
    public class RegisterVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
