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
    public class ProdutoController
    {
        DatabaseSqlServer dataBase = new DatabaseSqlServer();

        public int Inserir(Produto produto)
        {
            string queryInserir = "INSERT INTO  Produto(Nome,Marca,Codigo_barras,Preco,categoria,Quantidade_estoque,DtRegistro) " +
                "Values(@Nome,@Marca,@Codigo_barras,@Preco,@Categoria,@Quantidade_estoque,@DtRegistro);";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Nome", produto.Nome);
            dataBase.AdicionarParametros("@Marca", produto.Marca);
            dataBase.AdicionarParametros("@Codigo_barras", produto.Codigo_barras);
            dataBase.AdicionarParametros("@Preco", produto.Preco);
            dataBase.AdicionarParametros("@categoria", produto.Categoria);
            dataBase.AdicionarParametros("@Quantidade_estoque", produto.Quantidade_estoque);
            dataBase.AdicionarParametros("@DtRegistro", produto.DtRegistro);

            dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
            return Convert.ToInt32(dataBase.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_produto) FROM Produto"));
        }

        public int Alterar(Produto produto)
        {
            string queryInserir = "UPDATE Produto SET Nome = @Nome, Marca = @Marca, " +
                "Codigo_barras = @Codigo_barras, Preco = @Preco, categoria = @Categoria,Quantidade_estoque=@Quantidade_estoque,DtRegistro=@DtRegistro WHERE id_produto = @id_produto";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_produto", produto.id_produto);
            dataBase.AdicionarParametros("@Nome", produto.Nome);
            dataBase.AdicionarParametros("@Marca", produto.Marca);
            dataBase.AdicionarParametros("@Codigo_barras", produto.Codigo_barras);
            dataBase.AdicionarParametros("@Preco", produto.Preco);
            dataBase.AdicionarParametros("@Categoria", produto.Categoria);
            dataBase.AdicionarParametros("@Quantidade_estoque", produto.Quantidade_estoque);
            dataBase.AdicionarParametros("@DtRegistro", produto.DtRegistro);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }


        public int ApagarProduto(int id_produto)
        {
            string queryInserir = "DELETE FROM produto WHERE id_produto = @id_produto";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_produto", id_produto);

            return dataBase.ExecutarManipulacao(CommandType.Text, queryInserir);
        }

        public ProdutoCollection ConsultarTodos()
        {
            ProdutoCollection produtoColecao = new ProdutoCollection();
            string queryConsulta = "SELECT * FROM produto ORDER BY categoria";

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.id_produto = Convert.ToInt32(dataRow["id_produto"]);
                produto.Nome = Convert.ToString(dataRow["Nome"]);
                produto.Marca = Convert.ToString(dataRow["Marca"]);
                produto.Codigo_barras = Convert.ToString(dataRow["Codigo_barras"]);
                produto.Preco = Convert.ToDecimal(dataRow["Preco"]);
                produto.Categoria = Convert.ToString(dataRow["categoria"]);
                produto.Quantidade_estoque = Convert.ToInt32(dataRow["Quantidade_estoque"]);
                produto.DtRegistro = Convert.ToDateTime(dataRow["DtRegistro"]);

                produtoColecao.Add(produto);
            }
            return produtoColecao;
        }

        public Produto ConsultarPorId(int id_produto)
        {
            string queryConsulta = "SELECT * FROM Produto WHERE id_produto = @id_produto";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@id_produto", id_produto);

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            Produto produto = new Produto();
            produto.id_produto = Convert.ToInt32(dataTable.Rows[0]["id_produto"]);
            produto.Nome = Convert.ToString(dataTable.Rows[0]["Nome"]);
            produto.Marca = Convert.ToString(dataTable.Rows[0]["Marca"]);
            produto.Codigo_barras = Convert.ToString(dataTable.Rows[0]["Codigo_barras"]);
            produto.Preco = Convert.ToDecimal(dataTable.Rows[0]["Preco"]);
            produto.Categoria = Convert.ToString(dataTable.Rows[0]["categoria"]);
            produto.Quantidade_estoque = Convert.ToInt32(dataTable.Rows[0]["Quantidade_estoque"]);
            produto.DtRegistro = Convert.ToDateTime(dataTable.Rows[0]["DtRegistro"]);
            return produto;
        }

        public ProdutoCollection ConsultarPorCategoria(string Categoria)
        {
            ProdutoCollection produtoColecao = new ProdutoCollection();
            string queryConsulta = "SELECT * FROM Produto WHERE categoria LIKE '%' + @categoria + '%' ORDER BY categoria";

            dataBase.LimparParametros();
            dataBase.AdicionarParametros("@Categoria", Categoria);

            DataTable dataTable = dataBase.ExecutarConsulta(CommandType.Text, queryConsulta);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.id_produto = Convert.ToInt32(dataRow["id_produto"]);
                produto.Nome = Convert.ToString(dataRow["Nome"]);
                produto.Marca = Convert.ToString(dataRow["Marca"]);
                produto.Codigo_barras = Convert.ToString(dataRow["Codigo_barras"]);
                produto.Preco = Convert.ToDecimal(dataRow["Preco"]);
                produto.Categoria = Convert.ToString(dataRow["categoria"]);
                produto.Quantidade_estoque = Convert.ToInt32(dataRow["Quantidade_estoque"]);
                produto.DtRegistro = Convert.ToDateTime(dataRow["DtRegistro"]);

                produtoColecao.Add(produto);
            }
            return produtoColecao;
        }


    }
}
