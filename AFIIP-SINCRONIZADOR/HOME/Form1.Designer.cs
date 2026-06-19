namespace AFIIP_SINCRONIZADOR.HOME
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DgConsulta = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_TELEFONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGRADOURO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAIRRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEXO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDDFone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAGWHATS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATANASCIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMEMAE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMERECEITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTCIV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAIXA_RENDA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITULO_ELEITOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LbTotalRegistro = new System.Windows.Forms.Label();
            this.LbEncontrado = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtFechar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PAguarde = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgConsulta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAguarde)).BeginInit();
            this.SuspendLayout();
            // 
            // DgConsulta
            // 
            this.DgConsulta.AllowUserToAddRows = false;
            this.DgConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgConsulta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.DgConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.CPF,
            this.DDD,
            this.FONE,
            this.TIPO_TELEFONE,
            this.NOME,
            this.LOGRADOURO,
            this.NUM,
            this.COMPL,
            this.BAIRRO,
            this.CIDADE,
            this.UF,
            this.CEP,
            this.SEXO,
            this.OP,
            this.DDDFone,
            this.FLAGWHATS,
            this.EMAIL,
            this.DATANASCIMENTO,
            this.NOMEMAE,
            this.NOMERECEITA,
            this.ESTCIV,
            this.CBO,
            this.RENDA,
            this.FAIXA_RENDA_ID,
            this.TITULO_ELEITOR});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgConsulta.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgConsulta.Location = new System.Drawing.Point(14, 146);
            this.DgConsulta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgConsulta.Name = "DgConsulta";
            this.DgConsulta.RowHeadersVisible = false;
            this.DgConsulta.Size = new System.Drawing.Size(1017, 356);
            this.DgConsulta.TabIndex = 2;
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            // 
            // CPF
            // 
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            // 
            // DDD
            // 
            this.DDD.HeaderText = "DDD";
            this.DDD.Name = "DDD";
            // 
            // FONE
            // 
            this.FONE.HeaderText = "FONE";
            this.FONE.Name = "FONE";
            // 
            // TIPO_TELEFONE
            // 
            this.TIPO_TELEFONE.HeaderText = "TIPO_TELEFONE";
            this.TIPO_TELEFONE.Name = "TIPO_TELEFONE";
            // 
            // NOME
            // 
            this.NOME.FillWeight = 300F;
            this.NOME.HeaderText = "NOME";
            this.NOME.Name = "NOME";
            this.NOME.Width = 300;
            // 
            // LOGRADOURO
            // 
            this.LOGRADOURO.HeaderText = "LOGRADOURO";
            this.LOGRADOURO.Name = "LOGRADOURO";
            // 
            // NUM
            // 
            this.NUM.HeaderText = "NUM";
            this.NUM.Name = "NUM";
            // 
            // COMPL
            // 
            this.COMPL.HeaderText = "COMPL";
            this.COMPL.Name = "COMPL";
            // 
            // BAIRRO
            // 
            this.BAIRRO.HeaderText = "BAIRRO";
            this.BAIRRO.Name = "BAIRRO";
            // 
            // CIDADE
            // 
            this.CIDADE.HeaderText = "CIDADE";
            this.CIDADE.Name = "CIDADE";
            // 
            // UF
            // 
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            // 
            // CEP
            // 
            this.CEP.HeaderText = "CEP";
            this.CEP.Name = "CEP";
            // 
            // SEXO
            // 
            this.SEXO.HeaderText = "SEXO";
            this.SEXO.Name = "SEXO";
            // 
            // OP
            // 
            this.OP.HeaderText = "OP";
            this.OP.Name = "OP";
            // 
            // DDDFone
            // 
            this.DDDFone.HeaderText = "DDDFone";
            this.DDDFone.Name = "DDDFone";
            // 
            // FLAGWHATS
            // 
            this.FLAGWHATS.HeaderText = "FLAGWHATS";
            this.FLAGWHATS.Name = "FLAGWHATS";
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            // 
            // DATANASCIMENTO
            // 
            this.DATANASCIMENTO.HeaderText = "DATANASCIMENTO";
            this.DATANASCIMENTO.Name = "DATANASCIMENTO";
            // 
            // NOMEMAE
            // 
            this.NOMEMAE.FillWeight = 300F;
            this.NOMEMAE.HeaderText = "NOMEMAE";
            this.NOMEMAE.Name = "NOMEMAE";
            this.NOMEMAE.Width = 300;
            // 
            // NOMERECEITA
            // 
            this.NOMERECEITA.HeaderText = "NOMERECEITA";
            this.NOMERECEITA.Name = "NOMERECEITA";
            // 
            // ESTCIV
            // 
            this.ESTCIV.HeaderText = "ESTCIV";
            this.ESTCIV.Name = "ESTCIV";
            // 
            // CBO
            // 
            this.CBO.HeaderText = "CBO";
            this.CBO.Name = "CBO";
            // 
            // RENDA
            // 
            this.RENDA.HeaderText = "RENDA";
            this.RENDA.Name = "RENDA";
            // 
            // FAIXA_RENDA_ID
            // 
            this.FAIXA_RENDA_ID.HeaderText = "FAIXA_RENDA_ID";
            this.FAIXA_RENDA_ID.Name = "FAIXA_RENDA_ID";
            // 
            // TITULO_ELEITOR
            // 
            this.TITULO_ELEITOR.HeaderText = "TITULO_ELEITOR";
            this.TITULO_ELEITOR.Name = "TITULO_ELEITOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(327, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total de registro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(327, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total encontrado:";
            // 
            // LbTotalRegistro
            // 
            this.LbTotalRegistro.AutoSize = true;
            this.LbTotalRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbTotalRegistro.Location = new System.Drawing.Point(559, 68);
            this.LbTotalRegistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTotalRegistro.Name = "LbTotalRegistro";
            this.LbTotalRegistro.Size = new System.Drawing.Size(21, 24);
            this.LbTotalRegistro.TabIndex = 6;
            this.LbTotalRegistro.Text = "0";
            // 
            // LbEncontrado
            // 
            this.LbEncontrado.AutoSize = true;
            this.LbEncontrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LbEncontrado.Location = new System.Drawing.Point(559, 106);
            this.LbEncontrado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbEncontrado.Name = "LbEncontrado";
            this.LbEncontrado.Size = new System.Drawing.Size(21, 24);
            this.LbEncontrado.TabIndex = 7;
            this.LbEncontrado.Text = "0";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.csv;
            this.button3.Location = new System.Drawing.Point(112, 57);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 83);
            this.button3.TabIndex = 3;
            this.button3.Text = "CHK-BUK-FP";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.csv;
            this.button1.Location = new System.Drawing.Point(13, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 83);
            this.button1.TabIndex = 0;
            this.button1.Text = "ORIG-RS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BtFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 49);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(50, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(983, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "CHECA NUMERO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(50, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1637, 0);
            this.label3.TabIndex = 7;
            this.label3.Text = "COMPARA CEP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(50, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2444, 0);
            this.label4.TabIndex = 6;
            this.label4.Text = "CONSULTAR CADASTRO DE ELEITOR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtFechar
            // 
            this.BtFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtFechar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.fechar;
            this.BtFechar.Location = new System.Drawing.Point(12, 10);
            this.BtFechar.MaximumSize = new System.Drawing.Size(32, 32);
            this.BtFechar.MinimumSize = new System.Drawing.Size(32, 32);
            this.BtFechar.Name = "BtFechar";
            this.BtFechar.Size = new System.Drawing.Size(32, 32);
            this.BtFechar.TabIndex = 4;
            this.BtFechar.TabStop = false;
            this.BtFechar.Click += new System.EventHandler(this.BtFechar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 25);
            this.panel2.TabIndex = 9;
            // 
            // PAguarde
            // 
            this.PAguarde.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.aguarde;
            this.PAguarde.Location = new System.Drawing.Point(414, 211);
            this.PAguarde.Name = "PAguarde";
            this.PAguarde.Size = new System.Drawing.Size(208, 208);
            this.PAguarde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PAguarde.TabIndex = 21;
            this.PAguarde.TabStop = false;
            this.PAguarde.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1045, 533);
            this.Controls.Add(this.PAguarde);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LbEncontrado);
            this.Controls.Add(this.LbTotalRegistro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DgConsulta);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECA NUMERO";
            ((System.ComponentModel.ISupportInitialize)(this.DgConsulta)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAguarde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DgConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn FONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_TELEFONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGRADOURO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPL;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAIRRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEXO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDDFone;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAGWHATS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATANASCIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMEMAE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMERECEITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTCIV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAIXA_RENDA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITULO_ELEITOR;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbTotalRegistro;
        private System.Windows.Forms.Label LbEncontrado;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private PictureBox BtFechar;
        private Panel panel2;
        private Label label5;
        private PictureBox PAguarde;
    }
}

