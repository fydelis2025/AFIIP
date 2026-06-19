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

namespace AFIIP_SINCRONIZADOR.HOME
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<CSVCOMPLETO> tablecarlito;
        private List<ConsultaCandidato> tablecandidato;
        private StreamWriter CriarCSV;
        private int contador;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DgConsulta.Rows.Clear();

                contador = 0;

                PAguarde.Visible = true;

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "CSV (*.csv)|*.csv";
                openFile.Title = "ARQUIVOS CSV";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFile.FileName, Encoding.UTF8, true, 512))
                    {
                        string strLine = sr.ReadLine();

                        string[] strArray = strLine.Split(';');

                        while (sr.Peek() >= 0)
                        {
                            strLine = sr.ReadLine();
                            strArray = strLine.Replace("\"", " ").Split(';');
                            IEnumerable<CSVCOMPLETO> _tabelacarlito =
                            from bolsapgto in strArray
                                //where strArray[1].Trim() == CbUF.Text.Remove(2)
                            select new CSVCOMPLETO
                            {
                                CODIGO = strArray[0].ToString(),
                                CPF = strArray[1].ToString().Trim(),
                                DDD = strArray[2].ToString(),
                                FONE = strArray[3].ToString(),
                                TIPO_TELEFONE = strArray[4].ToString().Trim(),
                                NOME = strArray[5].ToString().Trim(),
                                LOGRADOURO = strArray[6].ToString().Trim(),
                                NUM = strArray[7].ToString().Trim(),
                                COMPL = strArray[8].ToString().Trim(),
                                BAIRRO = strArray[9].ToString().Trim(),
                                CIDADE = strArray[10].ToString().Trim(),
                                UF = strArray[11].ToString().Trim(),
                                CEP = strArray[12].ToString(),
                                SEXO = strArray[13].ToString(),
                                OP = strArray[14].ToString(),
                                DDDFone = strArray[15].ToString(),
                                FLAGWHATS = strArray[16].ToString().Trim(),
                                EMAIL = strArray[17].ToString(),
                                DATANASCIMENTO = strArray[18].ToString(),
                                NOMEMAE = strArray[19].ToString(),
                                NOMERECEITA = strArray[20].ToString(),
                                ESTCIV = strArray[21].ToString(),
                                CBO = strArray[22].ToString(),
                                RENDA = strArray[23].ToString(),
                                FAIXA_RENDA_ID = strArray[24].ToString(),
                                TITULO_ELEITOR = strArray[25].ToString(),
                            };

                            tablecarlito = _tabelacarlito.ToList();

                            int processa = 1;
                            foreach (var _auxilio in tablecarlito)
                            {
                                if (processa.Equals(1))
                                {
                                    contador = contador + 1;

                                    DgConsulta.Rows.Add(_auxilio.CODIGO, _auxilio.CPF, _auxilio.DDD, _auxilio.FONE, _auxilio.TIPO_TELEFONE, _auxilio.NOME, _auxilio.LOGRADOURO, _auxilio.NUM, _auxilio.COMPL, _auxilio.BAIRRO, _auxilio.CIDADE, _auxilio.UF, _auxilio.CEP, _auxilio.SEXO, _auxilio.OP, _auxilio.DDDFone, _auxilio.FLAGWHATS, _auxilio.EMAIL, _auxilio.DATANASCIMENTO, _auxilio.NOMEMAE, _auxilio.NOMERECEITA, _auxilio.ESTCIV, _auxilio.RENDA, _auxilio.FAIXA_RENDA_ID, _auxilio.TITULO_ELEITOR);
                                }

                                processa = processa + 1;

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PAguarde.Visible = false;
                LbTotal.Text = contador.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                contador = 0;
                PAguarde.Visible = true;

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "CSV (*.csv)|*.csv";
                openFile.Title = "ARQUIVOS CSV";

                if(!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATO"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATO");

                CriarCSV = new StreamWriter(Environment.CurrentDirectory + "\\CANDIDATO\\" + "CANDIDATO" + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".csv", true, Encoding.ASCII);

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFile.FileName, Encoding.UTF8, true, 512))
                    {
                        string strLine = sr.ReadLine();

                        string[] strArray = strLine.Split(';');

                        while (sr.Peek() >= 0)
                        {
                            strLine = sr.ReadLine();
                            strArray = strLine.Replace("\"", " ").Split(';');
                            IEnumerable<ConsultaCandidato> _tabelacandidato =
                            from bolsapgto in strArray
                                //where strArray[1].Trim() == CbUF.Text.Remove(2)
                            select new ConsultaCandidato
                            {
                                ANO_ELEICAO = strArray[0].ToString(),
                                SG_UF = strArray[1].ToString().Trim(),
                                NM_UE = strArray[2].ToString(),
                                DS_CARGO = strArray[3].ToString(),
                                NM_CANDIDATO = strArray[4].ToString().Trim(),
                                NM_URNA_CANDIDATO = strArray[5].ToString().Trim(),
                                NR_CPF_CANDIDATO = strArray[6].ToString().Trim(),
                                NM_EMAIL = strArray[7].ToString().Trim(),
                                DS_COMPOSICAO_COLIGACAO = strArray[8].ToString().Trim(),
                                DT_NASCIMENTO = strArray[9].ToString().Trim(),
                                NR_IDADE_DATA_POSSE = strArray[10].ToString().Trim(),
                                NR_TITULO_ELEITORAL_CANDIDATO = strArray[11].ToString().Trim(),
                                DS_GRAU_INSTRUCAO = strArray[12].ToString(),
                                DS_ESTADO_CIVIL = strArray[13].ToString(),
                                DS_COR_RACA = strArray[14].ToString(),
                                DS_OCUPACAO = strArray[15].ToString(),
                            };

                            _tabelacandidato = _tabelacandidato.ToList();

                            int processa = 1;

                            foreach (var _auxilio in _tabelacandidato)
                            {
                                if (processa.Equals(1))
                                {
                                    foreach (DataGridViewRow rows in DgConsulta.Rows)
                                    {
                                        if (_auxilio.NR_CPF_CANDIDATO == rows.Cells[1].Value.ToString())
                                        {
                                            String fone = rows.Cells[15].Value.ToString();

                                            CriarCSV.WriteLine( _auxilio.ANO_ELEICAO + ";" + rows.Cells[15].Value.ToString() + ";" + _auxilio.SG_UF + ";" + _auxilio.NM_UE + ";" + _auxilio.DS_CARGO + ";" + _auxilio.NM_CANDIDATO + ";" + _auxilio.NM_URNA_CANDIDATO + ";" + _auxilio.NR_CPF_CANDIDATO + ";" + _auxilio.NM_EMAIL + ";" + _auxilio.DS_COMPOSICAO_COLIGACAO + ";" + _auxilio.DT_NASCIMENTO + ";" + _auxilio.NR_IDADE_DATA_POSSE + ";" + _auxilio.NR_TITULO_ELEITORAL_CANDIDATO + ";" + _auxilio.DS_GRAU_INSTRUCAO + ";" + _auxilio.DS_ESTADO_CIVIL + ";" + _auxilio.DS_COR_RACA + ";" + _auxilio.DS_OCUPACAO);

                                            contador = contador + 1;
                                        }
                                    }
                                }

                                processa = processa + 1;

                            }
                        }

                    }

                    MessageBox.Show("ARQUIVO GERADO COM SUCESSO", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PAguarde.Visible = false;
                CriarCSV.Close();
                LbEncontrado.Text = contador.ToString();
            }
        }
    }
}
