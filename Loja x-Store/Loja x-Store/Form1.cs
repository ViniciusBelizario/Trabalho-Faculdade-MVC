using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja_x_Store.View;
using Loja_x_Store.Models;
//using Loja_x_Store.Controllers;
using Loja_x_Store.Services;

namespace Loja_x_Store
{
    public partial class Form1 : Form
    {

        
       



        public Form1()
        {
            InitializeComponent();
        }



        

        #region Chamar Tela cadastro de produtos


        private void ChamarTelaCadastroProdutos() {
            frmCadProdutoSelecaoView frm = new frmCadProdutoSelecaoView();
            frm.ShowDialog();

        }

        #endregion

        #region Chamar Tela cadastro de funcionarios
        private void ChamarTelaCadastroFuncionarios()
        {
            frmCadFuncionarioSelecaoView frm = new frmCadFuncionarioSelecaoView();
            frm.ShowDialog(); 
          

        }
        #endregion

        #region Chamar Tela cadastro de fornecedores

        private void ChamarTelaCadastroFornecedores()
        {
            frmCadFornecedorSelecaoView frm = new frmCadFornecedorSelecaoView();
            frm.ShowDialog();

        }
        #endregion

        #region Chamar Tela cadastro de clientes
        private void ChamarTelaCadastroCliente()
        {
            frmCadClienteSelecaoView   frm = new frmCadClienteSelecaoView();
            frm.ShowDialog();

        }
        #endregion

        #region validacao fechamento do formulario
        public void FechamentoFormulario( FormClosingEventArgs e) {
            if (MessageBox.Show("Deseja realmente sair ?",
              "Atenção",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button2
              ) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion



        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroProdutos();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroFornecedores();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroFuncionarios();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroCliente();
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroFuncionarios();
        }

        private void fmrCadCliente_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroCliente();
        }

        private void fmrCadFornecedor_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroFornecedores();
        }

        private void fmrCadProduto_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastroProdutos();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FechamentoFormulario(e);
        }
    }
}
