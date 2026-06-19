using AFIIP_SINCRONIZADOR.BANCO.Classes;
using AFIIP_SINCRONIZADOR.CADASTRO;
using AFIIP_SINCRONIZADOR.HOME;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Policy;
using XAct;

namespace AFIIP_SINCRONIZADOR
{
    public partial class Form1 : Form
    {
        int X = 0;
        int Y = 0;
        public Form1()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            PnlHome.Visible = false;
            PnlCadastro.Visible = false;
        }

        private Form activeForm;
        private void OpenChildForm( Form child)
        {

            if (activeForm != null)
                activeForm.Close();

                activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                PnlChildForm.Controls.Add(child);
                PnlChildForm.Tag = child;
                child.BringToFront();
                child.Show();
            
        }
        private void HideSubMenu()
        {
            if(PnlHome.Visible == true) 
                PnlHome.Visible = false;
            if (PnlCadastro.Visible == true)
                PnlCadastro.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == true)
            {
                HideSubMenu();
                subMenu.Visible = false;
            }
            else
            {
                
                subMenu.Visible = true;
            }
        }
        private void BtFechar_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BarraTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void BarraTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if(PlLeft.Size.Width == 250)
                {
                    PlLeft.Width = 50;
                }
                else
                {
                    PlLeft.Width = 250;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtHome_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlHome);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSincronizar());
            HideSubMenu();
        }

        private void BtCadastro_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlCadastro);
        }

        private void BtConsultar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmConsultar());
            HideSubMenu();
        }

        private void BtVerificarBanco_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HOME.Form2());
            HideSubMenu();
        }

        private void BtWhatsapp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HOME.Form1());
            HideSubMenu();
        }

        private void BtURL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmURL());
            HideSubMenu();
        }

        private void BtOrgao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmOrgao());
            HideSubMenu();
        }

        private void BtEntidades_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtInformacao_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void PnLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void PnLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form2());
            HideSubMenu();
        }

        private void BtConfiguracao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3());
            HideSubMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LbData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");

            disk.Get();
            LbSerie.Text = disk["VolumeSerialNumber"].ToString();
            LbPC.Text = Environment.MachineName;
            //LbUsuario.Text = Environment.UserName;

            if (!Directory.Exists(Environment.CurrentDirectory + "\\ARQUIVOEXCEL\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\ARQUIVOEXCEL\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\ARQUIVOORIGINAL\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\ARQUIVOORIGINAL\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\ARQUIVOTXT\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\ARQUIVOTXT\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS");

            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FOTOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FOTOS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\REDESOCIAIS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\REDESOCIAIS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOVOTO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOVOTO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOZONA"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOZONA");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\TELZAP"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\TELZAP");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\SECAO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\SECAO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\BOLETIMURNA"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\BOLETIMURNA");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2018"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2018");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2020"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2020");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DELEGADOPARTIDARIO"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DELEGADOPARTIDARIO");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FILIADOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FILIADOS");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\GUARULHOS"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\GUARULHOS");

        }

        private void PnLogo_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void PnLogo_Click(object sender, EventArgs e)
        {
            try
            {
                String url = "http://www.afiip.com.br";

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HOME.Form3());
            HideSubMenu();
        }

        private void BtZap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ZAP.Form1());
            HideSubMenu();
        }
    }
}