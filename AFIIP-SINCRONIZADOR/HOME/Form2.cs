using AFIIP_SINCRONIZADOR.BANCO.Classes;
using AFIIP_SINCRONIZADOR.Classes;
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
    public partial class Form2 : Form
    {
        private List<PRINCIPAL> tablecarlito;
        private List<Secundario> tabsecundario;
        private int contador;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DgCEP.Rows.Clear();

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "CSV (*.csv)|*.csv";
                openFile.Title = "ARQUIVOS CSV";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PAguarde.Visible = true;

                    using (StreamReader sr = new StreamReader(openFile.FileName, Encoding.UTF8, true, 512))
                    {
                        string strLine = sr.ReadLine();

                        string[] strArray = strLine.Split(';');

                        while (sr.Peek() >= 0)
                        {
                            contador = contador + 1;

                            strLine = sr.ReadLine();
                            strArray = strLine.Replace("\"", " ").Split(';');

                            IEnumerable<PRINCIPAL> pRINCIPALs =
                            from bolsapgto in strArray
                                //where strArray[1].Trim() == CbUF.Text.Remove(2)
                            select new PRINCIPAL
                            {
                                UF = strArray[0].ToString(),
                                MUNICIPIO = strArray[1].ToString().Trim(),
                                BAIRRO = strArray[2].ToString(),
                                ENDERECO = strArray[3].ToString(),
                                CEP = strArray[4].ToString(),
                            };

                            tablecarlito = pRINCIPALs.ToList();

                            //Progress.Maximum = pRINCIPALs.Count();

                            int processa = 1;
                            foreach (var _auxilio in tablecarlito)
                            {
                                if (processa.Equals(1))
                                {
                                    LbLeitura.Text = contador.ToString();
                                    DgCEP.Rows.Add(_auxilio.UF.ToUpper(), _auxilio.MUNICIPIO.ToUpper(), _auxilio.BAIRRO.ToUpper(), _auxilio.ENDERECO.ToUpper(), _auxilio.CEP);
                                }

                                processa = processa + 1;

                            }
                        }
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

        StreamWriter CriarCSV;
        String _Arquivo;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                contador = 0;

                if (!Directory.Exists(Environment.CurrentDirectory + "\\CEP"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\CEP");

                OpenFileDialog openFileNumero = new OpenFileDialog();
                openFileNumero.Filter = "CSV (*.csv)|*.csv";
                openFileNumero.Title = "ARQUIVO SECUNDÁRIO CSV";

                CriarCSV = new StreamWriter(Environment.CurrentDirectory + "\\CEP\\" +openFileNumero.FileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".csv", true, Encoding.ASCII);

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

                            IEnumerable<Secundario> _tabelaseund =
                            from bolsapgto in strArray
                                //where strArray[1].Trim() == CbUF.Text.Remove(2)
                            select new Secundario
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

                            tabsecundario = _tabelaseund.ToList();

                            int processa = 1;
                            foreach (var _auxilio in _tabelaseund)
                            {
                                if (processa.Equals(1))
                                {
                                    foreach (DataGridViewRow rows in DgCEP.Rows)
                                    {
                                        if (_auxilio.CEP == rows.Cells[4].Value.ToString())
                                        {
                                            CriarCSV.WriteLine(_auxilio.CODIGO + ";" + _auxilio.CPF + ";" + _auxilio.DDD + ";" + _auxilio.FONE + ";" + _auxilio.TIPO_TELEFONE + ";" + _auxilio.NOME.ToUpper() + ";" + rows.Cells[3].Value.ToString().ToUpper() + ";" + _auxilio.NUM + ";" + _auxilio.COMPL.ToUpper() + ";" + rows.Cells[2].Value.ToString().ToUpper() + ";" + rows.Cells[1].Value.ToString().ToUpper() + ";" + rows.Cells[0].Value.ToString().ToUpper() + ";" + rows.Cells[4].Value.ToString().ToUpper() + ";" + _auxilio.SEXO.ToUpper() + ";" + _auxilio.OP.ToUpper() + ";" + _auxilio.DDDFone + ";" + _auxilio.FLAGWHATS + ";" + _auxilio.EMAIL + ";" + _auxilio.DATANASCIMENTO + ";" + _auxilio.NOMEMAE.ToUpper() + ";" + _auxilio.NOMERECEITA.ToUpper() + ";" + _auxilio.ESTCIV.ToUpper() + ";" + _auxilio.CBO + ";" + _auxilio.RENDA + ";" + _auxilio.FAIXA_RENDA_ID + ";" + _auxilio.TITULO_ELEITOR);
                                        }
                                    }
                                }

                                processa = processa + 1;
                            }

                        }
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
                MessageBox.Show("FIM DO PROCESSO", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PAguarde.Visible = false;
            }
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
