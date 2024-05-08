using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_x_Store.Models
{
    public class Cliente
    {

        public int cod_cliente { get; set; }
        public string Nome_Sobrenome { get; set; }
        public string Razao_social { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string cidade { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NºLogradouro { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string IdNomeCliente
        {
            get
            {
                return cod_cliente.ToString() + " - " + Nome_Sobrenome;
            }
        }





    }
}
