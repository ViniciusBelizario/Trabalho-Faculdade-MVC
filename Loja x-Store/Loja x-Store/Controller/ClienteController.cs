using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja_x_Store.Models;
using Loja_x_Store.Services;
using System;
using System.Data;

namespace Loja_x_Store.Controller
{
    public class ClienteController
    {
        #region Variaveis Locais
        //Variavel local e privada que faz o acesso ao 
        //banco de dados e executa os comandos.
        DatabaseSqlServer dataBase = new DatabaseSqlServer();

        #endregion

        #region Inserir
        

        public int Inserir(Cliente cliente)
        {
            
            string queryInserir =
                "INSERT INTO Cliente (Nome_Sobrenome, CEP, CPF, " +
                "Data_nascimento,cidade, Endereco,Telefone,Email,NºLogradouro,UF,Bairro) VALUES (@Nome_Sobrenome, " +
                "@CEP, @CPF, @Data_nascimento, @cidade,@Endereco,@Telefone,@Email,@NºLogradouro,@UF,@Bairro)";

            
            dataBase.LimparParametros();

            dataBase.AdicionarParametros("@Nome_Sobrenome", cliente.Nome_Sobrenome);
            dataBase.AdicionarParametros("@CEP", cliente.CEP);
            dataBase.AdicionarParametros("@CPF", cliente.CPF);
            dataBase.AdicionarParametros("@Data_nascimento", cliente.Data_Nascimento);
            dataBase.AdicionarParametros("@cidade", cliente.cidade);
            dataBase.AdicionarParametros("@Endereco", cliente.Endereco);
            dataBase.AdicionarParametros("@Telefone", cliente.Telefone);
            dataBase.AdicionarParametros("@Email", cliente.Email);
            dataBase.AdicionarParametros("@NºLogradouro", cliente.NºLogradouro);
            dataBase.AdicionarParametros("@UF", cliente.UF);
            dataBase.AdicionarParametros("@Bairro", cliente.Bairro);


            dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
         
            return Convert.ToInt32(dataBase.ExecutarConsultaScalar(
                CommandType.Text, "SELECT MAX(cod_cliente) FROM Cliente"));
        }
        #endregion

        #region Alterar
       
        public int Alterar(Cliente cliente)
        {
            string queryAlterar =
                "UPDATE cliente SET " +
                "Nome_Sobrenome = @Nome_Sobrenome," +
                "CEP = @CEP," +
                "CPF = @CPF," +
                "Data_nascimento = @Data_nascimento," +
                "cidade = @cidade," +
                "Endereco = @Endereco," +
                "Telefone = @Telefone, " +
                "Email = @Email, " +
                "NºLogradouro = @NºLogradouro," +
                "UF = @UF," +
                "Bairro = @Bairro " +
                "WHERE cod_cliente = @cod_cliente";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@cod_cliente", cliente.cod_cliente);
            dataBase.AdicionarParametros("@Nome_Sobrenome", cliente.Nome_Sobrenome);
            dataBase.AdicionarParametros("@CEP", cliente.CEP);
            dataBase.AdicionarParametros("@CPF", cliente.CPF);
            dataBase.AdicionarParametros("@Data_nascimento", cliente.Data_Nascimento);
            dataBase.AdicionarParametros("@cidade", cliente.cidade);
            dataBase.AdicionarParametros("@Endereco", cliente.Endereco);
            dataBase.AdicionarParametros("@Telefone", cliente.Telefone);
            dataBase.AdicionarParametros("@Email", cliente.Email);
            dataBase.AdicionarParametros("@NºLogradouro", cliente.NºLogradouro);
            dataBase.AdicionarParametros("@UF", cliente.UF);
            dataBase.AdicionarParametros("@Bairro", cliente.Bairro);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }
        #endregion

        #region Apagar
        public int Apagar(int cod_cliente)
        {
            string queryApagar =
                "DELETE FROM Cliente " +
                "WHERE cod_cliente = @cod_cliente";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@cod_cliente", cod_cliente);

            return dataBase.ExecutarManipulacao(
                CommandType.Text, queryApagar);
        }
        #endregion

