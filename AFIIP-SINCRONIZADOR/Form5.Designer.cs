namespace AFIIP_SINCRONIZADOR
{
    partial class Form5
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxUsuario = new System.Windows.Forms.TextBox();
            this.CbUF = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtOK = new System.Windows.Forms.Button();
            this.BtFechar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.bloqueado;
            this.pictureBox1.Location = new System.Drawing.Point(38, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(235, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // TxUsuario
            // 
            this.TxUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxUsuario.Location = new System.Drawing.Point(235, 80);
            this.TxUsuario.Name = "TxUsuario";
            this.TxUsuario.Size = new System.Drawing.Size(332, 25);
            this.TxUsuario.TabIndex = 2;
            // 
            // CbUF
            // 
            this.CbUF.FormattingEnabled = true;
            this.CbUF.Location = new System.Drawing.Point(235, 137);
            this.CbUF.Name = "CbUF";
            this.CbUF.Size = new System.Drawing.Size(96, 23);
            this.CbUF.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(235, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "UF";
            // 
            // TxSenha
            // 
            this.TxSenha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxSenha.Location = new System.Drawing.Point(337, 137);
            this.TxSenha.Name = "TxSenha";
            this.TxSenha.PasswordChar = '*';
            this.TxSenha.Size = new System.Drawing.Size(230, 25);
            this.TxSenha.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(337, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Senha";
            // 
            // BtOK
            // 
            this.BtOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtOK.FlatAppearance.BorderSize = 0;
            this.BtOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOK.ForeColor = System.Drawing.Color.White;
            this.BtOK.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.controle_de_acesso;
            this.BtOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtOK.Location = new System.Drawing.Point(235, 178);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(150, 35);
            this.BtOK.TabIndex = 8;
            this.BtOK.Text = "LOGAR";
            this.BtOK.UseVisualStyleBackColor = true;
            this.BtOK.Click += new System.EventHandler(this.BtOK_Click);
            // 
            // BtFechar
            // 
            this.BtFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtFechar.FlatAppearance.BorderSize = 0;
            this.BtFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtFechar.ForeColor = System.Drawing.Color.White;
            this.BtFechar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.exit;
            this.BtFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtFechar.Location = new System.Drawing.Point(417, 178);
            this.BtFechar.Name = "BtFechar";
            this.BtFechar.Size = new System.Drawing.Size(150, 35);
            this.BtFechar.TabIndex = 9;
            this.BtFechar.Text = "FECHAR";
            this.BtFechar.UseVisualStyleBackColor = true;
            this.BtFechar.Click += new System.EventHandler(this.BtFechar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(296, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "http://www.incip.com.br";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(637, 301);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtFechar);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbUF);
            this.Controls.Add(this.TxUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACESSO RESTRITO";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox TxUsuario;
        private ComboBox CbUF;
        private Label label2;
        private TextBox TxSenha;
        private Label label3;
        private Button BtOK;
        private Button BtFechar;
        private Label label4;
    }
}