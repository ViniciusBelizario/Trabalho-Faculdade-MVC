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
    public partial class frmCadFornecedor : Form
    {
        AcaoNaTela acaoSelecionada;
        Fornecedor FornecedorSelecionado;
        public frmCadFornecedor(AcaoNaTela acaoTela, Fornecedor fornecedor)
        {
            
            InitializeComponent();
            acaoSelecionada = acaoTela;
            FornecedorSelecionado = fornecedor;
            if (acaoSelecionada == AcaoNaTela.Inserir)
                this.Text = "Cadastrar Fornecedor";
            else
            {
                CarregarDados();

                if (acaoSelecionada == AcaoNaTela.Alterar)
                    this.Text = "Alterar Fornecedor";
                else
                {
                    this.Text = "Visualizar Fornecedor";
                    DesabilitarCampos();
                }
            }
        }
        private void CarregarDados()
        {
            txtCodigoFornecedor.Text = FornecedorSelecionado.idFornecedor.ToString();
            txtRazaoSocial.Text = FornecedorSelecionado.Razao_social;
            mskCNPJ.Text = FornecedorSelecionado.CNPJ;
            txtDescricao.Text = FornecedorSelecionado.Descricao;
            nudQtProduto.Value = FornecedorSelecionado.quantidade_produto;
            txtEndereco.Text = FornecedorSelecionado.Endereco;
            txtBairro.Text = FornecedorSelecionado.Bairro;
            txtCidade.Text = FornecedorSelecionado.cidade;
            cbbUF.Text = FornecedorSelecionado.UF;
            mskTelefone.Text = FornecedorSelecionado.telefone;
          

        }

        private void DesabilitarCampos()
        {

            txtRazaoSocial.ReadOnly = true;
            mskCNPJ.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            mskCNPJ.ReadOnly = true;
            txtBairro.ReadOnly = true;
            cbbUF.Enabled = false;
            nudQtProduto.ReadOnly = true;
            mskTelefone.ReadOnly = true;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;

        }

        #region Não permitir números
        public void NaoPermitirNumeros(TextBox txt,  KeyPressEventArgs e)
        {

           string texto = "Insira apenas Letras";
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(txt, texto);

            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region Não permitir Letras
        public void NaoPermitirLetras(TextBox txt, KeyPressEventArgs e)
        {

            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(txt, "Insira apenas números");

            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region Não permitir Letras Masked
        public void NaoPermitirLetrasMasked(MaskedTextBox msk, KeyPressEventArgs e)
        {

         

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(msk, "Insira apenas números");

            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region Validar campo vazio
        public void ValidarCampo(TextBox txt, CancelEventArgs e, string texto)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txt, texto);
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txt, "");

            }
        }
        #endregion

        #region Validar campo de numeros
        public void ValidarCampoNumero(TextBox txt, CancelEventArgs e, int numeroCaracter, string texto1, string texto2)
        {

            string texto = "";
            foreach (char t in txt.Text)
            {
                if (char.IsNumber(t))
                {
                    texto += t;
                }
                if (string.IsNullOrEmpty(texto))
                {
                    e.Cancel = true;
                    errProvider.SetError(txt, texto1);
                }

                else if (texto.Length != numeroCaracter)
                {
                    e.Cancel = true;
                    errProvider.SetError(txt, texto2);
                }
                else
                {
                    e.Cancel = false;
                    errProvider.SetError(txt, "");
                }

            }

        }
        #endregion

        #region Validar campo de numeros Masked
        public void ValidarCampoNumeroMasked(MaskedTextBox msk, CancelEventArgs e, int numeroCaracter, string texto1, string texto2)
        {

            string texto = "";
            foreach (char t in msk.Text)
            {
                if (char.IsNumber(t))
                {
                    texto += t;
                }
                if (string.IsNullOrEmpty(texto))
                {
                    e.Cancel = true;
                    errProvider.SetError(msk, texto1);
                }

                else if (texto.Length != numeroCaracter)
                {
                    e.Cancel = true;
                    errProvider.SetError(msk, texto2);
                }
                else
                {
                    e.Cancel = false;
                    errProvider.SetError(msk, "");
                }

            }

        }
        #endregion

        #region Validar campo de texto
        public void ValidarCampoTexto(TextBox txt, int numeroCaracter, string texto1, string texto2, CancelEventArgs e)
        {

            string texto = "";
            foreach (char t in txt.Text)
            {
                if (char.IsLetter(t))
                {
                    texto += t;
                }
                if (string.IsNullOrEmpty(texto))
                {
                    e.Cancel = true;
                    errProvider.SetError(txt, texto1);
                }

                else if (texto.Length != numeroCaracter)
                {
                    e.Cancel = true;
                    errProvider.SetError(txt, texto2);
                }
                else
                {
                    e.Cancel = false;
                    errProvider.SetError(txt, "");
                }

            }

        }
        #endregion

        #region Não deixar valor 0
        public void NaoDeixarZero(NumericUpDown nud, CancelEventArgs e) {
            if (nud.Value <= 0)
            {
                e.Cancel = true;
                errProvider.SetError(nud, "O valor deve ser maior que 0");

            }
            else {
                e.Cancel = false;
                errProvider.SetError(nud, "");

            }
        }
        #endregion

        #region Validação do campo UF
        public void ValidarUF(CancelEventArgs e,ComboBox cbb)
        {
            
            if (string.IsNullOrEmpty(cbb.Text))
            {
                e.Cancel = true;
                errProvider.SetError(cbb, "Preencha o campo UF, o campo está vazio.");
            }
            else
            {
                switch (cbb.SelectedIndex)
                {
                    case 0:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 1:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 2:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 3:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 4:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 5:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 6:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 7:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 8:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 9:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 10:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 11:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 12:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 13:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 14:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 15:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 16:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 17:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 18:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 19:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 20:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 21:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 22:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 23:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 24:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    case 25:
                        e.Cancel = false;
                        errProvider.SetError(cbb, "");
                        break;
                    default:
                        errProvider.SetError(cbb, "Valor inválido");
                        break;
                }

            }
        }
        #endregion

        Form1 form = new Form1();

        private void Salvar()
        {
            if (!string.IsNullOrEmpty(txtDescricao.Text))
            {
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.CNPJ = mskCNPJ.Text;
                fornecedor.CNPJ = fornecedor.CNPJ.Replace(",", "");
                fornecedor.CNPJ = fornecedor.CNPJ.Replace("/", "");
                fornecedor.CNPJ = fornecedor.CNPJ.Replace("-", "");
                fornecedor.Razao_social = txtRazaoSocial.Text;
                fornecedor.quantidade_produto = Convert.ToInt32(nudQtProduto.Value);
                fornecedor.Descricao = txtDescricao.Text;
                fornecedor.cidade = txtCidade.Text;
                fornecedor.UF = cbbUF.Text;
                fornecedor.Endereco = txtEndereco.Text;
                fornecedor.Bairro = txtBairro.Text;
                fornecedor.telefone = mskTelefone.Text;






                FornecedorController fornecedorController = new FornecedorController();
                int retonoSql = 0;

                if (acaoSelecionada == AcaoNaTela.Inserir)
                    retonoSql = fornecedorController.Inserir(fornecedor);
                else
                {
                    fornecedor.idFornecedor = int.Parse(txtCodigoFornecedor.Text);
                    retonoSql = fornecedorController.Alterar(fornecedor);
                }

                if (retonoSql > 0)
                {
                    if (acaoSelecionada == AcaoNaTela.Inserir)
                        txtCodigoFornecedor.Text = retonoSql.ToString();

                    MessageBox.Show("Registro salvo com sucesso!", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Falha ao salvar registro", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Preencha os campos corretamente", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Salvar();
                Close();
            }
            else
            {
                MessageBox.Show("É necessário o preenchimento de " +
                                "todos os campos obrigatórios.",
                                "Atenção", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente descartar as alterações?",
                             "Confirmação",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }


        private void txtDescricao_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtDescricao, e, "O campo Descrição Descrição está vazio");
        }

        private void txtRazaoSocial_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtRazaoSocial, e, "O campo Razão social está vazio");
        }

        private void mskCNPJ_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoNumeroMasked(mskCNPJ, e, 14, "O campo CNPJ está vazio", "O campo CNPJ deve ter 14 números");
        }

        private void txtCidade_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtCidade, e, "O campo Cidade está vazio");
        }

        private void cbbUF_Validating(object sender, CancelEventArgs e)
        {
            ValidarUF(e,cbbUF);
        }
        

        private void txtEndereco_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtEndereco, e, "O campo Endereço está vazio");
        }

        private void txtBairro_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtBairro,e,"O campo Bairro está vazio");
        }

        private void mskTelefone_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoNumeroMasked(mskTelefone, e, 11, "O campo Telefone está vazio", "O campo Telefone deve ter 11 números contando o DDD");
        }

        private void mskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirLetrasMasked(mskCNPJ, e);   
        }

        private void nudQtProduto_Validating(object sender, CancelEventArgs e)
        {
            NaoDeixarZero(nudQtProduto, e);
        }

        private void txtRazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtRazaoSocial, e);
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtDescricao, e);
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtBairro, e);
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtCidade, e);
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtEndereco, e);
        }

        
    }

}
