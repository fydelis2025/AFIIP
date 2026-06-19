using AFIIP_SINCRONIZADOR.BANCO.Classes;
using AFIIP_SINCRONIZADOR.BANCO.CONSULTAR;
using AFIIP_SINCRONIZADOR.Classes;
using Extrator_Excel.Inserir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR.CADASTRO
{
    public partial class FrmURL : Form
    {
        public FrmURL()
        {
            InitializeComponent();
        }

        internal AFIIP_URL _url;
        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DgGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.Equals(6))
                {
                    _url = new AFIIP_URL();

                    int codigouf = await Selecionar_Registro.ConsultarIDUF(DgGrid.CurrentRow.Cells[4].Value.ToString());

                    int retuf = CbUF.FindString(DgGrid.CurrentRow.Cells[4].Value.ToString());
                    CbUF.SelectedIndex = retuf;

                    List<CIDADES> cidades = await Selecionar_Registro.CidadesAsync(codigouf);

                    for (int i = 0; i < cidades.Count; i++)
                    {
                        CbMunicipio.Items.Add(cidades[i].DESCRICAO.ToUpper());
                    }

                    int retmun = CbMunicipio.FindString(DgGrid.CurrentRow.Cells[5].Value.ToString());
                    CbMunicipio.SelectedIndex = retmun;

                }

                if (e.ColumnIndex.Equals(7))
                {
                    DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE EXCLUIR A URL?","ATENÇÃO",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    
                    if(pergunta == DialogResult.Yes)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_url == null)
                {
                    _url = new AFIIP_URL();
                    _url.UF = Convert.ToString(await Selecionar_Registro.ConsultarIDUF(CbUF.Text));
                    _url.MUNICIPIO = Convert.ToString(await Selecionar_Registro.ConsultarIDCIDADE(CbMunicipio.Text));
                    _url.CODIGOIBGE = int.Parse(TxCodigoIBGE.Text);
                    _url.ORGAO = Convert.ToString(await Selecionar_Registro.ConsultarIDCIDADE(CbMunicipio.Text));
                    _url.TITULOBUSCA = TxTituloBusca.Text;
                    _url.URL = TxURL.Text;
                    _url.OBS = TxOBS.Text;

                    int retorno = await Criar_RegistroCarlito.Criar_URLAsync(_url);

                    if (retorno != 0)
                        MessageBox.Show("URL CRIADO COM SUCESSO");

                    _url = null;

                }
                else
                {
                    _url.UF = Convert.ToString(await Selecionar_Registro.ConsultarIDUF(CbUF.Text));
                    _url.MUNICIPIO = Convert.ToString(await Selecionar_Registro.ConsultarIDCIDADE(CbMunicipio.Text));
                    _url.CODIGOIBGE = int.Parse(TxCodigoIBGE.Text);
                    _url.ORGAO = Convert.ToString(await Selecionar_Registro.ConsultarIDCIDADE(CbMunicipio.Text));
                    _url.TITULOBUSCA = TxTituloBusca.Text;
                    _url.URL = TxURL.Text;
                    _url.OBS = TxOBS.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CbUF_Click(object sender, EventArgs e)
        {
            try
            {
                CbUF.Items.Clear();

                List<Estados> estados = await Selecionar_Registro.EstadosAsync();

                for (int i = 0; i < estados.Count; i++)
                {

                    CbUF.Items.Add(estados[i].DESCRICAO.ToUpper());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CbMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                CbMunicipio.Items.Clear();

                int codigouf = await Selecionar_Registro.ConsultarIDUF(CbUF.Text);

                List<CIDADES> cidades = await Selecionar_Registro.CidadesAsync(codigouf);

                for (int i = 0; i < cidades.Count; i++)
                {

                    CbMunicipio.Items.Add(cidades[i].DESCRICAO.ToUpper());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CbMunicipio_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int codigo = await Selecionar_Registro.ConsultarIDIBGE(CbMunicipio.Text);

                TxCodigoIBGE.Text = codigo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CbOrgao_Click(object sender, EventArgs e)
        {
            try
            {
                CbOrgao.Items.Clear();

                List<AFIIP_Orgao> _orgao = await Selecionar_Registro.ConsultarDESCRICAOORGAO();

                for (int i = 0; i < _orgao.Count; i++)
                {

                    CbOrgao.Items.Add(_orgao[i].DESCRICAO.ToUpper());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Boolean validaURL(String _url)
        {
            Uri Result;

            return Uri.TryCreate(_url,uriKind:UriKind.Absolute, out Result) && Result.Scheme == Uri.UriSchemeHttp;
        }
        private void TxURL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (validaURL(TxURL.Text))
                    {
                        TxOBS.Focus();
                    }
                    else
                    {
                        throw new Exception("URL INVÁLIDO");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DgGrid.Rows.Clear();

                if(ChUF.Checked.Equals(true) && ChMunicipio.Checked.Equals(false) && ChTituloBusca.Checked.Equals(false) && ChOrgao.Checked.Equals(false))
                {
                    List<AFIIP_URL> Lista = await Selecionar_Registro.FiltrarURLUF(CbUF.Text);

                    if (Lista.Count == 0)
                        throw new Exception("DADOS NÃO ENCONTRADO");

                    string[] param = new string[6];

                    for(int i = 0; i < Lista.Count; i++)
                    {
                        param[0] = Lista[i].ORGAO;
                        param[1] = Lista[i].TITULOBUSCA;
                        param[2] = Lista[i].URL;
                        param[3] = Lista[i].OBS;
                        param[4] = Lista[i].UF;
                        param[5] = Lista[i].MUNICIPIO;

                        DgGrid.Rows.Add(param);
                    }
                }
                else if (ChUF.Checked.Equals(true) && ChMunicipio.Checked.Equals(true) && ChTituloBusca.Checked.Equals(false) && ChOrgao.Checked.Equals(false))
                {
                    List<AFIIP_URL> Lista = await Selecionar_Registro.FiltrarURLUFMUNICIPIO(CbUF.Text, CbMunicipio.Text);

                    if (Lista.Count == 0)
                        throw new Exception("DADOS NÃO ENCONTRADO");

                    string[] param = new string[6];

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        param[0] = Lista[i].ORGAO;
                        param[1] = Lista[i].TITULOBUSCA;
                        param[2] = Lista[i].URL;
                        param[3] = Lista[i].OBS;
                        param[4] = Lista[i].UF;
                        param[5] = Lista[i].MUNICIPIO;

                        DgGrid.Rows.Add(param);
                    }
                }
                else if (ChUF.Checked.Equals(false) && ChMunicipio.Checked.Equals(false) && ChTituloBusca.Checked.Equals(true) && ChOrgao.Checked.Equals(false))
                {
                    List<AFIIP_URL> Lista = await Selecionar_Registro.FiltrarURLTITULOBUSCA(TxTituloBusca.Text);

                    if (Lista.Count == 0)
                        throw new Exception("DADOS NÃO ENCONTRADO");

                    string[] param = new string[6];

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        param[0] = Lista[i].ORGAO;
                        param[1] = Lista[i].TITULOBUSCA;
                        param[2] = Lista[i].URL;
                        param[3] = Lista[i].OBS;
                        param[4] = Lista[i].UF;
                        param[5] = Lista[i].MUNICIPIO;

                        DgGrid.Rows.Add(param);
                    }
                }
                else
                {
                    throw new Exception("OPÇÃO INVÁLIDA");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
