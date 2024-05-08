using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja_x_Store.Models;
using Loja_x_Store.Services;
using System.Data;
using System.Data.SqlClient;

namespace Loja_x_Store.Controller
{
    public class FuncionarioController
    {
        DatabaseSqlServer dataBase = new DatabaseSqlServer();

        public int Inserir(Funcionario funcionario)
        {
            string queryInserir = "INSERT INTO Funcionario(Nome , CPF ,Data_nascimento ,Telefone,Cidade ,Endereco ,Bairro ,UF )" +
                "VALUES(@Nome , @CPF ,@Data_nascimento ,@Telefone,@Cidade ,@Endereco ,@Bairro ,@UF )";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Nome", funcionario.Nome);
            dataBase.AdicionarParametros("@CPF", funcionario.CPF);
            dataBase.AdicionarParametros("@Data_nascimento", funcionario.Data_Nascimento);
            dataBase.AdicionarParametros("@Telefone", funcionario.Telefone);
            dataBase.AdicionarParametros("@Cidade", funcionario.Cidade);
            dataBase.AdicionarParametros("@Endereco", funcionario.Endereco);
            dataBase.AdicionarParametros("@Bairro", funcionario.Bairro);
            dataBase.AdicionarParametros("@UF", funcionario.UF);

            dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
            return Convert.ToInt32(dataBase.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_Funcionario) FROM Funcionario"));
        }

        public int Alterar(Funcionario funcionario)
        {
            string queryInserir = "UPDATE Funcionario SET Nome = @Nome, CPF = @CPF, " +
                "Data_nascimento = @Data_nascimento, Telefone = @Telefone, Cidade = @Cidade,Endereco=@Endereco,Bairro=@Bairro,UF=@UF WHERE id_Funcionario = @id_Funcionario";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_Funcionario", funcionario.id_Funcionario);
            dataBase.AdicionarParametros("@Nome", funcionario.Nome);
            dataBase.AdicionarParametros("@CPF", funcionario.CPF);
            dataBase.AdicionarParametros("@Data_nascimento", funcionario.Data_Nascimento);
            dataBase.AdicionarParametros("@Telefone", funcionario.Telefone);
            dataBase.AdicionarParametros("@Cidade", funcionario.Cidade);
            dataBase.AdicionarParametros("@Endereco", funcionario.Endereco);
            dataBase.AdicionarParametros("@Bairro", funcionario.Bairro);
            dataBase.AdicionarParametros("@UF", funcionario.UF);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }


        public int ApagarFuncionario(int id_Funcionario)
        {
            string queryInserir = "DELETE FROM Funcionario WHERE id_Funcionario = @id_Funcionario";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_Funcionario", id_Funcionario);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public FuncionarioCollection ConsultarTodos()
        {
            FuncionarioCollection funcionarioColecao = new FuncionarioCollection();
            string queryConsulta = "SELECT * FROM id_Funcionario ORDER BY Cidade";

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.id_Funcionario = Convert.ToInt32(dataRow["id_Funcionario"]);
                funcionario.Nome = Convert.ToString(dataRow["Nome"]);
                funcionario.CPF = Convert.ToString(dataRow["CPF"]);
                funcionario.Data_Nascimento = Convert.ToDateTime(dataRow["Data_nascimento"]);
                funcionario.Telefone = Convert.ToString(dataRow["Telefone"]);
                funcionario.Cidade = Convert.ToString(dataRow["Cidade"]);
                funcionario.Endereco = Convert.ToString(dataRow["Endereco"]);
                funcionario.Bairro = Convert.ToString(dataRow["Bairro"]);
                funcionario.UF = Convert.ToString(dataRow["UF"]);

                funcionarioColecao.Add(funcionario);
            }
            return funcionarioColecao;
        }

        public Funcionario ConsultarPorId(int id_produto)
        {
            string queryConsulta = "SELECT * FROM Funcionario WHERE id_Funcionario = @id_Funcionario";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_produto", id_produto);

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            Funcionario funcionario = new Funcionario();
            funcionario.id_Funcionario = Convert.ToInt32(dataTable.Rows[0]["id_Funcionario"]);
            funcionario.Nome = Convert.ToString(dataTable.Rows[0]["Nome"]);
            funcionario.CPF = Convert.ToString(dataTable.Rows[0]["CPF"]);
            funcionario.Data_Nascimento = Convert.ToDateTime(dataTable.Rows[0]["Data_nascimento"]);
            funcionario.Telefone = Convert.ToString(dataTable.Rows[0]["Telefone"]);
            funcionario.Cidade = Convert.ToString(dataTable.Rows[0]["Cidade"]);
            funcionario.Endereco = Convert.ToString(dataTable.Rows[0]["Endereco"]);
            funcionario.Bairro = Convert.ToString(dataTable.Rows[0]["Bairro"]);
            funcionario.UF = Convert.ToString(dataTable.Rows[0]["UF"]);
            return funcionario;
        }

        public FuncionarioCollection ConsultarPorCidade(string Cidade)
        {
            FuncionarioCollection funcionarioColecao = new FuncionarioCollection();
            string queryConsulta = "SELECT * FROM Funcionario WHERE Cidade LIKE '%' + @Cidade + '%' ORDER BY Cidade";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Cidade", Cidade);

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.id_Funcionario = Convert.ToInt32(dataRow["id_Funcionario"]);
                funcionario.Nome = Convert.ToString(dataRow["Nome"]);
                funcionario.CPF = Convert.ToString(dataRow["CPF"]);
                funcionario.Data_Nascimento = Convert.ToDateTime(dataRow["Data_nascimento"]);
                funcionario.Telefone = Convert.ToString(dataRow["Telefone"]);
                funcionario.Cidade = Convert.ToString(dataRow["Cidade"]);
                funcionario.Endereco = Convert.ToString(dataRow["Endereco"]);
                funcionario.Bairro = Convert.ToString(dataRow["Bairro"]);
                funcionario.UF = Convert.ToString(dataRow["UF"]);

                funcionarioColecao.Add(funcionario);
            }
            return funcionarioColecao;
        }

    }
}
