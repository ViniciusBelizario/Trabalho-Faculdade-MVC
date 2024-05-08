namespace Loja_x_Store.View
{
    partial class frmCadProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNome = new System.Windows.Forms.Label();
            this.DTRegistro = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblQt = new System.Windows.Forms.Label();
            this.dtpDtRegistro = new System.Windows.Forms.DateTimePicker();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudQtEstoque = new System.Windows.Forms.NumericUpDown();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.mskCodigoBarras = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(127, 25);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // DTRegistro
            // 
            this.DTRegistro.AutoSize = true;
            this.DTRegistro.Location = new System.Drawing.Point(334, 123);
            this.DTRegistro.Name = "DTRegistro";
            this.DTRegistro.Size = new System.Drawing.Size(85, 13);
            this.DTRegistro.TabIndex = 1;
            this.DTRegistro.Text = "Data de registro:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(16, 174);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(90, 13);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código de barras:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(12, 74);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(283, 74);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoria:";
            // 
            // lblQt
            // 
            this.lblQt.AutoSize = true;
            this.lblQt.Location = new System.Drawing.Point(12, 123);
            this.lblQt.Name = "lblQt";
            this.lblQt.Size = new System.Drawing.Size(123, 13);
            this.lblQt.TabIndex = 6;
            this.lblQt.Text = "Quantidade em estoque:";
            // 
            // dtpDtRegistro
            // 
            this.dtpDtRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtRegistro.Location = new System.Drawing.Point(337, 139);
            this.dtpDtRegistro.Name = "dtpDtRegistro";
            this.dtpDtRegistro.Size = new System.Drawing.Size(105, 20);
            this.dtpDtRegistro.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(130, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(368, 20);
            this.txtNome.TabIndex = 8;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(15, 90);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(262, 20);
            this.txtMarca.TabIndex = 11;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            this.txtMarca.Validating += new System.ComponentModel.CancelEventHandler(this.txtMarca_Validating);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(286, 90);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(212, 20);
            this.txtCategoria.TabIndex = 12;
            this.txtCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategoria_Validating);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::Loja_x_Store.Properties.Resources.icons8_ok_54;
            this.btnSalvar.Location = new System.Drawing.Point(344, 269);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 64);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::Loja_x_Store.Properties.Resources.icons8_cancelar_54;
            this.btnCancelar.Location = new System.Drawing.Point(425, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 64);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // nudQtEstoque
            // 
            this.nudQtEstoque.Location = new System.Drawing.Point(15, 140);
            this.nudQtEstoque.Name = "nudQtEstoque";
            this.nudQtEstoque.Size = new System.Drawing.Size(117, 20);
            this.nudQtEstoque.TabIndex = 17;
            this.nudQtEstoque.Validating += new System.ComponentModel.CancelEventHandler(this.nudQtEstoque_Validating);
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(12, 41);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.ReadOnly = true;
            this.txtCodigoProduto.Size = new System.Drawing.Size(109, 20);
            this.txtCodigoProduto.TabIndex = 19;
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Location = new System.Drawing.Point(12, 25);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(97, 13);
            this.lblCodigoProduto.TabIndex = 18;
            this.lblCodigoProduto.Text = "Código do produto:";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(157, 140);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(154, 20);
            this.txtPreco.TabIndex = 21;
            this.txtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
         
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(154, 123);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(38, 13);
            this.lblPreco.TabIndex = 20;
            this.lblPreco.Text = "Preço:";
            // 
            // mskCodigoBarras
            // 
            this.mskCodigoBarras.Location = new System.Drawing.Point(19, 190);
            this.mskCodigoBarras.Mask = "9999999999999";
            this.mskCodigoBarras.Name = "mskCodigoBarras";
            this.mskCodigoBarras.Size = new System.Drawing.Size(297, 20);
            this.mskCodigoBarras.TabIndex = 22;
            this.mskCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskCodigoBarras_KeyPress);
            this.mskCodigoBarras.Validating += new System.ComponentModel.CancelEventHandler(this.mskCodigoBarras_Validating);
            // 
            // frmCadProduto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(529, 342);
            this.Controls.Add(this.mskCodigoBarras);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtCodigoProduto);
            this.Controls.Add(this.lblCodigoProduto);
            this.Controls.Add(this.nudQtEstoque);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dtpDtRegistro);
            this.Controls.Add(this.lblQt);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.DTRegistro);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produto";
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label DTRegistro;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblQt;
        private System.Windows.Forms.DateTimePicker dtpDtRegistro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.NumericUpDown nudQtEstoque;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.MaskedTextBox mskCodigoBarras;
    }
}