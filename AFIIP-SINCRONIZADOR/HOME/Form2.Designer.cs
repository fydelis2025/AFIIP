namespace AFIIP_SINCRONIZADOR.HOME
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgCEP = new System.Windows.Forms.DataGridView();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUNICIPIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAIRRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDERECO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.LbLeitura = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtFechar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PAguarde = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgCEP)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAguarde)).BeginInit();
            this.SuspendLayout();
            // 
            // DgCEP
            // 
            this.DgCEP.AllowUserToAddRows = false;
            this.DgCEP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgCEP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.DgCEP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgCEP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgCEP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgCEP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCEP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UF,
            this.MUNICIPIO,
            this.BAIRRO,
            this.ENDERECO,
            this.CEP});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgCEP.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgCEP.Location = new System.Drawing.Point(12, 134);
            this.DgCEP.Name = "DgCEP";
            this.DgCEP.RowHeadersVisible = false;
            this.DgCEP.Size = new System.Drawing.Size(830, 297);
            this.DgCEP.TabIndex = 0;
            // 
            // UF
            // 
            this.UF.FillWeight = 70F;
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            this.UF.Width = 70;
            // 
            // MUNICIPIO
            // 
            this.MUNICIPIO.FillWeight = 150F;
            this.MUNICIPIO.HeaderText = "MUNICIPIO";
            this.MUNICIPIO.Name = "MUNICIPIO";
            this.MUNICIPIO.Width = 150;
            // 
            // BAIRRO
            // 
            this.BAIRRO.FillWeight = 150F;
            this.BAIRRO.HeaderText = "BAIRRO";
            this.BAIRRO.Name = "BAIRRO";
            this.BAIRRO.Width = 150;
            // 
            // ENDERECO
            // 
            this.ENDERECO.FillWeight = 350F;
            this.ENDERECO.HeaderText = "ENDERECO";
            this.ENDERECO.Name = "ENDERECO";
            this.ENDERECO.Width = 350;
            // 
            // CEP
            // 
            this.CEP.HeaderText = "CEP";
            this.CEP.Name = "CEP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "LENDO...";
            // 
            // LbLeitura
            // 
            this.LbLeitura.AutoSize = true;
            this.LbLeitura.Location = new System.Drawing.Point(422, 64);
            this.LbLeitura.Name = "LbLeitura";
            this.LbLeitura.Size = new System.Drawing.Size(13, 15);
            this.LbLeitura.TabIndex = 6;
            this.LbLeitura.Text = "0";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.csv;
            this.button2.Location = new System.Drawing.Point(93, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "COMPARA";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.pasta;
            this.button1.Location = new System.Drawing.Point(12, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "CEP-COR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 49);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(50, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(792, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "COMPARA CEP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1599, 0);
            this.label2.TabIndex = 6;
            this.label2.Text = "CONSULTAR CADASTRO DE ELEITOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel2.Location = new System.Drawing.Point(0, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 25);
            this.panel2.TabIndex = 8;
            // 
            // PAguarde
            // 
            this.PAguarde.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.aguarde;
            this.PAguarde.Location = new System.Drawing.Point(319, 187);
            this.PAguarde.Name = "PAguarde";
            this.PAguarde.Size = new System.Drawing.Size(208, 208);
            this.PAguarde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PAguarde.TabIndex = 22;
            this.PAguarde.TabStop = false;
            this.PAguarde.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(854, 462);
            this.Controls.Add(this.PAguarde);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LbLeitura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DgCEP);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMPARA CEP";
            ((System.ComponentModel.ISupportInitialize)(this.DgCEP)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAguarde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DgCEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn MUNICIPIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAIRRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDERECO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbLeitura;
        private Panel panel1;
        private Label label2;
        private PictureBox BtFechar;
        private Panel panel2;
        private Label label3;
        private PictureBox PAguarde;
    }
}