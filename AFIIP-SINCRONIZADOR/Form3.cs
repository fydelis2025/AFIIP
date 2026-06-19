using AFIIP_SINCRONIZADOR.BANCO.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            Application.Restart();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                Configuracao config = new Configuracao();
                PropConfig.SelectedObject = config;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PropConfig_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                DialogResult _pergunta = MessageBox.Show("DESEJA REALMENTE ALTERAR A CONFIGURAÇÃO " + e.ChangedItem.Value.ToString(), "ALTERAR CONFIGURAÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (e.ChangedItem.Label.Equals("TIMEOUT"))
                {
                    if(_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "TIMEOUT", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                        
                    }
                }

                if (e.ChangedItem.Label.Equals("USUARIOPC"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("GERAL", "USUARIOPC", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("NOMEPC"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("GERAL", "NOMEPC", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("SQLSERVER"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "SQLSERVER", Criptografia.Encripta(e.ChangedItem.Value.ToString()));
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("SERVIDOR"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("GERAL", "SERVIDOR", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("CAMINHODESTINO"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("GERAL", "CAMINHODESTINO", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("TIMERCOPYARQUIVO"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "TIMERCOPYARQUIVO", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("HOST"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "HOST", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("DATABASE"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "DATABASE", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("USUARIO"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "USUARIO", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("SENHA"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "SENHA", Criptografia.Encripta(e.ChangedItem.Value.ToString()));
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("TIMERINSERT"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "TIMERINSERT", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("TIMERINSERT"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "TIMERINSERT", e.ChangedItem.Value.ToString());
                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("BANCO"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "BANCOSQL", e.ChangedItem.Value.ToString());

                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");

                            
                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (e.ChangedItem.Label.Equals("PROTOCOLTSL"))
                {
                    if (_pergunta == DialogResult.Yes)
                    {
                        if (!String.IsNullOrWhiteSpace(e.ChangedItem.Value.ToString()))
                        {
                            INI.gravaarquivoini("BANCO", "PROTOCOLTSL", e.ChangedItem.Value.ToString());

                            MessageBox.Show("CONFIGURAÇÃO ATUALIZADA COM SUCESSO");


                        }
                        else
                        {
                            throw new Exception("NÃO É PERMITIDO NULO, FAVOR VERIFIQUE");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
