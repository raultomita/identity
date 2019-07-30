using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProvider.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }        
    }
}
