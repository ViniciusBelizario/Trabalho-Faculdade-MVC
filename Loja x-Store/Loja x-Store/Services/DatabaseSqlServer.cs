using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Loja_x_Store.Services
{
    public class DatabaseSqlServer
    {
        private SqlConnection CriarConexao()
        {
            SqlConnection conexao = new SqlConnection();

            conexao.ConnectionString =

                //Se esse primeiro falhar
                //tento o segundo
                /*
                "Data Source=127.0.0.1;" +
                "Initial Catalog=pooCamadas;" +
                "Integrated Security=SSPI;";*/

                "Data Source=DESKTOP-JM1DITN\\SQLEXPRESS;" +
                "Initial Catalog=x_Store;" +
                "Integrated Security=SSPI;" +
                "User Instance = false;";

            conexao.Open();
            return conexao;
        }

        private SqlParameterCollection sqlParameterCollection =new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro,object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro,valorParametro));
        }


        public int ExecutarManipulacao(CommandType commandType,string nomeStoredProcedureOuTextpSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextpSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName,sqlParameter.Value));
                }

              
                return sqlCommand.ExecuteNonQuery();
            }
          
            catch (Exception ex)
            {
             
                throw new Exception("Houve uma falha ao execuar o " +
                    "comando no banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }

        public DataTable ExecutarConsulta(
            CommandType commandType,string nomeStoredProcedureOuTextpSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextpSql;

                foreach (SqlParameter sqlParameter
                    in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName,sqlParameter.Value));
                }

             
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

              
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Houve uma falha ao execuar o " +
                    "comando no banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }

        public object ExecutarConsultaScalar(CommandType commandType,string nomeStoredProcedureOuTextpSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextpSql;

                foreach (SqlParameter sqlParameter
                    in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName,sqlParameter.Value));
                }

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //Retorno o erro a onde o Método foi chamado
                throw new Exception("Houve uma falha ao execuar o " +
                    "comando no banco de dados.\r\n" +
                    "Mensagem original: " + ex.Message);
            }
        }


    }
}
