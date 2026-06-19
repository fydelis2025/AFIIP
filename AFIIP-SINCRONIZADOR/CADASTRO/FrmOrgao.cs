using AFIIP_SINCRONIZADOR.BANCO.CONSULTAR;
using AFIIP_SINCRONIZADOR.Classes;
using Extrator_Excel.Excluir;
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
    public partial class FrmOrgao : Form
    {
        public FrmOrgao()
        {
            InitializeComponent();
        }

        internal AFIIP_Orgao _criarOrgao;
        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmOrgao_Load(object sender, EventArgs e)
        {
            try
            {
                _criarOrgao = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_criarOrgao == null)
                {
                    _criarOrgao = new AFIIP_Orgao();
                    _criarOrgao.DESCRICAO = TxDescricao.Text;

                    int retorno = await Criar_RegistroCarlito.Criar_OrgaoAsync(_criarOrgao);

                    if(retorno != 0)
                    {
                        MessageBox.Show("DADOS INSERIDO COM SUCESSO");
                        _criarOrgao = null;
                        TxDescricao.ResetText();
                        TxDescricao.Focus();
                    }

                   
                }
                else
                {
                    _criarOrgao.DESCRICAO = TxDescricao.Text;
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

                AFIIP_Parametros._ListaOrgao = await Selecionar_Registro.FiltrarOrgaos();

                for (int i = 0; i < AFIIP_Parametros._ListaOrgao.Count; i++)
                {
                    DgGrid.Rows.Add(AFIIP_Parametros._ListaOrgao[i].DESCRICAO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DgGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.Equals(1))
                {
                    _criarOrgao = new AFIIP_Orgao();

                    TxDescricao.Text = DgGrid.CurrentRow.Cells[0].Value.ToString();

                    _criarOrgao.DESCRICAO = DgGrid.CurrentRow.Cells[0].Value.ToString();

                    TxDescricao.Focus();
                    
                }
                if (e.ColumnIndex.Equals(2))
                {
                    String _DescricaoOrgao = DgGrid.CurrentRow.Cells[0].Value.ToString();

                    DialogResult pergunta = MessageBox.Show("DESEJA EXCLUIR O ORGÃO -->"+ _DescricaoOrgao + " <-- ", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(pergunta == DialogResult.Yes)
                    {
                        int retorno = await Excluir_RegistroCarlito.Excluir_Orgao(_DescricaoOrgao);

                        if(retorno != 0)
                        {
                            MessageBox.Show("ORGÃO REMOVIDO COM SUCESSO");

                            DgGrid.Rows.Clear();

                            AFIIP_Parametros._ListaOrgao = await Selecionar_Registro.FiltrarOrgaos();

                            for (int i = 0; i < AFIIP_Parametros._ListaOrgao.Count; i++)
                            {
                                DgGrid.Rows.Add(AFIIP_Parametros._ListaOrgao[i].DESCRICAO);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TxDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (_criarOrgao == null)
                    {
                        _criarOrgao = new AFIIP_Orgao();
                        _criarOrgao.DESCRICAO = TxDescricao.Text;

                        int retorno = await Criar_RegistroCarlito.Criar_OrgaoAsync(_criarOrgao);

                        if (retorno != 0)
                        {
                            MessageBox.Show("DADOS INSERIDO COM SUCESSO");
                            TxDescricao.ResetText();
                            TxDescricao.Focus();
                        }
                    }
                    else
                    {
                        _criarOrgao.DESCRICAO = TxDescricao.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
