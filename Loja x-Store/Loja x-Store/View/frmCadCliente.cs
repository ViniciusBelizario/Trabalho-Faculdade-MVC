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
using Loja_x_Store.Controller;

namespace Loja_x_Store.View
{
    public partial class frmCadCliente : Form
    {

        AcaoNaTela acaoSelecionada;
        Cliente clienteSelecionado;
        public frmCadCliente(AcaoNaTela acaoTela, Cliente cliente)
        {
            InitializeComponent();
            acaoSelecionada = acaoTela;
            clienteSelecionado = cliente;
            if (acaoSelecionada == AcaoNaTela.Inserir)
                this.Text = "Cadastrar Cliente";
            else
            {
                CarregarDados();

                if (acaoSelecionada == AcaoNaTela.Alterar)
                    this.Text = "Alterar Cliente";
                else
                {
                    this.Text = "Visualizar Cliente";
                    DesabilitarCampos();
                }
            }
        }

        private void CarregarDados()
        {
            txtCodigoCliente.Text = clienteSelecionado.cod_cliente.ToString();
            txtNome.Text = clienteSelecionado.Nome_Sobrenome;
            mskCpf.Text = clienteSelecionado.CPF;
            txtCidade.Text = clienteSelecionado.cidade;
            txtEndereco.Text = clienteSelecionado.Endereco;
            txtEmail.Text = clienteSelecionado.Email;
            dtpDtNascimento.Value = clienteSelecionado.Data_Nascimento;
            txtBairro.Text = clienteSelecionado.Bairro;
            cbbUF.Text = clienteSelecionado.UF;
            mskCep.Text = clienteSelecionado.CEP;
            mskTelefone.Text = clienteSelecionado.Telefone;
            txtLogradouro.Text = clienteSelecionado.NºLogradouro;

        }

        private void DesabilitarCampos()
        {

            txtNome.ReadOnly = true;
            mskCpf.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtEmail.ReadOnly = true;
            dtpDtNascimento.Enabled = false;
            txtBairro.ReadOnly = true;
            cbbUF.Enabled = false;
            mskCep.ReadOnly = true;
            mskTelefone.ReadOnly = true;
            txtLogradouro.ReadOnly = true;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;




        }


        #region Não permitir números
        public void NaoPermitirNumeros(TextBox txt, KeyPressEventArgs e)
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
        public void NaoDeixarZero(NumericUpDown nud, CancelEventArgs e)
        {
            if (nud.Value <= 0)
            {
                e.Cancel = true;
                errProvider.SetError(nud, "O valor deve ser maior que 0");

            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(nud, "");

            }
        }
        #endregion

        #region Validação do campo UF
        public void ValidarUF(CancelEventArgs e, ComboBox cbb)
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



        #region validar tipo de cliente 
        private void ValidarCliente(CheckBox cbk, MaskedTextBox msk)
        {

            if (cbk.Checked)
            {

                msk.Enabled = false;
                errProvider.SetError(msk, "");
               
            }
            else
            {
                msk.Enabled = true;

            }

        }


        #endregion

      
        Form1 form = new Form1();

        private void Salvar()
        {
            if (!string.IsNullOrEmpty(txtEndereco.Text))
            {
                Cliente cliente = new Cliente();

                cliente.Nome_Sobrenome = txtNome.Text;
                cliente.CEP = mskCep.Text;
                cliente.CPF = mskCpf.Text;
                cliente.CPF = cliente.CPF.Replace(",", "");
                cliente.CPF = cliente.CPF.Replace("-", "");
                cliente.Data_Nascimento = dtpDtNascimento.Value;
                cliente.cidade = txtCidade.Text;
                cliente.Endereco = txtEndereco.Text;
                cliente.Telefone = mskTelefone.Text;
                cliente.Email = txtEmail.Text;
                cliente.NºLogradouro = txtLogradouro.Text;
                cliente.UF = cbbUF.Text;
                cliente.Bairro = txtBairro.Text;
                    



             



                ClienteController clienteController = new ClienteController();
                int retonoSql = 0;

                if (acaoSelecionada == AcaoNaTela.Inserir)
                    retonoSql = clienteController.Inserir(cliente);
                else
                {
                    cliente.cod_cliente = int.Parse(txtCodigoCliente.Text);
                    retonoSql = clienteController.Alterar(cliente);
                }

                if (retonoSql > 0)
                {
                    if (acaoSelecionada == AcaoNaTela.Inserir)
                        txtCodigoCliente.Text = retonoSql.ToString();

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

        

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtNome, e, "O campo nome está vazio");
        }

        

        private void mskCep_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoNumeroMasked(mskCep, e, 8, "O campo CEP está vazio", "O campo CEP deve ter 8 números");
        }

        private void mskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirLetrasMasked(mskCep, e);
        }

        private void mskCpf_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoNumeroMasked(mskCpf, e, 11, "O campo CPF está vazio", "O campo CPF deve ter 11 números");
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirLetrasMasked(mskCpf, e);
        }

        private void mskTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirLetrasMasked(mskTelefone, e);
        }

        private void mskTelefone_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoNumeroMasked(mskTelefone, e, 11, "O campo Telefone está vazio", "O campo Telefone deve ter 11 número contando com o DDD");
        }

        private void txtCidade_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtCidade, e, "O campo Cidade está vazio");
        }

       

        private void txtBairro_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtBairro, e, "O campo Bairro está vazio");
        }

        private void txtEndereco_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtEndereco, e, "O campo Endereço está vazio");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtEmail, e, "O campo Email está vazio");
        }

        private void txtLogradouro_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtLogradouro, e, "O campo Nº logradouro está vazio");
        }

        private void txtLogradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirLetras(txtLogradouro,e);
        }

       

        private void cbbUF_Validating(object sender, CancelEventArgs e)
        {
            ValidarUF(e, cbbUF);
        }

       

      
    }


}
