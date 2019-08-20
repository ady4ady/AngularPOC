using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.ViewModels
{
    public class LoginRequestVM
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }       
    }
}
