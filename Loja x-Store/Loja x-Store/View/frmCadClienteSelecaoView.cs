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
    public partial class frmCadClienteSelecaoView : Form
    {

        public Cliente clienteSelecao;

        public frmCadClienteSelecaoView(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dvgRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }

        private void Selecionar()
        {
            clienteSelecao = RecuperarCliente();
            if (clienteSelecao != null)
                this.DialogResult = DialogResult.OK;
        }

        private void Pesquisar()
        {
            int id = 0;

            ClienteController clienteController = new ClienteController();
            ClienteCollection clientesCollection = new ClienteCollection();
            dvgRegistros.DataSource = null;

            if (int.TryParse(txtPesquisa.Text, out id))
            {
                Cliente cliente = clienteController.ConsultarPorId(id);
                if (cliente != null)
                    clientesCollection.Add(cliente);
            }
            else
                clientesCollection = clienteController.ConsultarPorNome(txtPesquisa.Text.Trim());


            dvgRegistros.DataSource = clientesCollection;
            dvgRegistros.Update();
            dvgRegistros.Refresh();
        }


        private void Excluir()
        {
            Cliente clienteSelecionado = RecuperarCliente();

            if (clienteSelecionado != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o registro?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    ClienteController clienteController = new ClienteController();

                    if (clienteController.Apagar(clienteSelecionado.cod_cliente) > 0)
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


        private Cliente RecuperarCliente()
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
                as Cliente;
            }
        }

        private void ChamarTelaCadastro(
           AcaoNaTela acaoTela, Cliente cliente)
        {
            frmCadCliente frm =new frmCadCliente(acaoTela, cliente);
            frm.ShowDialog();

          

             if (acaoTela != AcaoNaTela.Visualizar) { 
             Pesquisar();
             }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Inserir,null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Alterar, RecuperarCliente());
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
            ChamarTelaCadastro(AcaoNaTela.Visualizar, RecuperarCliente());
        }

        private void frmCadClienteSelecaoView_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
