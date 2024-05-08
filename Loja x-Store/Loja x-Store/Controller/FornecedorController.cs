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
    public class FornecedorController
    {


        DatabaseSqlServer dataBase = new DatabaseSqlServer();

        public int Inserir(Fornecedor fornecedor)
        {
            string queryInserir = "INSERT INTO  Fornecedor(CNPJ , Razao_social ,quantidade_produto ,Descricao ,cidade ,UF ,Endereco ,Bairro ,telefone ) " +
                "Values(@CNPJ , @Razao_social ,@quantidade_produto ,@Descricao ,@cidade ,@UF ,@Endereco ,@Bairro ,@telefone );";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@CNPJ", fornecedor.CNPJ);
            dataBase.AdicionarParametros("@Razao_social", fornecedor.Razao_social);
            dataBase.AdicionarParametros("@quantidade_produto", fornecedor.quantidade_produto);
            dataBase.AdicionarParametros("@Descricao", fornecedor.Descricao);
            dataBase.AdicionarParametros("@cidade", fornecedor.cidade);
            dataBase.AdicionarParametros("@UF", fornecedor.UF);
            dataBase.AdicionarParametros("@Endereco", fornecedor.Endereco);
            dataBase.AdicionarParametros("@Bairro", fornecedor.Bairro);
            dataBase.AdicionarParametros("@telefone", fornecedor.telefone);

            dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
            return Convert.ToInt32(dataBase.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_Fornecedor) FROM Fornecedor"));
        }

        public int Alterar(Fornecedor fornecedor)
        {
            string queryInserir = "UPDATE Fornecedor SET CNPJ = @CNPJ, Razao_social = @Razao_social, " +
                "quantidade_produto = @quantidade_produto, Descricao = @Descricao, cidade = @cidade,UF=@UF,Endereco=@Endereco,Bairro=@Bairro,telefone=@telefone WHERE id_Fornecedor = @IdFornecedor";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@idFornecedor", fornecedor.idFornecedor);
            dataBase.AdicionarParametros("@CNPJ", fornecedor.CNPJ);
            dataBase.AdicionarParametros("@Razao_social", fornecedor.Razao_social);
            dataBase.AdicionarParametros("@quantidade_produto", fornecedor.quantidade_produto);
            dataBase.AdicionarParametros("@Descricao", fornecedor.Descricao);
            dataBase.AdicionarParametros("@cidade", fornecedor.cidade);
            dataBase.AdicionarParametros("@UF", fornecedor.UF);
            dataBase.AdicionarParametros("@Endereco", fornecedor.Endereco);
            dataBase.AdicionarParametros("@Bairro", fornecedor.Bairro);
            dataBase.AdicionarParametros("@telefone", fornecedor.telefone);



            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }


        public int ApagarFornecedor(int id_fronecedor)
        {
            string queryInserir = "DELETE FROM Fornecedor WHERE id_Fornecedor = @idFornecedor";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@idFornecedor", id_fronecedor);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public FornecedorCollection ConsultarTodos()
        {
            FornecedorCollection fornecedorColecao = new FornecedorCollection();
            string queryConsulta = "SELECT * FROM Fornecedor ORDER BY Descricao";

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.idFornecedor = Convert.ToInt32(dataRow["id_produto"]);
                fornecedor.CNPJ = Convert.ToString(dataRow["CNPJ"]);
                fornecedor.Razao_social = Convert.ToString(dataRow["Razao_social"]);
                fornecedor.quantidade_produto = Convert.ToInt32(dataRow["quantidade_produto"]);
                fornecedor.Descricao = Convert.ToString(dataRow["Descricao"]);
                fornecedor.cidade = Convert.ToString(dataRow["cidade"]);
                fornecedor.UF = Convert.ToString(dataRow["UF"]);
                fornecedor.Endereco = Convert.ToString(dataRow["Endereco"]);
                fornecedor.Bairro = Convert.ToString(dataRow["Bairro"]);
                fornecedor.telefone = Convert.ToString(dataRow["telefone"]);

                fornecedorColecao.Add(fornecedor);
            }
            return fornecedorColecao;
        }

        public Fornecedor ConsultarPorId(int id_produto)
        {
            string queryConsulta = "SELECT * FROM Fornecedor WHERE id_Fornecedor = @id_Fornecedor";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_Fornecedor", id_produto);

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.idFornecedor = Convert.ToInt32(dataTable.Rows[0]["id_Fornecedor"]);
            fornecedor.CNPJ = Convert.ToString(dataTable.Rows[0]["CNPJ"]);
            fornecedor.Razao_social = Convert.ToString(dataTable.Rows[0]["Razao_social"]);
            fornecedor.quantidade_produto = Convert.ToInt32(dataTable.Rows[0]["quantidade_produto"]);
            fornecedor.Descricao = Convert.ToString(dataTable.Rows[0]["Descricao"]);
            fornecedor.cidade = Convert.ToString(dataTable.Rows[0]["cidade"]);
            fornecedor.UF = Convert.ToString(dataTable.Rows[0]["UF"]);
            fornecedor.Endereco = Convert.ToString(dataTable.Rows[0]["Endereco"]);
            fornecedor.Bairro = Convert.ToString(dataTable.Rows[0]["Bairro"]);
            fornecedor.telefone = Convert.ToString(dataTable.Rows[0]["telefone"]);
            return fornecedor;
        }

        public FornecedorCollection ConsultarPorDescricao(string Descricao)
        {
            FornecedorCollection fornecedorColecao= new FornecedorCollection();
            string queryConsulta = "SELECT * FROM Fornecedor WHERE Descricao LIKE '%' + @Descricao + '%' ORDER BY Descricao";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Descricao",Descricao );

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.idFornecedor = Convert.ToInt32(dataRow["id_Fornecedor"]);
                fornecedor.CNPJ = Convert.ToString(dataRow["CNPJ"]);
                fornecedor.Razao_social = Convert.ToString(dataRow["Razao_social"]);
                fornecedor.quantidade_produto = Convert.ToInt32(dataRow["quantidade_produto"]);
                fornecedor.Descricao = Convert.ToString(dataRow["Descricao"]);
                fornecedor.cidade = Convert.ToString(dataRow["cidade"]);
                fornecedor.UF = Convert.ToString(dataRow["UF"]);
                fornecedor.Endereco = Convert.ToString(dataRow["Endereco"]);
                fornecedor.Bairro = Convert.ToString(dataRow["Bairro"]);
                fornecedor.telefone = Convert.ToString(dataRow["telefone"]);

                fornecedorColecao.Add(fornecedor);
            }
            return fornecedorColecao;
        }


    }
}
