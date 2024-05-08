using System;
using System.ComponentModel;
using System.Windows.Forms;
using Loja_x_Store.View;
using Loja_x_Store.Models;
//using Loja_x_Store.Controllers;
using Loja_x_Store.Services;
using Loja_x_Store.Controller;
namespace Loja_x_Store.View
{
    public partial class frmCadProduto : Form
    {
        AcaoNaTela acaoSelecionada;
        Produto produtoSelecionado;
        public frmCadProduto(AcaoNaTela acaoTela, Produto produto)
        {
            InitializeComponent();
            acaoSelecionada = acaoTela;
            produtoSelecionado = produto;
            if (acaoSelecionada == AcaoNaTela.Inserir)
                this.Text = "Cadastrar Produto";
            else
            {
                CarregarDados();

                if (acaoSelecionada == AcaoNaTela.Alterar)
                {
                    this.Text = "Alterar Produto";
                    CarregarDados();
                }
                else
                {
                    this.Text = "Visualizar Produto";
                    DesabilitarCampos();
                }
            }
        }
        private void CarregarDados()
        {
            txtCodigoProduto.Text = produtoSelecionado.id_produto.ToString();
            txtNome.Text = produtoSelecionado.Nome;
            txtMarca.Text = produtoSelecionado.Marca;
            txtCategoria.Text = produtoSelecionado.Categoria;
            nudQtEstoque.Value = produtoSelecionado.Quantidade_estoque;
            txtPreco.Text = produtoSelecionado.Preco.ToString();
            mskCodigoBarras.Text = produtoSelecionado.Codigo_barras;
            dtpDtRegistro.Value = produtoSelecionado.DtRegistro;



        }

        private void DesabilitarCampos()
        {

            txtNome.ReadOnly = true;
            txtMarca.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            mskCodigoBarras.ReadOnly = true;
            txtPreco.ReadOnly = true;
            dtpDtRegistro.Enabled = false;
            nudQtEstoque.Enabled = false;


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


        #region validar Campo preço
        private void ValidarPreco(CancelEventArgs e)
        {
            try
            {
                int Converter = Convert.ToInt32(txtPreco.Text);
                if (Converter <= 0)
                {
                    e.Cancel = true;
                    errProvider.SetError(txtPreco, "O Preço não deve ser menor que 0");
                }

            }
            catch
            {
                errProvider.SetError(txtPreco, "O campo Preço está vazio");

            }
        }
        #endregion


        #region Validar Campo Masked
        private void ValidarCampoMasked(MaskedTextBox msk, CancelEventArgs e, string texto)
        {
            if (string.IsNullOrEmpty(msk.Text))
            {
                e.Cancel = true;
                errProvider.SetError(msk, texto);
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(msk, "");

            }
        }
        #endregion


        Form1 form = new Form1();

        private void Salvar()
        {
            if (!string.IsNullOrEmpty(txtCategoria.Text))
            {
                Produto produto = new Produto();



                string precoVenda = txtPreco.Text.Replace(".", "");
                decimal preco;

                if (decimal.TryParse(precoVenda, out preco))
                    produto.Preco = preco;
                else
                {
                    MessageBox.Show("Digite uma Preçoe válido.", "Atenção...",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    

                }

                produto.Categoria = txtCategoria.Text;
                produto.Codigo_barras = mskCodigoBarras.Text;
                produto.Marca = txtMarca.Text;
                produto.DtRegistro = dtpDtRegistro.Value;
                produto.Nome = txtNome.Text;
                produto.Quantidade_estoque = Convert.ToInt32(nudQtEstoque.Value);
                

              
                

                ProdutoController produtoController = new ProdutoController();
                int retonoSql = 0;

                if (acaoSelecionada == AcaoNaTela.Inserir)
                    retonoSql = produtoController.Inserir(produto);
                else
                {
                    produto.id_produto = int.Parse(txtCodigoProduto.Text);
                    retonoSql = produtoController.Alterar(produto);
                }

                if (retonoSql > 0)
                {
                    if (acaoSelecionada == AcaoNaTela.Inserir)
                        txtCodigoProduto.Text = retonoSql.ToString();

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           
            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                
                Close();
                Salvar();

            }
            else
            {
                MessageBox.Show("É necessário o preenchimento de " +
                                "todos os campos obrigatórios.",
                                "Atenção", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtNome, e, "O campo Nome está vazio");
        }

        private void txtMarca_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtMarca, e, "O campo Marca está vazio");
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtNome, e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            NaoPermitirNumeros(txtMarca, e);
        }



        private void txtCategoria_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampo(txtCategoria, e, "O campo Categoria está vazio");
        }

        private void nudQtEstoque_Validating(object sender, CancelEventArgs e)
        {

            NaoDeixarZero(nudQtEstoque, e);
        }




        #region Não utilizar o ponto no preço
        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(txtPreco, "Insira apenas números");

            }
            else if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                errProvider.SetError(txtPreco, "");
            }
        }







        #endregion

        private void mskCodigoBarras_Validating(object sender, CancelEventArgs e)
        {
            ValidarCampoMasked(mskCodigoBarras, e, "O campo Código de barras está vazio");
            ValidarCampoNumeroMasked(mskCodigoBarras, e, 13, "O campo Código de barras está vazio", "O campo Código de barras deve ter 13 números");
        }

        private void mskCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {

            NaoPermitirLetrasMasked(mskCodigoBarras, e);
        }

       
      }
    }

