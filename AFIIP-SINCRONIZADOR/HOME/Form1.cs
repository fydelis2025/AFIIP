using AFIIP_SINCRONIZADOR.BANCO.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR.HOME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<CSVCOMPLETO> tablecarlito = null;
        private List<CSVNUMERO> tablecarlitoNumero = null;
        private String _NomeOriginal = String.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LbTotalRegistro.Text = "0";

                DgConsulta.Rows.Clear();

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "CSV (*.csv)|*.csv";
                openFile.Title = "ARQUIVOS CSV";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    _NomeOriginal = openFile.SafeFileName;
                    PAguarde.Visible = true;

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
                LbTotalRegistro.Text = DgConsulta.Rows.Count.ToString();
                PAguarde.Visible = false;
            }
        }

        StreamWriter CriarCSV;
        String _Arquivo;
        int contador;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                contador = 0;

                if (!Directory.Exists(Environment.CurrentDirectory + "\\CHK-BUK-FP"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\CHK-BUK-FP");

                OpenFileDialog openFileNumero = new OpenFileDialog();
                openFileNumero.Filter = "CSV (*.csv)|*.csv";
                openFileNumero.Title = "ARQUIVO SECUNDÁRIO CSV";

                CriarCSV = new StreamWriter(Environment.CurrentDirectory + "\\" + _NomeOriginal + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".csv", true, Encoding.ASCII);

                if (openFileNumero.ShowDialog() == DialogResult.OK)
                {
                    PAguarde.Visible = true;

                    using (StreamReader sr = new StreamReader(openFileNumero.FileName, Encoding.UTF8, true, 512))
                    {
                        string strLine = sr.ReadLine();

                        string[] strArray = strLine.Split(';');

                        while (sr.Peek() >= 0)
                        {
                            strLine = sr.ReadLine();
                            strArray = strLine.Replace("\"", " ").Split(';');
                            IEnumerable<CSVNUMERO> _tabelacarlitoNum =
                            from bolsapgto in strArray
                                //where strArray[1].Trim() == CbUF.Text.Remove(2)
                            select new CSVNUMERO
                            {
                                NOME = strArray[0].ToString().Trim(),
                                DDDFone = strArray[1].ToString(),
                            };

                            tablecarlitoNumero = _tabelacarlitoNum.ToList();

                            int processa = 1;
                            foreach (var _auxilio in tablecarlitoNumero)
                            {
                                if (processa.Equals(1))
                                {
                                    foreach(DataGridViewRow rows in DgConsulta.Rows)
                                    {
                                        if (_auxilio.DDDFone == rows.Cells[15].Value.ToString())
                                        {
                                            _Arquivo = rows.Cells[0].Value.ToString() + ";" + rows.Cells[1].Value.ToString() + ";" + rows.Cells[2].Value.ToString() + ";" + rows.Cells[3].Value.ToString() + ";" + rows.Cells[4].Value.ToString() + ";" + rows.Cells[5].Value.ToString() + ";" + rows.Cells[6].Value.ToString() + ";" + rows.Cells[7].Value.ToString() + ";" + rows.Cells[8].Value.ToString() + ";" + rows.Cells[9].Value.ToString() + ";" + rows.Cells[10].Value.ToString() + ";" + rows.Cells[11].Value.ToString() + ";" + rows.Cells[12].Value.ToString() + ";" + rows.Cells[13].Value.ToString() + ";" + rows.Cells[14].Value.ToString() + ";" + rows.Cells[15].Value.ToString() + ";" + rows.Cells[16].Value.ToString() + ";" + rows.Cells[17].Value.ToString() + ";" + rows.Cells[18].Value.ToString() + ";" + rows.Cells[19].Value.ToString() + ";" + rows.Cells[20].Value.ToString() + ";" + rows.Cells[21].Value.ToString() + ";" + rows.Cells[22].Value.ToString() + ";" + rows.Cells[23].Value.ToString() + ";" + rows.Cells[24].Value.ToString();

                                            CriarCSV.WriteLine(_Arquivo);

                                            contador = contador + 1;
                                        }
                                    }
                                    
                                }

                                processa = processa + 1;

                            }

                            
                        }

                        MessageBox.Show("LEITURA REALIZADA COM SUCESSO", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CriarCSV.Close();
                LbEncontrado.Text = contador.ToString();
                PAguarde.Visible = false;
            }
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
