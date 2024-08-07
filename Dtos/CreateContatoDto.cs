using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateContatoDto
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string numero { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string foto { get; set; }
    }
}