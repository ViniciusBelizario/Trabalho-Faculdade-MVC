using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_x_Store.Models
{
    public class Produto
        
    {
        
        public int id_produto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Codigo_barras { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public int Quantidade_estoque { get; set; }
        public DateTime DtRegistro { get; set; }
       
       



    }
}
