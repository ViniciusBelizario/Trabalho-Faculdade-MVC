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
    public partial class frmCadFuncionarioSelecaoView : Form
    {

        public Funcionario funcionarioSelecao;
        public frmCadFuncionarioSelecaoView(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            dvgRegistros.AutoGenerateColumns = false;
            btnSelecionar.Visible = ExibirBotaoSelecionar;

        }


        private void Selecionar()
        {
            funcionarioSelecao = RecuperarFuncionario();
            if (funcionarioSelecao != null)
                this.DialogResult = DialogResult.OK;
        }

        private void Pesquisar()
        {
            int id = 0;

            FuncionarioController funcionarioController = new FuncionarioController();
            FuncionarioCollection funcionarioCollection = new FuncionarioCollection();
            dvgRegistros.DataSource = null;

            if (int.TryParse(txtPesquisa.Text, out id))
            {
                Funcionario funcionario = funcionarioController.ConsultarPorId(id);
                if (funcionario != null)
                    funcionarioCollection.Add(funcionario);
            }
            else
                funcionarioCollection = funcionarioController.ConsultarPorCidade(txtPesquisa.Text.Trim());


            dvgRegistros.DataSource = funcionarioCollection;
            dvgRegistros.Update();
            dvgRegistros.Refresh();
        }


        private void ChamarTelaCadastro(AcaoNaTela acaoTela, Funcionario funcionario)
        {
            frmCadFuncionario frm = new frmCadFuncionario(acaoTela, funcionario);
            frm.ShowDialog();



            if (acaoTela != AcaoNaTela.Visualizar)
            {
                Pesquisar();
            }

        }

        private void Excluir()
        {
            Funcionario funcionarioSelecionado = RecuperarFuncionario();

            if (funcionarioSelecionado != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o registro?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    FuncionarioController funcionarioController = new FuncionarioController();

                    if (funcionarioController.ApagarFuncionario(funcionarioSelecionado.id_Funcionario) > 0)
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

        private Funcionario RecuperarFuncionario()
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
                as Funcionario;
            }
        }
    

       

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Inserir, null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ChamarTelaCadastro(AcaoNaTela.Alterar, RecuperarFuncionario());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
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
            ChamarTelaCadastro(AcaoNaTela.Visualizar, RecuperarFuncionario());
        }

        private void frmCadFuncionarioSelecaoView_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
