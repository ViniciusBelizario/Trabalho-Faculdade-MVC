using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_x_Store.Models
{
    public class Funcionario
    {

        public int id_Funcionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public  string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        
     

    }
}
