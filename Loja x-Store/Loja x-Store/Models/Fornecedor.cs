using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_x_Store.Models
{
    public class Fornecedor
    {
      
        public int idFornecedor { get; set; }
        public string Razao_social { get; set; }
        public string CNPJ { get; set; }
        public int quantidade_produto { get; set; }
        public string Descricao { get; set; }
        public string cidade { get; set; }
        public string UF { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string telefone { get; set; }
      
        


    }
}
