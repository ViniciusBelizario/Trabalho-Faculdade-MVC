namespace Loja_x_Store
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.fmrCadProduto = new System.Windows.Forms.Button();
            this.fmrCadFornecedor = new System.Windows.Forms.Button();
            this.fmrCadCliente = new System.Windows.Forms.Button();
            this.btnCaduncionario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipAtalho = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(295, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 112);
            this.label1.TabIndex = 6;
            this.label1.Text = "x-Store";
            // 
            // fmrCadProduto
            // 
            this.fmrCadProduto.FlatAppearance.BorderSize = 0;
            this.fmrCadProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fmrCadProduto.Image = global::Loja_x_Store.Properties.Resources.icons8_produto_90__1_;
            this.fmrCadProduto.Location = new System.Drawing.Point(11, 384);
            this.fmrCadProduto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fmrCadProduto.Name = "fmrCadProduto";
            this.fmrCadProduto.Size = new System.Drawing.Size(86, 98);
            this.fmrCadProduto.TabIndex = 5;
            this.fmrCadProduto.UseVisualStyleBackColor = true;
            this.fmrCadProduto.Click += new System.EventHandler(this.fmrCadProduto_Click);
            // 
            // fmrCadFornecedor
            // 
            this.fmrCadFornecedor.FlatAppearance.BorderSize = 0;
            this.fmrCadFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fmrCadFornecedor.Image = global::Loja_x_Store.Properties.Resources.icons8_fornecedor_90;
            this.fmrCadFornecedor.Location = new System.Drawing.Point(13, 256);
            this.fmrCadFornecedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fmrCadFornecedor.Name = "fmrCadFornecedor";
            this.fmrCadFornecedor.Size = new System.Drawing.Size(93, 101);
            this.fmrCadFornecedor.TabIndex = 4;
            this.fmrCadFornecedor.UseVisualStyleBackColor = true;
            this.fmrCadFornecedor.Click += new System.EventHandler(this.fmrCadFornecedor_Click);
            // 
            // fmrCadCliente
            // 
            this.fmrCadCliente.FlatAppearance.BorderSize = 0;
            this.fmrCadCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fmrCadCliente.Image = global::Loja_x_Store.Properties.Resources.icons8_grupo_de_usuário_homem_mulher_90;
            this.fmrCadCliente.Location = new System.Drawing.Point(13, 135);
            this.fmrCadCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fmrCadCliente.Name = "fmrCadCliente";
            this.fmrCadCliente.Size = new System.Drawing.Size(93, 103);
            this.fmrCadCliente.TabIndex = 3;
            this.fmrCadCliente.UseVisualStyleBackColor = true;
            this.fmrCadCliente.Click += new System.EventHandler(this.fmrCadCliente_Click);
            // 
            // btnCaduncionario
            // 
            this.btnCaduncionario.FlatAppearance.BorderSize = 0;
            this.btnCaduncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaduncionario.Image = global::Loja_x_Store.Properties.Resources.icons8_adicionar_usuário_masculino_90;
            this.btnCaduncionario.Location = new System.Drawing.Point(17, 17);
            this.btnCaduncionario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCaduncionario.Name = "btnCaduncionario";
            this.btnCaduncionario.Size = new System.Drawing.Size(93, 107);
            this.btnCaduncionario.TabIndex = 2;
            this.btnCaduncionario.UseVisualStyleBackColor = true;
            this.btnCaduncionario.Click += new System.EventHandler(this.btnCadastrarFuncionario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 484);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cadastar Produto ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cadastrar Fornecedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cadastrar Clientes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cadastrar Funcionarios";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(758, 527);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fmrCadProduto);
            this.Controls.Add(this.fmrCadFornecedor);
            this.Controls.Add(this.fmrCadCliente);
            this.Controls.Add(this.btnCaduncionario);
            this.Name = "Form1";
            this.Text = "Loja x-Store";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCaduncionario;
        private System.Windows.Forms.Button fmrCadCliente;
        private System.Windows.Forms.Button fmrCadFornecedor;
        private System.Windows.Forms.Button fmrCadProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTipAtalho;
    }
}

