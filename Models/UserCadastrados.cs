using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Models
{
    public class UserCadastrados
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public string senha { get; set; } 
    }
}