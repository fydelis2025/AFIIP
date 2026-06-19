using AFIIP_SINCRONIZADOR.BANCO.Classes;
using AFIIP_SINCRONIZADOR.BANCO.CONSULTAR;
using AFIIP_SINCRONIZADOR.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR.HOME
{
    public partial class FrmConsultar : Form
    {
        public FrmConsultar()
        {
            InitializeComponent();
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DgGrid.Rows.Clear();

                PAguarde.Visible = true;

                if(ChOriginal.Checked.Equals(false))
                {
                    if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancado(TxCidade.Text, TxBairro.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }

                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (TxDtNascimento.Text.Length != 4)
                            throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeUFDataNascimento(TxCidade.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {

                        if (TxDtNascimento.Text.Length != 4)
                            throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoUFDataNascimento(CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }

                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeBairroUF(TxCidade.Text, TxBairro.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }

                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();


                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeBairroUFSexoAniversarioAnsy(TxCidade.Text, TxBairro.Text, CbUF.Text, CbFlagTipo.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeUFSexoAnsy(TxCidade.Text, CbUF.Text, CbFlagTipo.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeBairroUFAniversarioAnsy(TxCidade.Text, TxBairro.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeUFDataNascimentoSexo(TxCidade.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)), CbFlagTipo.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoNomeCidade(TxCidade.Text, TxNome.Text, CbUF.Text);
                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(true) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeUFTelefone(TxCidade.Text, TxDDDFone.Text, CbUF.Text);
                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoNomeCidadeBairroSexo(TxCidade.Text, TxBairro.Text, CbFlagTipo.Text, TxNome.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoCidadeUFBairroSexo(TxCidade.Text, TxBairro.Text, CbFlagTipo.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoNome(TxCidade.Text, CbUF.Text, TxBairro.Text, TxNome.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoUFCidade(TxCidade.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxNome.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", TxNome.Text, "", "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(true) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCPFCNPJ.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", "", "", "", TxCPFCNPJ.Text, "", "", "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }

                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }

                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCidade.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", TxCidade.Text, "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", "", "", TxBairro.Text, "", "", "", "");

                        if (AFIIP_Parametros.Lista.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                            Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                            Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                            Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                            Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                            Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                            Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxDtNascimento.Text))
                        {
                            if (TxDtNascimento.Text.Length != 4)
                                throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosAvancadoDataNascimento(int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(true) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxDDDFone.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados(TxDDDFone.Text, "", "", "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbFlagTipo.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", "", "", "", "", "", CbFlagTipo.Text, "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbUF.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", "", CbUF.Text, "", "", "", "", "");

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(true) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbUF.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDados("", "", "", "", "", "", "", "", TxNIS.Text);

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(true))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCEP.Text))
                        {
                            AFIIP_Parametros.Lista = await Selecionar_Registro.FiltrarDadosCEP(TxCEP.Text);

                            if (AFIIP_Parametros.Lista.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista[i].DATANASCIMENTO.ToString("dd/MM/yyyy");
                                Parametro[4] = AFIIP_Parametros.Lista[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista[i].CPF_GOV_BR;
                                Parametro[9] = AFIIP_Parametros.Lista[i].NOME_GOV_BR;
                                Parametro[10] = AFIIP_Parametros.Lista[i].NOME_ELEITOR_TRE;
                                Parametro[11] = AFIIP_Parametros.Lista[i].TITULO_ELEITOR;
                                Parametro[12] = AFIIP_Parametros.Lista[i].ZONA.ToString();
                                Parametro[13] = AFIIP_Parametros.Lista[i].SECAO.ToString();

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista.Count.ToString();
                        }
                    }
                    else
                    {
                        throw new Exception("OPÇÃO INVÁLIDA");
                    }
                }
                else //ARQUIVO ORIGINAL
                {
                    if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancado(TxCidade.Text, TxBairro.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }

                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (TxDtNascimento.Text.Length != 4)
                            throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeUFDataNascimento(TxCidade.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {

                        if (TxDtNascimento.Text.Length != 4)
                            throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoUFDataNascimento(CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }

                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeBairroUF(TxCidade.Text, TxBairro.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }

                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();


                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeBairroUFSexoAniversarioAnsy(TxCidade.Text, TxBairro.Text, CbUF.Text, CbFlagTipo.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeUFSexoAnsy(TxCidade.Text, CbUF.Text, CbFlagTipo.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeBairroUFAniversarioAnsy(TxCidade.Text, TxBairro.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeUFDataNascimentoSexo(TxCidade.Text, CbUF.Text, int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)), CbFlagTipo.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoNomeCidade(TxCidade.Text, TxNome.Text, CbUF.Text);
                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(true) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeUFTelefone(TxCidade.Text, TxDDDFone.Text, CbUF.Text);
                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoNomeCidadeBairroSexo(TxCidade.Text, TxBairro.Text, CbFlagTipo.Text, TxNome.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoCidadeUFBairroSexo(TxCidade.Text, TxBairro.Text, CbFlagTipo.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoNome(TxCidade.Text, CbUF.Text, TxBairro.Text, TxNome.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[9];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(true) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoUFCidade(TxCidade.Text, CbUF.Text);

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(true) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxNome.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", TxNome.Text, "", "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(true) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCPFCNPJ.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", "", "", "", TxCPFCNPJ.Text, "", "", "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }

                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCidade.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", TxCidade.Text, "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(true) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", "", "", TxBairro.Text, "", "", "", "");

                        if (AFIIP_Parametros.Lista_Original.Count == 0)
                            throw new Exception("DADOS NÃO ENCONTRADO");

                        string[] Parametro = new string[14];

                        for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                        {
                            Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                            Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                            Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                            Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                            Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                            Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                            Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                            Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                            Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                            DgGrid.Rows.Add(Parametro);
                        }
                        PAguarde.Visible = false;
                        LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(true) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxDtNascimento.Text))
                        {
                            if (TxDtNascimento.Text.Length != 4)
                                throw new Exception("DATA DE NASCIMENTO NO FORMATO INVÁLIDO, FAVOR INFORMAR NO FORMATO ANOMES");

                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosAvancadoDataNascimento(int.Parse(TxDtNascimento.Text.Substring(0, 2)), int.Parse(TxDtNascimento.Text.Substring(2, 2)));

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(true) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(TxDDDFone.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados(TxDDDFone.Text, "", "", "", "", "", "", "", "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(true) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbFlagTipo.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", "", "", "", "", "", CbFlagTipo.Text, "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(true) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbUF.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", "", CbUF.Text, "", "", "", "", "");

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(true) && ChCep.Checked.Equals(false))
                    {
                        if (!String.IsNullOrWhiteSpace(CbUF.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDados("", "", "", "", "", "", "", "", TxNIS.Text);

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else if (ChCidade.Checked.Equals(false) && ChBairro.Checked.Equals(false) && ChCPFCNPJ.Checked.Equals(false) && ChCPFGOVBR.Checked.Equals(false) && ChUF.Checked.Equals(false) && ChNome.Checked.Equals(false) && ChDtNascimento.Checked.Equals(false) && ChDDDFone.Checked.Equals(false) && ChFlagTipo.Checked.Equals(false) && ChNIS.Checked.Equals(false) && ChCep.Checked.Equals(true))
                    {
                        if (!String.IsNullOrWhiteSpace(TxCEP.Text))
                        {
                            AFIIP_Parametros.Lista_Original = await Selecionar_Original.FiltrarDadosCEP(TxCEP.Text);

                            if (AFIIP_Parametros.Lista_Original.Count == 0)
                                throw new Exception("DADOS NÃO ENCONTRADO");

                            string[] Parametro = new string[14];

                            for (int i = 0; i < AFIIP_Parametros.Lista_Original.Count; i++)
                            {
                                Parametro[0] = AFIIP_Parametros.Lista_Original[i].FONE.ToString();
                                Parametro[1] = AFIIP_Parametros.Lista_Original[i].NOME;
                                Parametro[2] = AFIIP_Parametros.Lista_Original[i].SEXO;
                                Parametro[3] = AFIIP_Parametros.Lista_Original[i].DATANASCIMENTO;
                                Parametro[4] = AFIIP_Parametros.Lista_Original[i].CIDADE;
                                Parametro[5] = AFIIP_Parametros.Lista_Original[i].UF;
                                Parametro[6] = AFIIP_Parametros.Lista_Original[i].BAIRRO;
                                Parametro[7] = AFIIP_Parametros.Lista_Original[i].CPF;
                                Parametro[8] = AFIIP_Parametros.Lista_Original[i].TITULO_ELEITOR;

                                DgGrid.Rows.Add(Parametro);
                            }
                            PAguarde.Visible = false;
                            LbTotal.Text = AFIIP_Parametros.Lista_Original.Count.ToString();
                        }
                    }
                    else
                    {
                        throw new Exception("OPÇÃO INVÁLIDA");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PAguarde.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Pergunta = MessageBox.Show("DESEJA EXPORTAR O ARQUIVO PARA CSV?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Pergunta == DialogResult.Yes)
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + "\\ARQUIVOTXT\\"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\ARQUIVOTXT\\");
                    }

                    FileIOPermission f = new FileIOPermission(PermissionState.None);
                    f.AllLocalFiles = FileIOPermissionAccess.Read;

                    f.Demand();

                    String Caminho = Environment.CurrentDirectory + "\\ARQUIVOTXT\\" + DateTime.Now.ToString("dd_mm_yyyy_hh_MM_ss") + ".csv";

                    StreamWriter arquivo = new StreamWriter(Caminho);

                    for (int r = 0; r < DgGrid.Rows.Count; r++)
                    {
                        arquivo.WriteLine(DgGrid.Rows[r].Cells[1].Value.ToString() + ";" + DgGrid.Rows[r].Cells[0].Value.ToString() + ";" + DgGrid.Rows[r].Cells[5].Value.ToString() + ";" + DgGrid.Rows[r].Cells[4].Value.ToString() + ";" + DgGrid.Rows[r].Cells[6].Value.ToString() + ";" + DgGrid.Rows[r].Cells[7].Value.ToString() + ";" + DgGrid.Rows[r].Cells[3].Value.ToString());
                    }

                    arquivo.Close();

                    MessageBox.Show("ARQUIVO GERADO COM SUCESSO", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxDtNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxDDDFone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChCPFCNPJ_Click(object sender, EventArgs e)
        {
            if (ChCPFCNPJ.Checked)
            {
                TxCPFCNPJ.Enabled = true;
                TxCPFCNPJ.Focus();
            }
            else
            {
                TxCPFCNPJ.ResetText();
                TxCPFCNPJ.Enabled = false;
            }
        }

        private void ChCPFGOVBR_Click(object sender, EventArgs e)
        {

        }

        private void ChUF_Click(object sender, EventArgs e)
        {
            if (ChUF.Checked)
            {
                CbUF.Enabled = true;
                CbUF.Focus();
            }
            else
            {
                CbUF.Enabled = false;
            }
        }

        private void ChCidade_Click(object sender, EventArgs e)
        {
            if (ChCidade.Checked)
            {
                TxCidade.Enabled = true;
                TxCidade.Focus();
            }
            else
            {
                TxCidade.ResetText();
                TxCidade.Enabled = false;
            }
        }

        private void ChBairro_Click(object sender, EventArgs e)
        {
            if (ChBairro.Checked)
            {
                TxBairro.Enabled = true;
                TxBairro.Focus();
            }
            else
            {
                TxBairro.ResetText();
                TxBairro.Enabled = false;
            }
        }

        private void ChNome_Click(object sender, EventArgs e)
        {
            if (ChNome.Checked)
            {
                TxNome.Enabled = true;
                TxNome.Focus();
            }
            else
            {
                TxNome.ResetText();
                TxNome.Enabled = false;
            }
        }

        private void ChDtNascimento_Click(object sender, EventArgs e)
        {
            if (ChDtNascimento.Checked)
            {
                TxDtNascimento.Enabled = true;
                TxDtNascimento.Focus();
            }
            else
            {
                TxDtNascimento.ResetText();
                TxDtNascimento.Enabled = false;
            }
        }

        private void ChDDDFone_Click(object sender, EventArgs e)
        {
            if (ChDDDFone.Checked)
            {
                TxDDDFone.Enabled = true;
                TxDDDFone.Focus();

            }
            else
            {
                TxDDDFone.ResetText();
                TxDDDFone.Enabled = false;
            }
        }

        private void ChFlagTipo_Click(object sender, EventArgs e)
        {
            if (ChFlagTipo.Checked)
            {
                CbFlagTipo.Enabled = true;
                CbFlagTipo.Focus();
            }
            else
            {
                CbFlagTipo.Text = "";
                CbFlagTipo.Enabled = false;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmConsultar_Load(object sender, EventArgs e)
        {
            try
            {
                LbTotalBD.Text = Convert.ToString(await Selecionar_Registro.SelecionarTotalRegistroCompleto());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            DgGrid.Rows.Clear();
        }

        private void ChNIS_Click(object sender, EventArgs e)
        {
            if (ChNIS.Checked)
            {
                TxNIS.Enabled = true;
                TxNIS.Focus();
            }
            else
            {
                TxNIS.Text = "";
                TxNIS.Enabled = false;
            }
        }

        private void ChCampoCNPJ_Click(object sender, EventArgs e)
        {
            TxCPFCNPJ.Mask = "############-##";
        }

        private void ChCampoCPF_Click(object sender, EventArgs e)
        {
            TxCPFCNPJ.Mask = "#########-##";
        }

        private void ChCep_Click(object sender, EventArgs e)
        {
            if (ChCep.Checked)
            {
                TxCEP.Enabled = true;
                TxCEP.Focus();
            }
            else
            {
                TxCEP.Text = "";
                TxCEP.Enabled = false;
            }
        }
    }
}
