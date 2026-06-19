namespace AFIIP_SINCRONIZADOR.CADASTRO
{
    partial class FrmOrgao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtFechar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.BtIncluir = new System.Windows.Forms.Button();
            this.TxDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DgGrid = new System.Windows.Forms.DataGridView();
            this.DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 49);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "ORGÃO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1267, 0);
            this.label1.TabIndex = 5;
            this.label1.Text = "CONSULTAR INFORMAÇÕES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel2.Controls.Add(this.BtBuscar);
            this.panel2.Controls.Add(this.BtIncluir);
            this.panel2.Controls.Add(this.TxDescricao);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 77);
            this.panel2.TabIndex = 6;
            // 
            // BtBuscar
            // 
            this.BtBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtBuscar.FlatAppearance.BorderSize = 0;
            this.BtBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.OCORRENCIA;
            this.BtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtBuscar.Location = new System.Drawing.Point(437, 29);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(43, 37);
            this.BtBuscar.TabIndex = 10;
            this.BtBuscar.UseVisualStyleBackColor = true;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // BtIncluir
            // 
            this.BtIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtIncluir.FlatAppearance.BorderSize = 0;
            this.BtIncluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtIncluir.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.Salvar;
            this.BtIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtIncluir.Location = new System.Drawing.Point(388, 29);
            this.BtIncluir.Name = "BtIncluir";
            this.BtIncluir.Size = new System.Drawing.Size(43, 37);
            this.BtIncluir.TabIndex = 8;
            this.BtIncluir.UseVisualStyleBackColor = true;
            this.BtIncluir.Click += new System.EventHandler(this.BtIncluir_Click);
            // 
            // TxDescricao
            // 
            this.TxDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxDescricao.Location = new System.Drawing.Point(12, 37);
            this.TxDescricao.Name = "TxDescricao";
            this.TxDescricao.Size = new System.Drawing.Size(370, 23);
            this.TxDescricao.TabIndex = 7;
            this.TxDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescricao_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "DESCRIÇÃO";
            // 
            // DgGrid
            // 
            this.DgGrid.AllowUserToAddRows = false;
            this.DgGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.DgGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.DgGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DESCRICAO,
            this.Editar,
            this.Excluir});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DgGrid.Location = new System.Drawing.Point(0, 126);
            this.DgGrid.Name = "DgGrid";
            this.DgGrid.RowHeadersVisible = false;
            this.DgGrid.RowTemplate.Height = 25;
            this.DgGrid.Size = new System.Drawing.Size(503, 256);
            this.DgGrid.TabIndex = 9;
            this.DgGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgGrid_CellClick);
            // 
            // DESCRICAO
            // 
            this.DESCRICAO.FillWeight = 400F;
            this.DESCRICAO.HeaderText = "DESCRIÇÃO";
            this.DESCRICAO.Name = "DESCRICAO";
            this.DESCRICAO.Width = 400;
            // 
            // Editar
            // 
            this.Editar.FillWeight = 50F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.editar;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Editar.Name = "Editar";
            this.Editar.ToolTipText = "Editar";
            this.Editar.Width = 50;
            // 
            // Excluir
            // 
            this.Excluir.FillWeight = 50F;
            this.Excluir.HeaderText = "Excluir";
            this.Excluir.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources._6932392;
            this.Excluir.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Excluir.Name = "Excluir";
            this.Excluir.ToolTipText = "Excluir";
            this.Excluir.Width = 50;
            // 
            // FrmOrgao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(503, 382);
            this.Controls.Add(this.DgGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrgao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrgao";
            this.Load += new System.EventHandler(this.FrmOrgao_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox BtFechar;
        private Label label2;
        private Panel panel2;
        private DataGridView DgGrid;
        private TextBox TxDescricao;
        private Label label3;
        private DataGridViewTextBoxColumn DESCRICAO;
        private DataGridViewImageColumn Editar;
        private DataGridViewImageColumn Excluir;
        private Button BtIncluir;
        private Button BtBuscar;
    }
}