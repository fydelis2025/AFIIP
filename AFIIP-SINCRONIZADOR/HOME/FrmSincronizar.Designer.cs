namespace AFIIP_SINCRONIZADOR.HOME
{
    partial class FrmSincronizar
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSincronizar));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            TreArquivo = new TreeView();
            imageList1 = new ImageList(components);
            BtOK = new Button();
            TxResultado = new TextBox();
            RdOriginal = new RadioButton();
            RdCarlito = new RadioButton();
            RdFotos = new RadioButton();
            RdRedes = new RadioButton();
            RdVotos = new RadioButton();
            RdCandidatos = new RadioButton();
            LbProgresso = new Label();
            RdSecao = new RadioButton();
            groupBox1 = new GroupBox();
            RdGuarulhos = new RadioButton();
            RdFiliados = new RadioButton();
            RdDelegadoPartidario = new RadioButton();
            RdMunZona2020 = new RadioButton();
            RdMunZona2018 = new RadioButton();
            RdPartidoMunZona2020 = new RadioButton();
            RdPartidoMunZona2018 = new RadioButton();
            RdBoletimUrna = new RadioButton();
            RdMunZona = new RadioButton();
            RdCand2018 = new RadioButton();
            RdCandTelZap = new RadioButton();
            BtFechar = new Button();
            BtPararSQL = new Button();
            BtIniciarSQL = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 151, 50);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(731, 49);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(50, 10);
            label1.Name = "label1";
            label1.Size = new Size(669, 32);
            label1.TabIndex = 5;
            label1.Text = "SINCRONIZAR ARQUIVOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.fechar;
            pictureBox1.Location = new Point(12, 10);
            pictureBox1.MaximumSize = new Size(32, 32);
            pictureBox1.MinimumSize = new Size(32, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TreArquivo
            // 
            TreArquivo.BackColor = Color.FromArgb(32, 30, 45);
            TreArquivo.CheckBoxes = true;
            TreArquivo.Dock = DockStyle.Left;
            TreArquivo.ForeColor = Color.White;
            TreArquivo.ImageIndex = 0;
            TreArquivo.ImageList = imageList1;
            TreArquivo.Location = new Point(0, 49);
            TreArquivo.Name = "TreArquivo";
            TreArquivo.SelectedImageIndex = 0;
            TreArquivo.ShowNodeToolTips = true;
            TreArquivo.Size = new Size(222, 428);
            TreArquivo.StateImageList = imageList1;
            TreArquivo.TabIndex = 2;
            TreArquivo.Click += TreArquivo_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "csv.png");
            imageList1.Images.SetKeyName(1, "pasta.png");
            // 
            // BtOK
            // 
            BtOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtOK.Cursor = Cursors.Hand;
            BtOK.FlatAppearance.BorderSize = 0;
            BtOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            BtOK.FlatStyle = FlatStyle.Flat;
            BtOK.ForeColor = Color.White;
            BtOK.Image = Properties.Resources.exportar;
            BtOK.ImageAlign = ContentAlignment.MiddleLeft;
            BtOK.Location = new Point(569, 279);
            BtOK.Name = "BtOK";
            BtOK.Size = new Size(150, 35);
            BtOK.TabIndex = 3;
            BtOK.Text = "SINCRONIZAR";
            BtOK.UseVisualStyleBackColor = true;
            BtOK.Click += BtOK_Click;
            // 
            // TxResultado
            // 
            TxResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxResultado.BackColor = Color.FromArgb(32, 30, 45);
            TxResultado.BorderStyle = BorderStyle.None;
            TxResultado.ForeColor = Color.White;
            TxResultado.Location = new Point(228, 55);
            TxResultado.Multiline = true;
            TxResultado.Name = "TxResultado";
            TxResultado.ScrollBars = ScrollBars.Both;
            TxResultado.Size = new Size(491, 163);
            TxResultado.TabIndex = 4;
            // 
            // RdOriginal
            // 
            RdOriginal.AutoSize = true;
            RdOriginal.ForeColor = Color.White;
            RdOriginal.Location = new Point(18, 46);
            RdOriginal.Name = "RdOriginal";
            RdOriginal.Size = new Size(70, 19);
            RdOriginal.TabIndex = 7;
            RdOriginal.Text = "Original ";
            RdOriginal.UseVisualStyleBackColor = true;
            RdOriginal.Click += RdOriginal_Click;
            // 
            // RdCarlito
            // 
            RdCarlito.AutoSize = true;
            RdCarlito.Checked = true;
            RdCarlito.ForeColor = Color.White;
            RdCarlito.Location = new Point(18, 21);
            RdCarlito.Name = "RdCarlito";
            RdCarlito.Size = new Size(105, 19);
            RdCarlito.TabIndex = 8;
            RdCarlito.TabStop = true;
            RdCarlito.Text = "Original Carlito";
            RdCarlito.UseVisualStyleBackColor = true;
            RdCarlito.CheckedChanged += RdCarlito_CheckedChanged;
            RdCarlito.Click += RdCarlito_Click;
            // 
            // RdFotos
            // 
            RdFotos.AutoSize = true;
            RdFotos.ForeColor = Color.White;
            RdFotos.Location = new Point(18, 71);
            RdFotos.Name = "RdFotos";
            RdFotos.Size = new Size(117, 19);
            RdFotos.TabIndex = 9;
            RdFotos.Text = "Fotos Candidatos";
            RdFotos.UseVisualStyleBackColor = true;
            RdFotos.Click += RdFotos_Click;
            // 
            // RdRedes
            // 
            RdRedes.AutoSize = true;
            RdRedes.ForeColor = Color.White;
            RdRedes.Location = new Point(18, 97);
            RdRedes.Name = "RdRedes";
            RdRedes.Size = new Size(158, 19);
            RdRedes.TabIndex = 10;
            RdRedes.Text = "Redes Sociais Candidatos";
            RdRedes.UseVisualStyleBackColor = true;
            RdRedes.Click += RdRedes_Click;
            // 
            // RdVotos
            // 
            RdVotos.AutoSize = true;
            RdVotos.ForeColor = Color.White;
            RdVotos.Location = new Point(18, 146);
            RdVotos.Name = "RdVotos";
            RdVotos.Size = new Size(106, 19);
            RdVotos.TabIndex = 11;
            RdVotos.Text = "Municipio Voto";
            RdVotos.UseVisualStyleBackColor = true;
            RdVotos.Click += RdVotos_Click;
            // 
            // RdCandidatos
            // 
            RdCandidatos.AutoSize = true;
            RdCandidatos.ForeColor = Color.White;
            RdCandidatos.Location = new Point(18, 194);
            RdCandidatos.Name = "RdCandidatos";
            RdCandidatos.Size = new Size(109, 19);
            RdCandidatos.TabIndex = 12;
            RdCandidatos.Text = "Candidatos2020";
            RdCandidatos.UseVisualStyleBackColor = true;
            RdCandidatos.CheckedChanged += radioButton4_CheckedChanged;
            RdCandidatos.Click += RdCandidatos_Click;
            // 
            // LbProgresso
            // 
            LbProgresso.AutoSize = true;
            LbProgresso.ForeColor = Color.White;
            LbProgresso.Location = new Point(644, 446);
            LbProgresso.Name = "LbProgresso";
            LbProgresso.Size = new Size(69, 15);
            LbProgresso.TabIndex = 13;
            LbProgresso.Text = "AGUARDE...";
            // 
            // RdSecao
            // 
            RdSecao.AutoSize = true;
            RdSecao.ForeColor = Color.White;
            RdSecao.Location = new Point(18, 122);
            RdSecao.Name = "RdSecao";
            RdSecao.Size = new Size(56, 19);
            RdSecao.TabIndex = 14;
            RdSecao.Text = "Seção";
            RdSecao.UseVisualStyleBackColor = true;
            RdSecao.Click += RdSecao_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RdGuarulhos);
            groupBox1.Controls.Add(RdFiliados);
            groupBox1.Controls.Add(RdDelegadoPartidario);
            groupBox1.Controls.Add(RdMunZona2020);
            groupBox1.Controls.Add(RdMunZona2018);
            groupBox1.Controls.Add(RdPartidoMunZona2020);
            groupBox1.Controls.Add(RdPartidoMunZona2018);
            groupBox1.Controls.Add(RdBoletimUrna);
            groupBox1.Controls.Add(RdMunZona);
            groupBox1.Controls.Add(RdCand2018);
            groupBox1.Controls.Add(RdCandTelZap);
            groupBox1.Controls.Add(RdCarlito);
            groupBox1.Controls.Add(RdSecao);
            groupBox1.Controls.Add(RdOriginal);
            groupBox1.Controls.Add(RdFotos);
            groupBox1.Controls.Add(RdCandidatos);
            groupBox1.Controls.Add(RdRedes);
            groupBox1.Controls.Add(RdVotos);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(228, 224);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 241);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "OPÇÕES";
            // 
            // RdGuarulhos
            // 
            RdGuarulhos.AutoSize = true;
            RdGuarulhos.ForeColor = Color.White;
            RdGuarulhos.Location = new Point(190, 216);
            RdGuarulhos.Name = "RdGuarulhos";
            RdGuarulhos.Size = new Size(79, 19);
            RdGuarulhos.TabIndex = 25;
            RdGuarulhos.Text = "Guarulhos";
            RdGuarulhos.UseVisualStyleBackColor = true;
            RdGuarulhos.Click += RdGuarulhos_Click;
            // 
            // RdFiliados
            // 
            RdFiliados.AutoSize = true;
            RdFiliados.ForeColor = Color.White;
            RdFiliados.Location = new Point(190, 194);
            RdFiliados.Name = "RdFiliados";
            RdFiliados.Size = new Size(65, 19);
            RdFiliados.TabIndex = 24;
            RdFiliados.Text = "Filiados";
            RdFiliados.UseVisualStyleBackColor = true;
            RdFiliados.Click += RdFiliados_Click;
            // 
            // RdDelegadoPartidario
            // 
            RdDelegadoPartidario.AutoSize = true;
            RdDelegadoPartidario.ForeColor = Color.White;
            RdDelegadoPartidario.Location = new Point(190, 172);
            RdDelegadoPartidario.Name = "RdDelegadoPartidario";
            RdDelegadoPartidario.Size = new Size(129, 19);
            RdDelegadoPartidario.TabIndex = 23;
            RdDelegadoPartidario.Text = "Delegado Partidario";
            RdDelegadoPartidario.UseVisualStyleBackColor = true;
            RdDelegadoPartidario.Click += RdDelegadoPartidario_Click;
            // 
            // RdMunZona2020
            // 
            RdMunZona2020.AutoSize = true;
            RdMunZona2020.ForeColor = Color.White;
            RdMunZona2020.Location = new Point(190, 147);
            RdMunZona2020.Name = "RdMunZona2020";
            RdMunZona2020.Size = new Size(119, 19);
            RdMunZona2020.TabIndex = 22;
            RdMunZona2020.Text = "Vt mun zona 2020";
            RdMunZona2020.UseVisualStyleBackColor = true;
            RdMunZona2020.Click += RdMunZona2020_Click;
            // 
            // RdMunZona2018
            // 
            RdMunZona2018.AutoSize = true;
            RdMunZona2018.ForeColor = Color.White;
            RdMunZona2018.Location = new Point(190, 122);
            RdMunZona2018.Name = "RdMunZona2018";
            RdMunZona2018.Size = new Size(119, 19);
            RdMunZona2018.TabIndex = 21;
            RdMunZona2018.Text = "Vt mun zona 2018";
            RdMunZona2018.UseVisualStyleBackColor = true;
            RdMunZona2018.Click += RdMunZona2018_Click;
            // 
            // RdPartidoMunZona2020
            // 
            RdPartidoMunZona2020.AutoSize = true;
            RdPartidoMunZona2020.ForeColor = Color.White;
            RdPartidoMunZona2020.Location = new Point(190, 97);
            RdPartidoMunZona2020.Name = "RdPartidoMunZona2020";
            RdPartidoMunZona2020.Size = new Size(143, 19);
            RdPartidoMunZona2020.TabIndex = 20;
            RdPartidoMunZona2020.Text = "Vt part mun zona 2020";
            RdPartidoMunZona2020.UseVisualStyleBackColor = true;
            RdPartidoMunZona2020.Click += RdPartidoMunZona2020_Click;
            // 
            // RdPartidoMunZona2018
            // 
            RdPartidoMunZona2018.AutoSize = true;
            RdPartidoMunZona2018.ForeColor = Color.White;
            RdPartidoMunZona2018.Location = new Point(190, 72);
            RdPartidoMunZona2018.Name = "RdPartidoMunZona2018";
            RdPartidoMunZona2018.Size = new Size(143, 19);
            RdPartidoMunZona2018.TabIndex = 19;
            RdPartidoMunZona2018.Text = "Vt part mun zona 2018";
            RdPartidoMunZona2018.UseVisualStyleBackColor = true;
            RdPartidoMunZona2018.Click += RdPartidoMunZona2018_Click;
            // 
            // RdBoletimUrna
            // 
            RdBoletimUrna.AutoSize = true;
            RdBoletimUrna.ForeColor = Color.White;
            RdBoletimUrna.Location = new Point(190, 47);
            RdBoletimUrna.Name = "RdBoletimUrna";
            RdBoletimUrna.Size = new Size(94, 19);
            RdBoletimUrna.TabIndex = 18;
            RdBoletimUrna.Text = "Boletim Urna";
            RdBoletimUrna.UseVisualStyleBackColor = true;
            RdBoletimUrna.Click += RdBoletimUrna_Click;
            // 
            // RdMunZona
            // 
            RdMunZona.AutoSize = true;
            RdMunZona.ForeColor = Color.White;
            RdMunZona.Location = new Point(18, 169);
            RdMunZona.Name = "RdMunZona";
            RdMunZona.Size = new Size(109, 19);
            RdMunZona.TabIndex = 17;
            RdMunZona.Text = "Municipio Zona";
            RdMunZona.UseVisualStyleBackColor = true;
            RdMunZona.Click += RdMunZona_Click;
            // 
            // RdCand2018
            // 
            RdCand2018.AutoSize = true;
            RdCand2018.ForeColor = Color.White;
            RdCand2018.Location = new Point(18, 216);
            RdCand2018.Name = "RdCand2018";
            RdCand2018.Size = new Size(109, 19);
            RdCand2018.TabIndex = 16;
            RdCand2018.Text = "Candidatos2018";
            RdCand2018.UseVisualStyleBackColor = true;
            RdCand2018.Click += RdCand2018_Click;
            // 
            // RdCandTelZap
            // 
            RdCandTelZap.AutoSize = true;
            RdCandTelZap.ForeColor = Color.White;
            RdCandTelZap.Location = new Point(190, 22);
            RdCandTelZap.Name = "RdCandTelZap";
            RdCandTelZap.Size = new Size(100, 19);
            RdCandTelZap.TabIndex = 15;
            RdCandTelZap.Text = "Cand. Tel/ZAP";
            RdCandTelZap.UseVisualStyleBackColor = true;
            RdCandTelZap.Click += RdCandTelZap_Click;
            // 
            // BtFechar
            // 
            BtFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtFechar.Cursor = Cursors.Hand;
            BtFechar.FlatAppearance.BorderSize = 0;
            BtFechar.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            BtFechar.FlatStyle = FlatStyle.Flat;
            BtFechar.ForeColor = Color.White;
            BtFechar.Image = Properties.Resources.exit;
            BtFechar.ImageAlign = ContentAlignment.MiddleLeft;
            BtFechar.Location = new Point(569, 319);
            BtFechar.Name = "BtFechar";
            BtFechar.Size = new Size(150, 35);
            BtFechar.TabIndex = 16;
            BtFechar.Text = "FECHAR";
            BtFechar.UseVisualStyleBackColor = true;
            BtFechar.Click += BtFechar_Click;
            // 
            // BtPararSQL
            // 
            BtPararSQL.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtPararSQL.Cursor = Cursors.Hand;
            BtPararSQL.FlatAppearance.BorderSize = 0;
            BtPararSQL.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            BtPararSQL.FlatStyle = FlatStyle.Flat;
            BtPararSQL.ForeColor = Color.White;
            BtPararSQL.Image = Properties.Resources.Untitled_1_fw;
            BtPararSQL.ImageAlign = ContentAlignment.MiddleLeft;
            BtPararSQL.Location = new Point(569, 362);
            BtPararSQL.Name = "BtPararSQL";
            BtPararSQL.Size = new Size(150, 35);
            BtPararSQL.TabIndex = 17;
            BtPararSQL.Text = "PARAR SQL";
            BtPararSQL.UseVisualStyleBackColor = true;
            BtPararSQL.Click += BtPararSQL_Click;
            // 
            // BtIniciarSQL
            // 
            BtIniciarSQL.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtIniciarSQL.Cursor = Cursors.Hand;
            BtIniciarSQL.FlatAppearance.BorderSize = 0;
            BtIniciarSQL.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 64);
            BtIniciarSQL.FlatStyle = FlatStyle.Flat;
            BtIniciarSQL.ForeColor = Color.White;
            BtIniciarSQL.Image = Properties.Resources.Untitled_11;
            BtIniciarSQL.ImageAlign = ContentAlignment.MiddleLeft;
            BtIniciarSQL.Location = new Point(569, 403);
            BtIniciarSQL.Name = "BtIniciarSQL";
            BtIniciarSQL.Size = new Size(150, 35);
            BtIniciarSQL.TabIndex = 18;
            BtIniciarSQL.Text = "INICIAR SQL";
            BtIniciarSQL.UseVisualStyleBackColor = true;
            BtIniciarSQL.Click += BtIniciarSQL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(569, 446);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 19;
            label2.Text = "AGUARDE...";
            // 
            // FrmSincronizar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(731, 477);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(BtIniciarSQL);
            Controls.Add(BtPararSQL);
            Controls.Add(BtFechar);
            Controls.Add(groupBox1);
            Controls.Add(LbProgresso);
            Controls.Add(TxResultado);
            Controls.Add(BtOK);
            Controls.Add(TreArquivo);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSincronizar";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmSincronizar_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private TreeView TreArquivo;
        private Button BtOK;
        private ImageList imageList1;
        private TextBox TxResultado;
        private RadioButton RdOriginal;
        private RadioButton RdCarlito;
        private RadioButton RdFotos;
        private RadioButton RdRedes;
        private RadioButton RdVotos;
        private RadioButton RdCandidatos;
        private Label LbProgresso;
        private RadioButton RdSecao;
        private GroupBox groupBox1;
        private Button BtFechar;
        private RadioButton RdCandTelZap;
        private RadioButton RdCand2018;
        private RadioButton RdMunZona;
        private Button BtPararSQL;
        private Button BtIniciarSQL;
        private Label label2;
        private RadioButton RdBoletimUrna;
        private RadioButton RdDelegadoPartidario;
        private RadioButton RdMunZona2020;
        private RadioButton RdMunZona2018;
        private RadioButton RdPartidoMunZona2020;
        private RadioButton RdPartidoMunZona2018;
        private RadioButton RdFiliados;
        private RadioButton RdGuarulhos;
    }
}