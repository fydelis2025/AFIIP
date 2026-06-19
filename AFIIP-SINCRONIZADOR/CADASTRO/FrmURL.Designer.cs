namespace AFIIP_SINCRONIZADOR.CADASTRO
{
    partial class FrmURL
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtFechar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChOrgao = new System.Windows.Forms.CheckBox();
            this.ChTituloBusca = new System.Windows.Forms.CheckBox();
            this.ChMunicipio = new System.Windows.Forms.CheckBox();
            this.ChUF = new System.Windows.Forms.CheckBox();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TxOBS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxCodigoIBGE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CbOrgao = new System.Windows.Forms.ComboBox();
            this.CbMunicipio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbUF = new System.Windows.Forms.ComboBox();
            this.BtSalvar = new System.Windows.Forms.Button();
            this.TxTituloBusca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DgGrid = new System.Windows.Forms.DataGridView();
            this.ORGAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUNICIPIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(50, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(738, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1041, 0);
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
            this.label1.Size = new System.Drawing.Size(1867, 0);
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
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.BtBuscar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.TxOBS);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.TxCodigoIBGE);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.TxURL);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.CbOrgao);
            this.panel2.Controls.Add(this.CbMunicipio);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.CbUF);
            this.panel2.Controls.Add(this.BtSalvar);
            this.panel2.Controls.Add(this.TxTituloBusca);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 178);
            this.panel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChOrgao);
            this.groupBox1.Controls.Add(this.ChTituloBusca);
            this.groupBox1.Controls.Add(this.ChMunicipio);
            this.groupBox1.Controls.Add(this.ChUF);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 55);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTRAR";
            // 
            // ChOrgao
            // 
            this.ChOrgao.AutoSize = true;
            this.ChOrgao.Location = new System.Drawing.Point(266, 19);
            this.ChOrgao.Name = "ChOrgao";
            this.ChOrgao.Size = new System.Drawing.Size(67, 19);
            this.ChOrgao.TabIndex = 3;
            this.ChOrgao.Text = "ORGÃO";
            this.ChOrgao.UseVisualStyleBackColor = true;
            // 
            // ChTituloBusca
            // 
            this.ChTituloBusca.AutoSize = true;
            this.ChTituloBusca.Location = new System.Drawing.Point(156, 19);
            this.ChTituloBusca.Name = "ChTituloBusca";
            this.ChTituloBusca.Size = new System.Drawing.Size(104, 19);
            this.ChTituloBusca.TabIndex = 2;
            this.ChTituloBusca.Text = "TITULO BUSCA";
            this.ChTituloBusca.UseVisualStyleBackColor = true;
            // 
            // ChMunicipio
            // 
            this.ChMunicipio.AutoSize = true;
            this.ChMunicipio.Location = new System.Drawing.Point(63, 19);
            this.ChMunicipio.Name = "ChMunicipio";
            this.ChMunicipio.Size = new System.Drawing.Size(87, 19);
            this.ChMunicipio.TabIndex = 1;
            this.ChMunicipio.Text = "MUNICIPIO";
            this.ChMunicipio.UseVisualStyleBackColor = true;
            // 
            // ChUF
            // 
            this.ChUF.AutoSize = true;
            this.ChUF.Location = new System.Drawing.Point(6, 19);
            this.ChUF.Name = "ChUF";
            this.ChUF.Size = new System.Drawing.Size(40, 19);
            this.ChUF.TabIndex = 0;
            this.ChUF.Text = "UF";
            this.ChUF.UseVisualStyleBackColor = true;
            // 
            // BtBuscar
            // 
            this.BtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.BtBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtBuscar.FlatAppearance.BorderSize = 0;
            this.BtBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscar.ForeColor = System.Drawing.Color.White;
            this.BtBuscar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.OCORRENCIA;
            this.BtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtBuscar.Location = new System.Drawing.Point(439, 120);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(90, 55);
            this.BtBuscar.TabIndex = 15;
            this.BtBuscar.Text = "BUSCAR";
            this.BtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtBuscar.UseVisualStyleBackColor = false;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "OBS";
            // 
            // TxOBS
            // 
            this.TxOBS.Location = new System.Drawing.Point(439, 88);
            this.TxOBS.Name = "TxOBS";
            this.TxOBS.Size = new System.Drawing.Size(349, 23);
            this.TxOBS.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "CODIGO IBGE";
            // 
            // TxCodigoIBGE
            // 
            this.TxCodigoIBGE.Location = new System.Drawing.Point(302, 37);
            this.TxCodigoIBGE.Name = "TxCodigoIBGE";
            this.TxCodigoIBGE.Size = new System.Drawing.Size(107, 23);
            this.TxCodigoIBGE.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "URL";
            // 
            // TxURL
            // 
            this.TxURL.Location = new System.Drawing.Point(12, 88);
            this.TxURL.MaxLength = 500;
            this.TxURL.Name = "TxURL";
            this.TxURL.Size = new System.Drawing.Size(421, 23);
            this.TxURL.TabIndex = 9;
            this.TxURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxURL_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(627, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "TITULO BUSCA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "ORGÃO GOV-BR";
            // 
            // CbOrgao
            // 
            this.CbOrgao.FormattingEnabled = true;
            this.CbOrgao.Location = new System.Drawing.Point(415, 37);
            this.CbOrgao.Name = "CbOrgao";
            this.CbOrgao.Size = new System.Drawing.Size(206, 23);
            this.CbOrgao.TabIndex = 6;
            this.CbOrgao.Click += new System.EventHandler(this.CbOrgao_Click);
            // 
            // CbMunicipio
            // 
            this.CbMunicipio.FormattingEnabled = true;
            this.CbMunicipio.Location = new System.Drawing.Point(92, 37);
            this.CbMunicipio.Name = "CbMunicipio";
            this.CbMunicipio.Size = new System.Drawing.Size(206, 23);
            this.CbMunicipio.TabIndex = 5;
            this.CbMunicipio.SelectedValueChanged += new System.EventHandler(this.CbMunicipio_SelectedValueChanged);
            this.CbMunicipio.Click += new System.EventHandler(this.CbMunicipio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "MUNICIPIO";
            // 
            // CbUF
            // 
            this.CbUF.FormattingEnabled = true;
            this.CbUF.Location = new System.Drawing.Point(12, 37);
            this.CbUF.Name = "CbUF";
            this.CbUF.Size = new System.Drawing.Size(74, 23);
            this.CbUF.TabIndex = 3;
            this.CbUF.Click += new System.EventHandler(this.CbUF_Click);
            // 
            // BtSalvar
            // 
            this.BtSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.BtSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtSalvar.FlatAppearance.BorderSize = 0;
            this.BtSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSalvar.ForeColor = System.Drawing.Color.White;
            this.BtSalvar.Image = global::AFIIP_SINCRONIZADOR.Properties.Resources.Salvar;
            this.BtSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtSalvar.Location = new System.Drawing.Point(535, 117);
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.Size = new System.Drawing.Size(101, 55);
            this.BtSalvar.TabIndex = 2;
            this.BtSalvar.Text = "SALVAR";
            this.BtSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtSalvar.UseVisualStyleBackColor = false;
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // TxTituloBusca
            // 
            this.TxTituloBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxTituloBusca.Location = new System.Drawing.Point(627, 37);
            this.TxTituloBusca.MaxLength = 150;
            this.TxTituloBusca.Name = "TxTituloBusca";
            this.TxTituloBusca.Size = new System.Drawing.Size(161, 23);
            this.TxTituloBusca.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "UF";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(191)))), ((int)(((byte)(76)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 227);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 10);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DgGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 237);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 264);
            this.panel4.TabIndex = 12;
            // 
            // DgGrid
            // 
            this.DgGrid.AllowUserToAddRows = false;
            this.DgGrid.AllowUserToDeleteRows = false;
            this.DgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.DgGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORGAO,
            this.TITULO,
            this.URL,
            this.OBS,
            this.UF,
            this.MUNICIPIO,
            this.Editar,
            this.Excluir});
            this.DgGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DgGrid.Location = new System.Drawing.Point(5, 3);
            this.DgGrid.Name = "DgGrid";
            this.DgGrid.RowHeadersVisible = false;
            this.DgGrid.RowTemplate.Height = 25;
            this.DgGrid.Size = new System.Drawing.Size(790, 258);
            this.DgGrid.TabIndex = 10;
            this.DgGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgGrid_CellClick);
            // 
            // ORGAO
            // 
            this.ORGAO.FillWeight = 150F;
            this.ORGAO.HeaderText = "ORGAO";
            this.ORGAO.Name = "ORGAO";
            this.ORGAO.Width = 150;
            // 
            // TITULO
            // 
            this.TITULO.FillWeight = 150F;
            this.TITULO.HeaderText = "TITULO";
            this.TITULO.Name = "TITULO";
            this.TITULO.Width = 150;
            // 
            // URL
            // 
            this.URL.FillWeight = 300F;
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.Width = 300;
            // 
            // OBS
            // 
            this.OBS.FillWeight = 300F;
            this.OBS.HeaderText = "OBS";
            this.OBS.Name = "OBS";
            this.OBS.Width = 300;
            // 
            // UF
            // 
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            this.UF.Visible = false;
            // 
            // MUNICIPIO
            // 
            this.MUNICIPIO.HeaderText = "MUNICIPIO";
            this.MUNICIPIO.Name = "MUNICIPIO";
            this.MUNICIPIO.Visible = false;
            // 
            // Editar
            // 
            this.Editar.FillWeight = 50F;
            this.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Editar.Text = "Editar";
            this.Editar.ToolTipText = "Editar";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 50;
            // 
            // Excluir
            // 
            this.Excluir.FillWeight = 50F;
            this.Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Excluir.HeaderText = "Excluir";
            this.Excluir.Name = "Excluir";
            this.Excluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Excluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Excluir.Text = "Excluir";
            this.Excluir.ToolTipText = "Excluir";
            this.Excluir.UseColumnTextForButtonValue = true;
            this.Excluir.Width = 50;
            // 
            // FrmURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmURL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtFechar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private PictureBox BtFechar;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button BtSalvar;
        private TextBox TxTituloBusca;
        private Label label4;
        private ComboBox CbUF;
        private Label label7;
        private Label label6;
        private ComboBox CbOrgao;
        private ComboBox CbMunicipio;
        private Label label5;
        private Label label8;
        private TextBox TxURL;
        private TextBox TxCodigoIBGE;
        private Label label9;
        private TextBox TxOBS;
        private Label label10;
        private Button BtBuscar;
        private GroupBox groupBox1;
        private CheckBox ChMunicipio;
        private CheckBox ChUF;
        private CheckBox ChTituloBusca;
        private CheckBox ChOrgao;
        private DataGridView DgGrid;
        private DataGridViewTextBoxColumn ORGAO;
        private DataGridViewTextBoxColumn TITULO;
        private DataGridViewTextBoxColumn URL;
        private DataGridViewTextBoxColumn OBS;
        private DataGridViewTextBoxColumn UF;
        private DataGridViewTextBoxColumn MUNICIPIO;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Excluir;
    }
}