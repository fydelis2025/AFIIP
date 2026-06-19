using AFIIP_SINCRONIZADOR.BANCO.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void BK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Hide();
                Form5 logon = new Form5();
                logon.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BK_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Progresso.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BK_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Delay(50).Wait();

                    BK.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {

                BK.RunWorkerAsync(0);

                if (!File.Exists(Environment.CurrentDirectory + "\\incip.ini"))
                    throw new Exception("FALHA AO EXECUTAR O APLICATIVO, ARQUIVO (INCIP.INI) ESTA FALTANDO");

                //File.Decrypt(Environment.CurrentDirectory + "\\incip.ini");

                string[] p = Directory.GetLogicalDrives();

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Equals("AFIIP-SINCRONIZADOR"))
                    {
                        if (Process.GetProcessesByName(process.ProcessName).Count() > 1)
                        {
                            MessageBox.Show("APLICATIVO JA EM EXECUÇÃO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            process.CloseMainWindow();
                        }

                    }
                }

                LbData.Text = DateTime.Now.ToLongDateString().ToUpper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            try
            {
                Boolean BancoAtivo = Boolean.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "BANCOSQL", ""));

                String Host = String.Empty, DataBase = String.Empty, Usuario = String.Empty, Senha = String.Empty, Script = String.Empty;
                int Timeout = 0, LimiteConexao = 0;
                
                Host = INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "HOST", "");
                DataBase = INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "DATABASE", "");
                Usuario = INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "USUARIO", "");
                Senha = Criptografia.Descripto(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "SENHA", ""));
                Timeout = int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMEOUT", ""));
                LimiteConexao = int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "LIMITECONEXAO", ""));

                Script = "Server=" + Host + ";Database=" + DataBase + ";User Id=" + Usuario + ";Password=" + Senha + ";Max Pool Size=" + LimiteConexao + ";";

                INI.gravaarquivoini("BANCO", "SQLSERVER", Criptografia.Encripta(Script));

            }
            catch
            {

            }
        }
    }
}
