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
    public partial class frmCadFornecedorSelecaoView : Form
    {

        public Fornecedor fornecedorSelecao;
        public frmCadFornecedorSelecaoView(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dvgRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }


        private void Selecionar()
        {
            fornecedorSelecao = RecuperarFornecedor();
            if (fornecedorSelecao != null)
                this.DialogResult = DialogResult.OK;
        }

        private void Pesquisar()
        {
            int id = 0;

            FornecedorController fornecedorController = new FornecedorController();
            FornecedorCollection fornecedorCollection = new FornecedorCollection();
            dvgRegistros.DataSource = null;

            if (int.TryParse(txtPesquisa.Text, out id))
            {
                Fornecedor fornecedor = fornecedorController.ConsultarPorId(id);
                if (fornecedor != null)
                    fornecedorCollection.Add(fornecedor);
            }
            else
                fornecedorCollection = fornecedorController.ConsultarPorDescricao(txtPesquisa.Text.Trim());


            dvgRegistros.DataSource = fornecedorCollection;
            dvgRegistros.Update();
            dvgRegistros.Refresh();
        }


        private void Excluir()
        {
            Fornecedor fornecedorSelecionado = RecuperarFornecedor();

            if (fornecedorSelecionado != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o registro?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    FornecedorController produtoController = new FornecedorController();

                    if (produtoController.ApagarFornecedor(fornecedorSelecionado.idFornecedor) > 0)
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


        private Fornecedor RecuperarFornecedor()
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
                //Este método recupera o objeto da linha 
                //selecionada na Grade
                return dvgRegistros.SelectedRows[0].DataBoundItem
                as Fornecedor;
            }
        }

        private void ChamarTelaCadastro(
           AcaoNaTela acaoTela, Fornecedor fornecedor)
        {
            frmCadFornecedor frm =
                new frmCadFornecedor(acaoTela, fornecedor);
            frm.ShowDialog();

         

             if (acaoTela != AcaoNaTela.Visualizar) { 
                    Pesquisar();
             }

        }

       

        

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Visualizar, RecuperarFornecedor());
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Inserir, null);
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Alterar, RecuperarFornecedor());
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Excluir();
        }

        private void frmCadFornecedorSelecaoView_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }



}
