namespace AFIIP_SINCRONIZADOR
{
    partial class Form4
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
            PnlChildForm = new Panel();
            LbData = new Label();
            label1 = new Label();
            Progresso = new ProgressBar();
            BK = new System.ComponentModel.BackgroundWorker();
            PnlChildForm.SuspendLayout();
            SuspendLayout();
            // 
            // PnlChildForm
            // 
            PnlChildForm.BackColor = Color.FromArgb(32, 30, 45);
            PnlChildForm.BackgroundImage = Properties.Resources.logoincipsistemas;
            PnlChildForm.BackgroundImageLayout = ImageLayout.Center;
            PnlChildForm.Controls.Add(LbData);
            PnlChildForm.Controls.Add(label1);
            PnlChildForm.Controls.Add(Progresso);
            PnlChildForm.Dock = DockStyle.Fill;
            PnlChildForm.Location = new Point(0, 0);
            PnlChildForm.Name = "PnlChildForm";
            PnlChildForm.Size = new Size(800, 450);
            PnlChildForm.TabIndex = 4;
            // 
            // LbData
            // 
            LbData.ForeColor = Color.White;
            LbData.Location = new Point(287, 91);
            LbData.Name = "LbData";
            LbData.Size = new Size(198, 23);
            LbData.TabIndex = 2;
            LbData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(274, 44);
            label1.Name = "label1";
            label1.Size = new Size(211, 32);
            label1.TabIndex = 1;
            label1.Text = "SEJA BEM VINDO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Progresso
            // 
            Progresso.ForeColor = Color.Yellow;
            Progresso.Location = new Point(274, 292);
            Progresso.Name = "Progresso";
            Progresso.Size = new Size(297, 23);
            Progresso.Style = ProgressBarStyle.Continuous;
            Progresso.TabIndex = 0;
            // 
            // BK
            // 
            BK.WorkerReportsProgress = true;
            BK.WorkerSupportsCancellation = true;
            BK.DoWork += BK_DoWork;
            BK.ProgressChanged += BK_ProgressChanged;
            BK.RunWorkerCompleted += BK_RunWorkerCompleted;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(PnlChildForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SPLASH";
            Load += Form4_Load;
            Shown += Form4_Shown;
            PnlChildForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlChildForm;
        private ProgressBar Progresso;
        private System.ComponentModel.BackgroundWorker BK;
        private Label LbData;
        private Label label1;
    }
}