        #region ConsultarPorNome
        public ClienteCollection ConsultarPorNome(string nome)
        {
            ClienteCollection clienteColecao = new ClienteCollection();
            string query =
                "SELECT * FROM Cliente " +
                "WHERE Nome_Sobrenome LIKE '%' + @Nome_Sobrenome + '%'  ORDER BY Nome_Sobrenome";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Nome_Sobrenome", nome.Trim());

            DataTable dataTable = dataBase.ExecutarConsulta(
                CommandType.Text, query);
          

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Cliente cliente = new Cliente();
                
                cliente.cod_cliente = Convert.ToInt32(dataRow["cod_cliente"]);
                cliente.Nome_Sobrenome = Convert.ToString(dataRow["Nome_Sobrenome"]);
                cliente.CEP = Convert.ToString(dataRow["CEP"]);
                cliente.CPF = Convert.ToString(dataRow["CPF"]);
                cliente.Data_Nascimento = Convert.ToDateTime(dataRow["Data_nascimento"]);
                cliente.cidade = Convert.ToString(dataRow["cidade"]);
                cliente.Endereco = Convert.ToString(dataRow["Endereco"]);
                cliente.Telefone = Convert.ToString(dataRow["Telefone"]);
                cliente.Email = Convert.ToString(dataRow["Email"]);
                cliente.NºLogradouro = Convert.ToString(dataRow["NºLogradouro"]);
                cliente.UF = Convert.ToString(dataRow["UF"]);
                cliente.Bairro = Convert.ToString(dataRow["Bairro"]);


                
                if (!(dataRow["data_nascimento"] is DBNull))
                    cliente.Data_Nascimento =
                        Convert.ToDateTime(dataRow["Data_nascimento"]);
                cliente.Telefone = Convert.ToString(dataRow["Telefone"]);

                
                clienteColecao.Add(cliente);
            }
            return clienteColecao;
        }
        #endregion

        #region ConsultarPorId
        public Cliente ConsultarPorId(int cod_cliente)
        {
            string query =
                "SELECT * FROM Cliente " +
                "WHERE cod_cliente = @cod_cliente";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@cod_cliente", cod_cliente);

            DataTable dataTable = dataBase.ExecutarConsulta(
                CommandType.Text, query);

            if (dataTable.Rows.Count > 0)
            {
                Cliente cliente = new Cliente();
               
                cliente.cod_cliente = Convert.ToInt32(dataTable.Rows[0]["cod_cliente"]);
                cliente.Nome_Sobrenome = Convert.ToString(dataTable.Rows[0]["Nome_Sobrenome"]);
                cliente.CEP = Convert.ToString(dataTable.Rows[0]["CEP"]);
                cliente.CPF = Convert.ToString(dataTable.Rows[0]["CPF"]);
                cliente.Data_Nascimento = Convert.ToDateTime(dataTable.Rows[0]["Data_nascimento"]);
                cliente.cidade = Convert.ToString(dataTable.Rows[0]["cidade"]);
                cliente.Endereco = Convert.ToString(dataTable.Rows[0]["Endereco"]);
                cliente.Telefone = Convert.ToString(dataTable.Rows[0]["Telefone"]);
                cliente.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                cliente.NºLogradouro = Convert.ToString(dataTable.Rows[0]["NºLogradouro"]);
                cliente.UF = Convert.ToString(dataTable.Rows[0]["UF"]);
                cliente.Bairro = Convert.ToString(dataTable.Rows[0]["Bairro"]);


                if (!(dataTable.Rows[0]["data_nascimento"] is DBNull))
                    cliente.Data_Nascimento =Convert.ToDateTime(dataTable.Rows[0]["Data_nascimento"]);
                    cliente.Telefone = Convert.ToString(dataTable.Rows[0]["Telefone"]);

                return cliente;
            }
            else
                return null;
        }
        #endregion

    }
}
