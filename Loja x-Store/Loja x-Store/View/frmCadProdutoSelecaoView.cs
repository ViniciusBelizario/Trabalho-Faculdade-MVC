using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja_x_Store.Models;
//using Loja_x_Store.Controllers;
using Loja_x_Store.Services;
using Loja_x_Store.Controller;

namespace Loja_x_Store.View
{
    public partial class frmCadProdutoSelecaoView : Form
    {

        public Produto produtoSelecao;
        public frmCadProdutoSelecaoView(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dvgRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }

        private void Selecionar()
        {
            produtoSelecao = RecuperarProduto();
            if (produtoSelecao != null)
                this.DialogResult = DialogResult.OK;
        }


        private Produto RecuperarProduto()
        {
            if (dvgRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.",
                    "Informação", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }
            else
            {
                
                return dvgRegistros.SelectedRows[0].DataBoundItem
                as Produto;
            }
        }
        private void Pesquisar()
        {
            int id = 0;

            ProdutoController produtoController = new ProdutoController();
            ProdutoCollection produtoCollection = new ProdutoCollection();
            dvgRegistros.DataSource = null;

            if (int.TryParse(txtPesquisa.Text, out id))
            {
                Produto produto = produtoController.ConsultarPorId(id);
                if (produto != null)
                    produtoCollection.Add(produto);
            }
            else
                produtoCollection = produtoController.ConsultarPorCategoria(txtPesquisa.Text.Trim());
               

            dvgRegistros.DataSource = produtoCollection;
            dvgRegistros.Update();
            dvgRegistros.Refresh();
        }


        private void ChamarTelaCadastro(
           AcaoNaTela acaoTela, Produto produto)
        {
            frmCadProduto frm = new frmCadProduto(acaoTela, produto);
                frm.ShowDialog();

            

             if (acaoTela != AcaoNaTela.Visualizar) { 
                  Pesquisar();
             }

        }

        private void Excluir()
        {
            Produto produtoSelecionado = RecuperarProduto();

            if (produtoSelecionado != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o registro?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    
                    ProdutoController produtoController = new ProdutoController();

                    if (produtoController.ApagarProduto(produtoSelecionado.id_produto) > 0)
                    {
                        MessageBox.Show("Registro excluído com sucesso.", "Informação",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Pesquisar();
                    }
                    else
                        MessageBox.Show("Não foi possível excluir o regsitro.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Inserir, null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Alterar, RecuperarProduto());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Visualizar, RecuperarProduto());
        }

        private void frmCadProdutoSelecaoView_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void dvgRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
