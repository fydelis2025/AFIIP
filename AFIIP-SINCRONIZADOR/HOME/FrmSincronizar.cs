using AFIIP_SINCRONIZADOR.BANCO.Classes;
using AFIIP_SINCRONIZADOR.BANCO.CONSULTAR;
using AFIIP_SINCRONIZADOR.BANCO.EXCLUIR;
using AFIIP_SINCRONIZADOR.BANCO.INSERIR;
using AFIIP_SINCRONIZADOR.Classes;
using Extrator_Excel.Excluir;
using Extrator_Excel.Inserir;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFIIP_SINCRONIZADOR.HOME
{
    public partial class FrmSincronizar : Form
    {
        public FrmSincronizar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSincronizar_Load(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                if (AFIIP_Parametros.directory.Exists)
                {
                    var rows = Enumerable.Range(0, AFIIP_Parametros.directory.GetFiles().Length);

                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(AFIIP_Parametros.files[i].Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtOK_Click(object sender, EventArgs e)
        {
            try                                                                                                                   
            {
                Boolean BancoAtivo = Boolean.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "BANCOSQL", ""));

                if (RdCarlito.Checked)
                {
                    BancoAtivo = true;

                    LogCarlito logcf = new LogCarlito();
                    DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (pergunta == DialogResult.Yes)
                    {
                        if (AFIIP_Parametros.directory.Exists)
                        {
                            var rows = Enumerable.Range(0, AFIIP_Parametros.directory.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                TxResultado.Text += "0" + Environment.NewLine;

                                if(BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                }
                                

                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = AFIIP_Parametros.files[i].Name;
                                    logcf.DATA = AFIIP_Parametros.files[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                    }

                                        
                                }
                                else
                                {

                                    TxResultado.Text += "------REVERTENDO AS INFORMAÇÕES DO ARQUIVO-----" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = AFIIP_Parametros.files[i].Name;
                                    logcf.DATA = AFIIP_Parametros.files[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.files[i].Name);
                                    }
                                        
                                }

                                TxResultado.Text += "INICIANDO LEITURA" + AFIIP_Parametros.files[i].Name + Environment.NewLine;

                                using (StreamReader sr = new StreamReader(AFIIP_Parametros.files[i].FullName, Encoding.UTF8, true, 512))
                                {

                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<Plan1> _tabelacarlito =
                                        from bolsapgto in strArray
                                            //where strArray[1].Trim() == CbUF.Text.Remove(2)
                                        select new Plan1
                                        {
                                            CODIGO = strArray[0].ToString(),
                                            CPF = strArray[1].ToString().Trim(),
                                            MODIF_CNPJCPF = strArray[2].ToString().Trim(),
                                            CPF_GOV_BR = strArray[3].ToString().Trim(),
                                            DDD = strArray[4].ToString(),
                                            FONE = strArray[5].ToString(),
                                            TIPO_TELEFONE = strArray[6].ToString().Trim(),
                                            NOME = strArray[7].ToString().Trim(),
                                            NOME_GOV_BR = strArray[8].ToString().Trim(),
                                            TOTAL_GOV_BR = strArray[9].ToString().Trim(),
                                            TIPO_BENEFCIO = strArray[10].ToString().Trim(),
                                            ANO_GOV_BR = strArray[11].ToString().Trim(),
                                            LOGRADOURO = strArray[12].ToString().Trim(),
                                            NUM = strArray[13].ToString().Trim(),
                                            COMPL = strArray[14].ToString().Trim(),
                                            BAIRRO = strArray[15].ToString().Trim(),
                                            CIDADE = strArray[16].ToString().Trim(),
                                            UF = strArray[17].ToString().Trim(),
                                            CEP = strArray[18].ToString(),
                                            SEXO = strArray[19].ToString(),
                                            OP = strArray[20].ToString(),
                                            DDDFone = strArray[21].ToString(),
                                            FLAGWHATS = strArray[22].ToString().Trim(),
                                            EMAIL = strArray[23].ToString(),
                                            DATANASCIMENTO = strArray[24].ToString(),
                                            NOMEMAE = strArray[25].ToString(),
                                            NOMERECEITA = strArray[26].ToString(),
                                            ESTCIV = strArray[27].ToString(),
                                            CBO = strArray[28].ToString(),
                                            RENDA = strArray[29].ToString(),
                                            FAIXA_RENDA_ID = strArray[30].ToString(),
                                            TITULO_ELEITOR = strArray[31].ToString(),
                                            NOME_ELEITOR_TRE = strArray[32].ToString(),
                                            ZONA = strArray[33].ToString(),
                                            SECAO = strArray[34].ToString().Trim()
                                        };

                                        LbProgresso.Text = "AGUARDE ...." + 0;

                                        List<Plan1> tablecarlito = _tabelacarlito.ToList();

                                        int processa = 1;
                                        foreach (var _auxilio in tablecarlito)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.Criar_Registro(_auxilio, AFIIP_Parametros.CodigoLog);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.Criar_Registro(_auxilio, AFIIP_Parametros.CodigoLog);
                                                }
                                                    

                                            }

                                            processa = processa + 1;

                                        }
                                    }

                                    TxResultado.Text += Convert.ToString(await Selecionar_Registro.SelecionarTotalRegistro(AFIIP_Parametros.CodigoLog)) + Environment.NewLine;

                                }

                                String caminho = Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\" + AFIIP_Parametros.files[i].Name;

                                if (!File.Exists(caminho))
                                    AFIIP_Parametros.files[i].CopyTo(Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\" + AFIIP_Parametros.files[i].Name);

                                AFIIP_Parametros.files[i].Delete();

                                if (AFIIP_Parametros.directory.Exists)
                                {
                                    var diretorio = Enumerable.Range(0, AFIIP_Parametros.directory.GetFiles().Length);

                                    foreach (var ro in diretorio)
                                    {
                                        TreArquivo.Nodes.Add(AFIIP_Parametros.files[ro].Name);
                                    }
                                }

                                Task.Delay(180000).Wait();
                                BancoAtivo = false;
                            }
                        }
                        else
                        {
                            throw new Exception("DIRETORIO (ARQUIVOEXCEL) NÃO ENCONTRADO, FAVOR VERIFIQUE");
                        }
                    }
                }

                if (RdOriginal.Checked)
                {
                    BancoAtivo = true;

                    LogCarlito logcf = new LogCarlito();
                    DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (pergunta == DialogResult.Yes)
                    {
                        if (AFIIP_Parametros.directoryOriginal.Exists)
                        {
                            var rows = Enumerable.Range(0, AFIIP_Parametros.directoryOriginal.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                TxResultado.Text += "0" + Environment.NewLine;

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = AFIIP_Parametros.filesOriginal[i].Name;
                                    logcf.DATA = AFIIP_Parametros.filesOriginal[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                    }


                                }
                                else
                                {

                                    TxResultado.Text += "------REVERTENDO AS INFORMAÇÕES DO ARQUIVO-----" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                      
                                    logcf.NOMEARQUIVO = AFIIP_Parametros.filesOriginal[i].Name;
                                    logcf.DATA = AFIIP_Parametros.filesOriginal[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(AFIIP_Parametros.filesOriginal[i].Name);
                                    }
                                        
                                }

                                TxResultado.Text += "INICIANDO LEITURA" + AFIIP_Parametros.filesOriginal[i].Name + Environment.NewLine;

                                using (StreamReader sr = new StreamReader(AFIIP_Parametros.filesOriginal[i].FullName, Encoding.UTF8, true, 512))
                                {

                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<Tabela_Original> _tabelacarlito =
                                        from bolsapgto in strArray
                                            //where strArray[1].Trim() == CbUF.Text.Remove(2)
                                        select new Tabela_Original
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

                                        LbProgresso.Text = "AGUARDE ...." + 0;

                                        List<Tabela_Original> tablecarlito = _tabelacarlito.ToList();

                                        int processa = 1;
                                        foreach (var _auxilio in tablecarlito)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.Criar_RegistroOriginal(_auxilio, AFIIP_Parametros.CodigoLog);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.Criar_RegistroOriginal(_auxilio, AFIIP_Parametros.CodigoLog);
                                                }

                                                    

                                            }

                                            processa = processa + 1;

                                        }
                                    }

                                    TxResultado.Text += Convert.ToString(await Selecionar_Registro.SelecionarTotalRegistro(AFIIP_Parametros.CodigoLog)) + Environment.NewLine;

                                }

                                String caminho = Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\" + AFIIP_Parametros.filesOriginal[i].Name;

                                if (!File.Exists(caminho))
                                    AFIIP_Parametros.filesOriginal[i].CopyTo(Environment.CurrentDirectory + "\\ARQUIVOFINALIZADO\\" + AFIIP_Parametros.filesOriginal[i].Name);

                                AFIIP_Parametros.filesOriginal[i].Delete();

                                if (AFIIP_Parametros.directoryOriginal.Exists)
                                {
                                    var diretorio = Enumerable.Range(0, AFIIP_Parametros.directoryOriginal.GetFiles().Length);

                                    foreach (var ro in diretorio)
                                    {
                                        TreArquivo.Nodes.Add(AFIIP_Parametros.filesOriginal[ro].Name);
                                    }
                                }

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                                BancoAtivo = false;
                            }
                        }
                        else
                        {
                            throw new Exception("DIRETORIO (ARQUIVOEXCEL) NÃO ENCONTRADO, FAVOR VERIFIQUE");
                        }
                    }
                }

                try
                {
                    if (RdFotos.Checked)
                    {
                        BancoAtivo = true;

                        LogCarlito logcf = new LogCarlito();
                        String NomeArquivo = String.Empty;
                        String CamninhoArquivo = Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS";
                        List<string> lstaarquivo = Directory.GetFiles(CamninhoArquivo, "*", System.IO.SearchOption.AllDirectories)
                                .Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)).ToList();

                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {

                            //DirectoryInfo directoryFOTOS = new DirectoryInfo(CamninhoArquivo);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS");

                            var rows = Enumerable.Range(0, lstaarquivo.Count);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                TxResultado.ResetText();

                                FileInfo info = new FileInfo(lstaarquivo[i].ToString());

                                LbProgresso.Text = "0";


                                if(BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(info.Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    
                                    TxResultado.Text += "CRIANDO ARQUIVO DE LOG" + Environment.NewLine;
                                    logcf.NOMEARQUIVO = info.Name;
                                    logcf.DATA = info.LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);
                                    }

                                        
                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = info.Name;
                                    logcf.DATA = info.LastWriteTime;
                                    logcf.FINALIZADO = false;


                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(info.Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(info.Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(info.FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;

                                    AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                    AFFIP_Fotos incip_Fotos = new AFFIP_Fotos();

                                    incip_Fotos.NOMEFOTO = info.Name;
                                    incip_Fotos.SQ_CANDIDATO = info.Name.Substring(3, 13).Replace("_d", "");
                                    incip_Fotos.FOTO = AFIIP_Parametros.GetPhoto(info.FullName);
                                    incip_Fotos.CAMINHOFOTO = info.FullName;
                                    incip_Fotos.UF = info.Name.Substring(1, 2);

                                    Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarFotos(incip_Fotos);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarFotos(incip_Fotos);
                                    }

                                        

                                    LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                    TxResultado.Text += "REGISTRO " + info.Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                }

                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (var i in rows)
                            {
                                FileInfo info = new FileInfo(lstaarquivo[i].ToString());

                                TxResultado.Text += "MOVENDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;

                                info.CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FOTOS\\" + info.Name);
                                //info.Delete();
                                TxResultado.Text += "ARQUIVOS " + info.Name + " MOVIDO COM SUCESSO" + Environment.NewLine;
                            }

                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                            BancoAtivo = false;

                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS\\*.jpg");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (RdRedes.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryREDESOCIAIS = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\");
                            FileInfo[] filesREDESOCIAIS = directoryREDESOCIAIS.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\");

                            var rows = Enumerable.Range(0, directoryREDESOCIAIS.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesREDESOCIAIS[i].Name;
                                    logcf.DATA = filesREDESOCIAIS[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    logcf.NOMEARQUIVO = filesREDESOCIAIS[i].Name;
                                    logcf.DATA = filesREDESOCIAIS[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesREDESOCIAIS[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesREDESOCIAIS[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_RedesSociais> _tabelarede = from _redesociais in strArray
                                                                                      select new AFIIP_RedesSociais
                                                                                      {
                                                                                          ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                          SQ_CANDIDATO = strArray[1].ToString().Trim(),
                                                                                          DS_URL = strArray[2].ToString().Trim(),
                                                                                      };

                                        List<AFIIP_RedesSociais> tabelaredesocial = _tabelarede.ToList();

                                        int processa = 1;
                                        foreach (var _redesocial in tabelaredesocial)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarRedeSociais(_redesocial);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarRedeSociais(_redesocial);
                                                }

                                                    
                                                //TxResultado.Text += "REGISTRO " + filesREDESOCIAIS[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesREDESOCIAIS[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\REDESOCIAIS\\" + filesREDESOCIAIS[i].Name);
                                filesREDESOCIAIS[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesREDESOCIAIS[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (RdVotos.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {

                            DirectoryInfo directoryVOTOMUNICIPIO = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO\\");
                            FileInfo[] filesVOTOMUNICIPIO = directoryVOTOMUNICIPIO.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO\\");

                            var rows = Enumerable.Range(0, directoryVOTOMUNICIPIO.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesVOTOMUNICIPIO[i].Name;
                                    logcf.DATA = filesVOTOMUNICIPIO[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    

                                    logcf.NOMEARQUIVO = filesVOTOMUNICIPIO[i].Name;
                                    logcf.DATA = filesVOTOMUNICIPIO[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                    

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesVOTOMUNICIPIO[i].Name);
                                    }
                                        
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesVOTOMUNICIPIO[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_VotoMunicipio> _tabelavoto = from _voto in strArray
                                                                                       select new AFIIP_VotoMunicipio
                                                                                       {
                                                                                           ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                           SG_UF = strArray[1].ToString().Trim(),
                                                                                           CD_MUNICIPIO = strArray[2].ToString().Trim(),
                                                                                           NM_MUNICIPIO = strArray[3].ToString().Trim(),
                                                                                           NR_ZONA = strArray[4].ToString().Trim(),
                                                                                           DS_CARGO = strArray[5].ToString().Trim(),
                                                                                           SQ_CANDIDATO = strArray[6].ToString().Trim(),
                                                                                           NR_CANDIDATO = strArray[7].ToString().Trim(),
                                                                                           NM_CANDIDATO = strArray[8].ToString().Trim(),
                                                                                           NM_URNA_CANDIDATO = strArray[9].ToString().Trim(),
                                                                                           DS_SITUACAO_CANDIDATURA = strArray[10].ToString().Trim(),
                                                                                           NR_PARTIDO = strArray[11].ToString().Trim(),
                                                                                           SG_PARTIDO = strArray[12].ToString().Trim(),
                                                                                           DS_COMPOSICAO_COLIGACAO = strArray[13].ToString().Trim(),
                                                                                           QT_VOTOS_NOMINAIS_VALIDOS = strArray[14].ToString().Trim(),
                                                                                           DS_SIT_TOT_TURNO = strArray[15].ToString().Trim(),
                                                                                       };

                                        List<AFIIP_VotoMunicipio> tabelavotomunicipio = _tabelavoto.ToList();

                                        int processa = 1;
                                        foreach (var _votomunicipio in tabelavotomunicipio)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarVotoMunicipio(_votomunicipio);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarVotoMunicipio(_votomunicipio);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesVOTOMUNICIPIO[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesVOTOMUNICIPIO[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOVOTO\\" + filesVOTOMUNICIPIO[i].Name);
                                filesVOTOMUNICIPIO[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesVOTOMUNICIPIO[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (RdSecao.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directorySecao = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO\\");
                            FileInfo[] filesSecao = directorySecao.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO\\");

                            var rows = Enumerable.Range(0, directorySecao.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesSecao[i].Name;
                                    logcf.DATA = filesSecao[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesSecao[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesSecao[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    logcf.NOMEARQUIVO = filesSecao[i].Name;
                                    logcf.DATA = filesSecao[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                    

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesSecao[i].Name);
                                    }
                                        
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesSecao[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Secao> _tabelaSecao = from _secao in strArray
                                                                                select new AFIIP_Secao
                                                                                {
                                                                                    ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                    SG_UF = strArray[1].ToString().Trim(),
                                                                                    SG_UE = strArray[2].ToString().Trim(),
                                                                                    NM_UE = strArray[3].ToString().Trim(),
                                                                                    CD_MUNICIPIO = strArray[4].ToString().Trim(),
                                                                                    NM_MUNICIPIO = strArray[5].ToString().Trim(),
                                                                                    NR_ZONA = Int32.Parse(strArray[6].ToString().Trim()),
                                                                                    NR_SECAO = Int32.Parse(strArray[7].ToString().Trim()),
                                                                                    CD_CARGO = Int32.Parse(strArray[8].ToString().Trim()),
                                                                                    DS_CARGO = strArray[9].ToString().Trim(),
                                                                                    QT_APTOS = Int32.Parse(strArray[10].ToString().Trim()),
                                                                                    QT_COMPARECIMENTO = Int32.Parse(strArray[11].ToString().Trim()),
                                                                                    QT_ABSTENCOES = Int32.Parse(strArray[12].ToString().Trim()),
                                                                                    QT_VOTOS_NOMINAIS = Int32.Parse(strArray[13].ToString().Trim()),
                                                                                    QT_VOTOS_BRANCOS = Int32.Parse(strArray[14].ToString().Trim()),
                                                                                    QT_VOTOS_NULOS = Int32.Parse(strArray[15].ToString().Trim()),
                                                                                    QT_VOTOS_LEGENDA = Int32.Parse(strArray[16].ToString().Trim()),
                                                                                    NR_LOCAL_VOTACAO = Int32.Parse(strArray[17].ToString().Trim())
                                                                                };

                                        List<AFIIP_Secao> tabelaSecao = _tabelaSecao.ToList();

                                        int processa = 1;
                                        foreach (var _Secao in tabelaSecao)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarSecao(_Secao);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarSecao(_Secao);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesSecao[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesSecao[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\SECAO\\" + filesSecao[i].Name);
                                filesSecao[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesSecao[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (RdCandidatos.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\2020\\");
                            FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\2020\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\2020\\");

                            var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesCandidato[i].Name;
                                    logcf.DATA = filesCandidato[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    

                                    logcf.NOMEARQUIVO = filesCandidato[i].Name;
                                    logcf.DATA = filesCandidato[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidato[i].Name);
                                    }

                                    
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesCandidato[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Candidatos> _tabelaCandidato = from _candidato in strArray
                                                                                         select new AFIIP_Candidatos
                                                                                         {
                                                                                             ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                             SG_UF = strArray[1].ToString().Trim(),
                                                                                             SG_UE = strArray[2].ToString().Trim(),
                                                                                             NM_UE = strArray[3].ToString().Trim(),
                                                                                             DS_CARGO = strArray[4].ToString().Trim(),
                                                                                             SQ_CANDIDATO = strArray[5].ToString().Trim(),
                                                                                             NR_CANDIDATO = strArray[6].ToString().Trim(),
                                                                                             NM_CANDIDATO = strArray[7].ToString().Trim(),
                                                                                             NM_URNA_CANDIDATO = strArray[8].ToString().Trim(),
                                                                                             NR_CPF_CANDIDATO = strArray[9].ToString().Trim(),
                                                                                             NM_EMAIL = strArray[10].ToString().Trim(),
                                                                                             DS_SITUACAO_CANDIDATURA = strArray[11].ToString().Trim(),
                                                                                             NR_PARTIDO = strArray[12].ToString().Trim(),
                                                                                             SG_PARTIDO = strArray[13].ToString().Trim(),
                                                                                             SQ_COLIGACAO = strArray[14].ToString().Trim(),
                                                                                             DS_COMPOSICAO_COLIGACAO = strArray[15].ToString().Trim(),
                                                                                             DT_NASCIMENTO = strArray[16].ToString().Trim(),
                                                                                             NR_IDADE_DATA_POSSE = strArray[17].ToString().Trim(),
                                                                                             NR_TITULO_ELEITORAL_CANDIDATO = strArray[18].ToString().Trim(),
                                                                                             DS_GENERO = strArray[19].ToString().Trim(),
                                                                                             DS_GRAU_INSTRUCAO = strArray[20].ToString().Trim(),
                                                                                             DS_ESTADO_CIVIL = strArray[21].ToString().Trim(),
                                                                                             DS_COR_RACA = strArray[22].ToString().Trim(),
                                                                                             DS_OCUPACAO = strArray[23].ToString().Trim(),
                                                                                             DS_SIT_TOT_TURNO = strArray[24].ToString().Trim(),
                                                                                             DS_SITUACAO_CANDIDATO_TOT = strArray[25].ToString().Trim(),
                                                                                         };

                                        List<AFIIP_Candidatos> tabelaCandidato = _tabelaCandidato.ToList();

                                        int processa = 1;
                                        foreach (var _Candidato in tabelaCandidato)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarCandidatos(_Candidato);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarCandidatos(_Candidato);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesCandidato[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesCandidato[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2020\\" + filesCandidato[i].Name);
                                filesCandidato[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesCandidato[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\2020\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (RdCand2018.Checked)
                    {

                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryCandidatos2018 = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\2018\\");
                            FileInfo[] filesCandidatos2018 = directoryCandidatos2018.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\2018\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\2018\\");

                            var rows = Enumerable.Range(0, directoryCandidatos2018.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesCandidatos2018[i].Name;
                                    logcf.DATA = filesCandidatos2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    

                                    logcf.NOMEARQUIVO = filesCandidatos2018[i].Name;
                                    logcf.DATA = filesCandidatos2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                    

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatos2018[i].Name);
                                    }
                                        
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesCandidatos2018[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Candidato2018> _tabelaCandidato = from _candidato in strArray
                                                                                            select new AFIIP_Candidato2018
                                                                                            {
                                                                                                ANO_ELEICAO = int.Parse(strArray[0].ToString().Trim()),
                                                                                                SG_UF = strArray[1].ToString().Trim(),
                                                                                                NM_UE = strArray[2].ToString().Trim(),
                                                                                                DS_CARGO = strArray[3].ToString().Trim(),
                                                                                                SQ_CANDIDATO = strArray[4].ToString().Trim(),
                                                                                                NR_CANDIDATO = strArray[5].ToString().Trim(),
                                                                                                NM_CANDIDATO = strArray[6].ToString().Trim(),
                                                                                                NM_URNA_CANDIDATO = strArray[7].ToString().Trim(),
                                                                                                NR_CPF_CANDIDATO = strArray[8].ToString().Trim(),
                                                                                                NM_EMAIL = strArray[9].ToString().Trim(),
                                                                                                DS_SITUACAO_CANDIDATURA = strArray[10].ToString().Trim(),
                                                                                                DS_DETALHE_SITUACAO_CAND = strArray[11].ToString().Trim(),
                                                                                                TP_AGREMIACAO = strArray[12].ToString().Trim(),
                                                                                                NR_PARTIDO = strArray[13].ToString().Trim(),
                                                                                                SG_PARTIDO = strArray[14].ToString().Trim(),
                                                                                                SQ_COLIGACAO = strArray[15].ToString().Trim(),
                                                                                                DS_COMPOSICAO_COLIGACAO = strArray[16].ToString().Trim(),
                                                                                                DT_NASCIMENTO = strArray[17].ToString().Trim(),
                                                                                                NR_IDADE_DATA_POSSE = strArray[18].ToString().Trim(),
                                                                                                NR_TITULO_ELEITORAL_CANDIDATO = strArray[19].ToString().Trim(),
                                                                                                DS_GENERO = strArray[20].ToString().Trim(),
                                                                                                DS_GRAU_INSTRUCAO = strArray[21].ToString().Trim(),
                                                                                                DS_ESTADO_CIVIL = strArray[22].ToString().Trim(),
                                                                                                DS_COR_RACA = strArray[23].ToString().Trim(),
                                                                                                DS_OCUPACAO = strArray[24].ToString().Trim(),
                                                                                                DS_SIT_TOT_TURNO = strArray[25].ToString().Trim(),
                                                                                                DS_SITUACAO_CANDIDATO_URNA = strArray[26].ToString().Trim()
                                                                                            };

                                        List<AFIIP_Candidato2018> tabelaCandidato = _tabelaCandidato.ToList();

                                        int processa = 1;
                                        foreach (var _Candidato in tabelaCandidato)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarCandidatos2018(_Candidato);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarCandidatos2018(_Candidato);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesCandidatoTELZAP[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesCandidatos2018[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\2018\\" + filesCandidatos2018[i].Name);
                                filesCandidatos2018[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesCandidatos2018[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\2018\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    if (RdCandTelZap.Checked)
                    {
                        BancoAtivo = true;


                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryCandidatoTELZAP = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP\\");
                            FileInfo[] filesCandidatoTELZAP = directoryCandidatoTELZAP.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP\\");

                            var rows = Enumerable.Range(0, directoryCandidatoTELZAP.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesCandidatoTELZAP[i].Name;
                                    logcf.DATA = filesCandidatoTELZAP[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesCandidatoTELZAP[i].Name;
                                    logcf.DATA = filesCandidatoTELZAP[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesCandidatoTELZAP[i].Name);
                                    }
                                        
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesCandidatoTELZAP[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_CandTelZap> _tabelaCandidato = from _candidato in strArray
                                                                                         select new AFIIP_CandTelZap
                                                                                         {
                                                                                             NOME_CANDIDATO = strArray[0].ToString().Trim(),
                                                                                             TELEZAP_CAND = strArray[1].ToString().Trim(),
                                                                                             UF = strArray[2].ToString().Trim(),
                                                                                             MUNICIPIO = strArray[3].ToString().Trim(),
                                                                                             BAIRRO_CAND = strArray[4].ToString().Trim(),
                                                                                             CPF_CAND = strArray[5].ToString().Trim(),
                                                                                             DT_NAS_CAND = strArray[6].ToString().Trim()
                                                                                         };

                                        List<AFIIP_CandTelZap> tabelaCandidato = _tabelaCandidato.ToList();

                                        int processa = 1;
                                        foreach (var _Candidato in tabelaCandidato)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarCandidatosTELZAP(_Candidato);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarCandidatosTELZAP(_Candidato);
                                                }

                                                    
                                                //TxResultado.Text += "REGISTRO " + filesCandidatoTELZAP[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }

                                }


                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesCandidatoTELZAP[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\TELZAP\\" + filesCandidatoTELZAP[i].Name);
                                filesCandidatoTELZAP[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesCandidatoTELZAP[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    if (RdMunZona.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryMunicipioZona = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA\\");
                            FileInfo[] filesMunicipioZona = directoryMunicipioZona.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA\\");

                            var rows = Enumerable.Range(0, directoryMunicipioZona.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesMunicipioZona[i].Name;
                                    logcf.DATA = filesMunicipioZona[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesMunicipioZona[i].Name;
                                    logcf.DATA = filesMunicipioZona[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunicipioZona[i].Name);
                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesMunicipioZona[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_MunicipioZona> _tabelaCandidato = from _candidato in strArray
                                                                                            select new AFIIP_MunicipioZona
                                                                                            {
                                                                                                ANO_ELEICAO = int.Parse(strArray[0].ToString().Trim()),
                                                                                                SG_UF = strArray[1].ToString().Trim(),
                                                                                                DS_CARGO = strArray[2].ToString().Trim(),
                                                                                                SQ_CANDIDATO = strArray[3].ToString().Trim(),
                                                                                                NR_CANDIDATO = strArray[4].ToString().Trim(),
                                                                                                NM_CANDIDATO = strArray[5].ToString().Trim(),
                                                                                                NM_URNA_CANDIDATO = strArray[6].ToString().Trim(),
                                                                                                QT_VOTOS_NOMINAIS = strArray[7].ToString().Trim(),
                                                                                                DS_SIT_TOT_TURNO = strArray[8].ToString().Trim()
                                                                                            };

                                        List<AFIIP_MunicipioZona> tabelaCandidato = _tabelaCandidato.ToList();

                                        int processa = 1;
                                        foreach (var _Candidato in tabelaCandidato)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarMunicipioZona(_Candidato);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarMunicipioZona(_Candidato);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesMunicipioZona[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }
                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesMunicipioZona[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\MUNICIPIOZONA\\" + filesMunicipioZona[i].Name);
                                filesMunicipioZona[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesMunicipioZona[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA\\*.csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    if (RdBoletimUrna.Checked)
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryBoletimUrna = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\");
                            FileInfo[] filesBoletimUrna = directoryBoletimUrna.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\");

                            var rows = Enumerable.Range(0, directoryBoletimUrna.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesBoletimUrna[i].Name;
                                    logcf.DATA = filesBoletimUrna[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesBoletimUrna[i].Name;
                                    logcf.DATA = filesBoletimUrna[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                    

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesBoletimUrna[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesBoletimUrna[i].FullName, Encoding.UTF8, true, 512))
                                {

                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_BoletimUrna> _tabelaboletim = from _boletimurna in strArray
                                                                                        select new AFIIP_BoletimUrna
                                                                                        {
                                                                                            ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                            SG_UF = strArray[1].ToString().Trim(),
                                                                                            CD_MUNICIPIO = strArray[2].ToString().Trim(),
                                                                                            NM_MUNICIPIO = strArray[3].ToString().Trim(),
                                                                                            NR_ZONA = Int32.Parse(strArray[4].ToString().Trim()),
                                                                                            NR_SECAO = Int32.Parse(strArray[5].ToString().Trim()),
                                                                                            NR_LOCAL_VOTACAO = Int32.Parse(strArray[6].ToString().Trim()),
                                                                                            DS_CARGO_PERGUNTA = strArray[7].ToString().Trim(),
                                                                                            SG_PARTIDO = strArray[8].ToString().Trim(),
                                                                                            QT_APTOS = Int32.Parse(strArray[9].ToString().Trim()),
                                                                                            QT_COMPARECIMENTOD = Int32.Parse(strArray[10].ToString().Trim()),
                                                                                            QT_ABSTENCOES = Int32.Parse(strArray[11].ToString().Trim()),
                                                                                            NR_VOTAVEL = Int32.Parse(strArray[12].ToString().Trim()),
                                                                                            NM_VOTAVEL = strArray[13].ToString().Trim(),
                                                                                            QT_VOTOS = Int32.Parse(strArray[14].ToString().Trim())
                                                                                        };

                                        List<AFIIP_BoletimUrna> tabelaboletimurna = _tabelaboletim.ToList();

                                        int processa = 1;
                                        foreach (var _urna in tabelaboletimurna)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarBoletimUrna(_urna);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarBoletimUrna(_urna);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesBoletimUrna[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\BOLETIMURNA\\" + filesBoletimUrna[i].Name);
                                filesBoletimUrna[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesBoletimUrna[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (RdMunZona2018.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryDetalheVotacao2018 = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018\\");
                            FileInfo[] filesDetalheVotacao2018 = directoryDetalheVotacao2018.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018\\");

                            var rows = Enumerable.Range(0, directoryDetalheVotacao2018.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesDetalheVotacao2018[i].Name;
                                    logcf.DATA = filesDetalheVotacao2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesDetalheVotacao2018[i].Name;
                                    logcf.DATA = filesDetalheVotacao2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheVotacao2018[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesDetalheVotacao2018[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<detalhe_votacao_munzona_2018> _tabelaDetalheVotacao2018 = from _DetalheVotacao2018 in strArray
                                                                                                              select new detalhe_votacao_munzona_2018
                                                                                                              {
                                                                                                                  ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                                                  SG_UE = strArray[1].ToString().Trim(),
                                                                                                                  CD_MUNICIPIO = Int32.Parse(strArray[2].ToString().Trim()),
                                                                                                                  NM_MUNICIPIO = strArray[3].ToString().Trim(),
                                                                                                                  NR_ZONA = Int32.Parse(strArray[4].ToString().Trim()),
                                                                                                                  DS_CARGO = strArray[5].ToString().Trim(),
                                                                                                                  QT_APTOS = Int32.Parse(strArray[6].ToString().Trim()),
                                                                                                                  QT_COMPARECIMENTO = Int32.Parse(strArray[7].ToString().Trim()),
                                                                                                                  QT_ABSTENCOES = Int32.Parse(strArray[8].ToString().Trim()),
                                                                                                                  QT_VOTOS_NOMINAIS = Int32.Parse(strArray[9].ToString().Trim()),
                                                                                                                  QT_VOTOS_BRANCOS = Int32.Parse(strArray[10].ToString().Trim()),
                                                                                                                  QT_VOTOS_NULOS = Int32.Parse(strArray[11].ToString().Trim())
                                                                                                              };

                                        List<detalhe_votacao_munzona_2018> DetalheVotacao2018 = _tabelaDetalheVotacao2018.ToList();

                                        int processa = 1;
                                        foreach (var _urna in DetalheVotacao2018)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarDetalheVotacao2018(_urna);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarDetalheVotacao2018(_urna);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesDetalheVotacao2018[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2018\\" + filesDetalheVotacao2018[i].Name);
                                filesDetalheVotacao2018[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesDetalheVotacao2018[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdMunZona2020.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryDetalheMunZona2020 = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020\\");
                            FileInfo[] filesDetalheMunZona2020 = directoryDetalheMunZona2020.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020\\");

                            var rows = Enumerable.Range(0, directoryDetalheMunZona2020.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesDetalheMunZona2020[i].Name;
                                    logcf.DATA = filesDetalheMunZona2020[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                        

                                    logcf.NOMEARQUIVO = filesDetalheMunZona2020[i].Name;
                                    logcf.DATA = filesDetalheMunZona2020[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                    }
                                    else

                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDetalheMunZona2020[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesDetalheMunZona2020[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<detalhe_votacao_munzona_2020> _tabelaDetalheVotacaoMuunZona2020 = from _DetalheVotacaoMuunZona2020 in strArray
                                                                                                                      select new detalhe_votacao_munzona_2020
                                                                                                                      {
                                                                                                                          ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                                                          SG_UF = strArray[1].ToString().Trim(),
                                                                                                                          SG_UE = strArray[2].ToString().Trim(),
                                                                                                                          CD_MUNICIPIO = Int32.Parse(strArray[3].ToString().Trim()),
                                                                                                                          NM_MUNICIPIO = strArray[4].ToString().Trim(),
                                                                                                                          NR_ZONA = Int32.Parse(strArray[5].ToString().Trim()),
                                                                                                                          DS_CARGO = strArray[6].ToString().Trim(),
                                                                                                                          QT_APTOS = Int32.Parse(strArray[7].ToString().Trim()),
                                                                                                                          QT_TOTAL_SECOES = Int32.Parse(strArray[8].ToString().Trim()),
                                                                                                                          QT_COMPARECIMENTO = Int32.Parse(strArray[9].ToString().Trim()),
                                                                                                                          QT_ABSTENCOES = Int32.Parse(strArray[10].ToString().Trim()),
                                                                                                                          QT_VOTOS_VALIDOS = Int32.Parse(strArray[11].ToString().Trim()),
                                                                                                                          QT_VOTOS_NOMINAIS_VALIDOS = Int32.Parse(strArray[12].ToString().Trim()),
                                                                                                                          QT_TOTAL_VOTOS_LEG_VALIDOS = Int32.Parse(strArray[13].ToString().Trim()),
                                                                                                                          QT_VOTOS_BRANCOS = Int32.Parse(strArray[14].ToString().Trim()),
                                                                                                                          QT_TOTAL_VOTOS_NULOS = Int32.Parse(strArray[15].ToString().Trim()),
                                                                                                                      };

                                        List<detalhe_votacao_munzona_2020> DetalheVotacaoMuunZona2020 = _tabelaDetalheVotacaoMuunZona2020.ToList();

                                        int processa = 1;
                                        foreach (var _VotacaoMuunZona2020 in DetalheVotacaoMuunZona2020)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarDetalheVotacao2020(_VotacaoMuunZona2020);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarDetalheVotacao2020(_VotacaoMuunZona2020);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesDetalheMunZona2020[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DETALHEVOTACAO2020\\" + filesDetalheMunZona2020[i].Name);
                                filesDetalheMunZona2020[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesDetalheMunZona2020[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdPartidoMunZona2018.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryMunZona2018 = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018\\");
                            FileInfo[] filesMunZona2018 = directoryMunZona2018.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018\\");

                            var rows = Enumerable.Range(0, directoryMunZona2018.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesMunZona2018[i].Name;
                                    logcf.DATA = filesMunZona2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesMunZona2018[i].Name;
                                    logcf.DATA = filesMunZona2018[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }


                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2018[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesMunZona2018[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<votacao_partido_munzona_2018> _tabelaMunZona2018 = from _MunZona2018 in strArray
                                                                                                       select new votacao_partido_munzona_2018
                                                                                                       {
                                                                                                           ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                                           SG_UF = strArray[1].ToString().Trim(),
                                                                                                           SG_UE = strArray[2].ToString().Trim(),
                                                                                                           NM_UE = strArray[3].ToString().Trim(),
                                                                                                           CD_MUNICIPIO = Int32.Parse(strArray[4].ToString().Trim()),
                                                                                                           NM_MUNICIPIO = strArray[5].ToString().Trim(),
                                                                                                           NR_ZONA = Int32.Parse(strArray[6].ToString().Trim()),
                                                                                                           DS_CARGO = strArray[7].ToString().Trim(),
                                                                                                           NR_PARTIDO = Int32.Parse(strArray[8].ToString().Trim()),
                                                                                                           SG_PARTIDO = strArray[9].ToString().Trim(),
                                                                                                           NM_PARTIDO = strArray[10].ToString().Trim(),
                                                                                                           SQ_COLIGACAO = strArray[11].ToString().Trim(),
                                                                                                           DS_COMPOSICAO_COLIGACAO = strArray[12].ToString().Trim(),
                                                                                                           QT_VOTOS_NOMINAIS_VALIDOS = Int32.Parse(strArray[13].ToString().Trim())
                                                                                                       };

                                        List<votacao_partido_munzona_2018> tabelaMunZona2018 = _tabelaMunZona2018.ToList();

                                        int processa = 1;
                                        foreach (var _MunZona2018 in tabelaMunZona2018)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarPartidoMunZona2018(_MunZona2018);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroCarlito.CriarPartidoMunZona2018(_MunZona2018);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesMunZona2018[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2018\\" + filesMunZona2018[i].Name);
                                filesMunZona2018[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesMunZona2018[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdPartidoMunZona2020.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryMunZona2020 = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020\\");
                            FileInfo[] filesMunZona2020 = directoryMunZona2020.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020\\");

                            var rows = Enumerable.Range(0, directoryMunZona2020.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesMunZona2020[i].Name;
                                    logcf.DATA = filesMunZona2020[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                        

                                    logcf.NOMEARQUIVO = filesMunZona2020[i].Name;
                                    logcf.DATA = filesMunZona2020[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesMunZona2020[i].Name);
                                    }
                                        

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesMunZona2020[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<votacao_partido_munzona_2020> _tabelaMunZona2020 = from _MunZona2020 in strArray
                                                                                                       select new votacao_partido_munzona_2020
                                                                                                       {
                                                                                                           ANO_ELEICAO = Int32.Parse(strArray[0].ToString().Trim()),
                                                                                                           SG_UF = strArray[1].ToString().Trim(),
                                                                                                           SG_UE = strArray[2].ToString().Trim(),
                                                                                                           NM_UE = strArray[3].ToString().Trim(),
                                                                                                           CD_MUNICIPIO = Int32.Parse(strArray[4].ToString().Trim()),
                                                                                                           NM_MUNICIPIO = strArray[5].ToString().Trim(),
                                                                                                           NR_ZONA = Int32.Parse(strArray[6].ToString().Trim()),
                                                                                                           DS_CARGO = strArray[7].ToString().Trim(),
                                                                                                           TP_AGREMIACAO = strArray[8].ToString().Trim(),
                                                                                                           NR_PARTIDO = Int32.Parse(strArray[9].ToString().Trim()),
                                                                                                           SG_PARTIDO = strArray[10].ToString().Trim(),
                                                                                                           DS_COMPOSICAO_FEDERACAO = strArray[11].ToString().Trim(),
                                                                                                           SQ_COLIGACAO = strArray[12].ToString().Trim(),
                                                                                                           DS_COMPOSICAO_COLIGACAO = strArray[13].ToString().Trim(),
                                                                                                           QT_VOTOS_NOMINAIS_VALIDOS = Int32.Parse(strArray[14].ToString().Trim())
                                                                                                       };

                                        List<votacao_partido_munzona_2020> tabelaMunZona2020 = _tabelaMunZona2020.ToList();

                                        int processa = 1;
                                        foreach (var _MunZona2020 in tabelaMunZona2020)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarPartidoMunZona2020(_MunZona2020);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarPartidoMunZona2020(_MunZona2020);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesMunZona2020[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\VOTACAOPARTIDO2020\\" + filesMunZona2020[i].Name);
                                filesMunZona2020[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesMunZona2020[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdDelegadoPartidario.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryDelegadoPartidario = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO\\");
                            FileInfo[] filesDelegadoPartidario = directoryDelegadoPartidario.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO\\");

                            var rows = Enumerable.Range(0, directoryDelegadoPartidario.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesDelegadoPartidario[i].Name;
                                    logcf.DATA = filesDelegadoPartidario[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    logcf.NOMEARQUIVO = filesDelegadoPartidario[i].Name;
                                    logcf.DATA = filesDelegadoPartidario[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                   

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesDelegadoPartidario[i].Name);
                                    }
                                    

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesDelegadoPartidario[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Delegado_Partidario> _tabelaDelegadoPartidario = from _delegado in strArray
                                                                                                           select new AFIIP_Delegado_Partidario
                                                                                                           {
                                                                                                               SG_PARTIDO = strArray[0].ToString().Trim(),
                                                                                                               NR_PARTIDO = Int32.Parse(strArray[1].ToString().Trim()),
                                                                                                               NM_PARTIDO = strArray[2].ToString().Trim(),
                                                                                                               DS_TIPO_ABRANGENCIA = strArray[3].ToString().Trim(),
                                                                                                               SG_UF = strArray[4].ToString().Trim(),
                                                                                                               SG_UE = strArray[5].ToString().Trim(),
                                                                                                               NM_UE = strArray[6].ToString().Trim(),
                                                                                                               SQ_DELEGADO = Int32.Parse(strArray[7].ToString().Trim()),
                                                                                                               NM_DELEGADO = strArray[8].ToString().Trim(),
                                                                                                               DT_CREDENCIAMENTO = strArray[9].ToString().Trim(),
                                                                                                               DT_DESCREDENCIAMENTO = strArray[10].ToString().Trim()
                                                                                                           };

                                        List<AFIIP_Delegado_Partidario> tabelaDelegadoPartidario = _tabelaDelegadoPartidario.ToList();

                                        int processa = 1;
                                        foreach (var _DelegadoPartidario in tabelaDelegadoPartidario)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarDelegadoPartidario(_DelegadoPartidario);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarDelegadoPartidario(_DelegadoPartidario);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesDelegadoPartidario[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\DELEGADOPARTIDARIO\\" + filesDelegadoPartidario[i].Name);
                                filesDelegadoPartidario[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesDelegadoPartidario[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdFiliados.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryFiliados = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS\\");
                            FileInfo[] filesFiliados = directoryFiliados.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS\\");

                            var rows = Enumerable.Range(0, directoryFiliados.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesFiliados[i].Name;
                                    logcf.DATA = filesFiliados[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesFiliados[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesFiliados[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    

                                    logcf.NOMEARQUIVO = filesFiliados[i].Name;
                                    logcf.DATA = filesFiliados[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }
                                        

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesFiliados[i].Name);
                                    }


                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesFiliados[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Filiados> _tabelafiliados = from _boletimurna in strArray
                                                                                      select new AFIIP_Filiados
                                                                                      {
                                                                                          NUMERO_DA_INSCRICAO = strArray[0].ToString().Trim(),
                                                                                          NOME_DO_FILIADO = strArray[1].ToString().Trim(),
                                                                                          SIGLA_DO_PARTIDO = strArray[2].ToString().Trim(),
                                                                                          UF = strArray[3].ToString().Trim(),
                                                                                          CODIGO_DO_MUNICIPIO = strArray[4].ToString().Trim(),
                                                                                          NOME_DO_MUNICIPIO = strArray[5].ToString().Trim(),
                                                                                          ZONA_ELEITORAL = strArray[6].ToString().Trim(),
                                                                                          SECAO_ELEITORAL = strArray[7].ToString().Trim(),
                                                                                          DATA_DA_FILIACAO = strArray[8].ToString().Trim(),
                                                                                          SITUACAO_DO_REGISTRO = strArray[9].ToString().Trim(),
                                                                                          DATA_DA_DESFILIACAO = strArray[10].ToString().Trim(),
                                                                                          MOTIVO_DO_CANCELAMENTO = strArray[11].ToString().Trim()

                                                                                      };

                                        List<AFIIP_Filiados> tabelaFiliados = _tabelafiliados.ToList();

                                        int processa = 1;
                                        foreach (var _filiados in tabelaFiliados)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if (BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarFiliados(_filiados);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarFiliados(_filiados);
                                                }
                                                    
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }


                                    }


                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesFiliados[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\FILIADOS\\" + filesFiliados[i].Name);
                                filesFiliados[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesFiliados[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (RdGuarulhos.Checked)
                {
                    try
                    {
                        BancoAtivo = true;

                        TxResultado.ResetText();
                        LogCarlito logcf = new LogCarlito();
                        DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (pergunta == DialogResult.Yes)
                        {
                            DirectoryInfo directoryGUARULHOS = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS\\");
                            FileInfo[] filesGUARULHOS = directoryGUARULHOS.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                            if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS\\"))
                                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS\\");

                            var rows = Enumerable.Range(0, directoryGUARULHOS.GetFiles().Length);

                            if (rows.Count() == 0)
                                throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                            foreach (var i in rows)
                            {
                                LbProgresso.Text = "0";

                                if (BancoAtivo.Equals(true))
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                }
                                else
                                {
                                    AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                }


                                if (AFIIP_Parametros.CodigoLog == 0)
                                {
                                    TxResultado.Text += "------CRIANDO LOG DO ARQUIVO-----" + Environment.NewLine;

                                    logcf.NOMEARQUIVO = filesGUARULHOS[i].Name;
                                    logcf.DATA = filesGUARULHOS[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                    }


                                }
                                else
                                {
                                    TxResultado.Text += "AGUARDE, IDENTIFICAMOS QUE O REGISTRO JA EXISTE, REORGANIZANDO O REGISTRO, POR FAVOR AGUARDE" + Environment.NewLine;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);

                                        await Excluir_RegistroCarlito.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroCarlito.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);

                                        await Excluir_RegistroMYSQL.Excluir_Registro(AFIIP_Parametros.CodigoLog);
                                        await Excluir_RegistroMYSQL.Excluir_ArquivoLog(AFIIP_Parametros.CodigoLog);
                                    }

                                    logcf.NOMEARQUIVO = filesGUARULHOS[i].Name;
                                    logcf.DATA = filesGUARULHOS[i].LastWriteTime;
                                    logcf.FINALIZADO = false;

                                    if (BancoAtivo.Equals(true))
                                    {
                                        await Criar_RegistroCarlito.CriarLog(logcf);
                                    }
                                    else
                                    {
                                        await Criar_RegistroMysql.CriarLog(logcf);
                                    }

                                    if (BancoAtivo.Equals(true))
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                    }
                                    else
                                    {
                                        AFIIP_Parametros.CodigoLog = await Selecionar_Mysql_Registro.SelecionarCodigoLog(filesGUARULHOS[i].Name);
                                    }

                                    TxResultado.Text += "SEU REGISTRO FOI REORGANIZADO COM SUCESSO, POR FAVOR AGUARDE" + Environment.NewLine;
                                }

                                using (StreamReader sr = new StreamReader(filesGUARULHOS[i].FullName, Encoding.UTF8, true, 512))
                                {
                                    TxResultado.Text += "INSERIDO NO BANCO DE DADOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                    string strLine = AFIIP_Parametros.Semacento(await sr.ReadLineAsync());

                                    string[] strArray = strLine.Split(';');

                                    while (sr.Peek() >= 0)
                                    {
                                        AFIIP_Parametros.contador = AFIIP_Parametros.contador + 1;

                                        strLine = sr.ReadLine();

                                        strArray = strLine.Replace("\"", " ").Split(';');
                                        IEnumerable<AFIIP_Guarulhos> _tabelaGuarulhos = from _Guarulhos in strArray
                                        select new AFIIP_Guarulhos
                                        {
                                            NOME_ELEITOR = strArray[0].ToString().Trim(),
                                            IDADE = Int32.Parse(strArray[1].ToString().Trim()),
                                            CPF_CNPJ = strArray[2].ToString().Trim(),
                                            TIT_ELEITOR = strArray[3].ToString().Trim(),
                                            DTA_NASC = strArray[4].ToString().Trim(),
                                            SEXO = strArray[5].ToString().Trim(),
                                            SIGNO = strArray[6].ToString().Trim(),
                                            NOME_MAE = strArray[7].ToString().Trim(),
                                            NOME_PAI = strArray[8].ToString().Trim(),
                                            EMAIL_ELEITOR = strArray[9].ToString().Trim(),
                                            CHAVE = strArray[10].ToString().Trim(),
                                            CEP = strArray[11].ToString().Trim(),
                                            RUA_ENDERECO = strArray[12].ToString().Trim(),
                                            NUMERO = strArray[13].ToString().Trim(),
                                            BAIRRO = strArray[14].ToString().Trim(),
                                            CIDADE = strArray[15].ToString().Trim(),
                                            UF = strArray[16].ToString().Trim(),
                                            TELEFONE_1 = strArray[17].ToString().Trim(),
                                            TELEFONE_2 = strArray[18].ToString().Trim(),
                                            ALTURA = strArray[19].ToString().Trim(),
                                            PESO = strArray[20].ToString().Trim(),
                                            G_SANG = strArray[21].ToString().Trim(),
                                            COR = strArray[22].ToString().Trim()

                                        };

                                        List<AFIIP_Guarulhos> tabelAgUARULHOS = _tabelaGuarulhos.ToList();

                                        int processa = 1;
                                        foreach (var _GUARULHOS in tabelAgUARULHOS)
                                        {
                                            if (processa.Equals(1))
                                            {
                                                LbProgresso.Text = AFIIP_Parametros.contador.ToString();

                                                //Progress1.Value = AFIIP_Parametros.contador;

                                                //TxResultado.Text += AFIIP_Parametros.contador.ToString() + "%" + Environment.NewLine;

                                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERINSERT", ""))).Wait();

                                                if(BancoAtivo.Equals(true))
                                                {
                                                    await Criar_RegistroCarlito.CriarGuarulhos(_GUARULHOS);
                                                }
                                                else
                                                {
                                                    await Criar_RegistroMysql.CriarGuarulhos(_GUARULHOS);
                                                }
                                                
                                                //TxResultado.Text += "REGISTRO " + filesBoletimUrna[i].Name + " INSERIDO COM SUCESSO " + Environment.NewLine;
                                            }

                                            processa = processa + 1;
                                        }

                                    }
                                }

                                TxResultado.Text += "COPIANDO OS ARUIVOS CONCLUIDOS, POR FAVOR AGUARDE" + Environment.NewLine;
                                filesGUARULHOS[i].CopyTo(Environment.CurrentDirectory + "\\CANDIDATOS\\CONCLUIDOS\\GUARULHOS\\" + filesGUARULHOS[i].Name);
                                filesGUARULHOS[i].Delete();
                                TxResultado.Text += "ARQUIVOS " + filesGUARULHOS[i].Name + " COPIDO COM SUCESSO" + Environment.NewLine;
                                TxResultado.Text += "TODOS OS ARQUIVOS FORAM MOVIDOS COM SUCESSO " + Environment.NewLine;

                                Task.Delay(int.Parse(INI.GetIniString(INI.nomeArquivoINI(), "BANCO", "TIMERCOPYARQUIVO", ""))).Wait();
                            }

                            MessageBox.Show("TODOS OS ARQUIVOS FORAM PROCESSADOS COM SUCESSO", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BancoAtivo = false;
                            //File.Delete(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\*.csv");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TreArquivo_Click(object sender, EventArgs e)
        {

        }

        private void RdCarlito_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdCarlito_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                if (AFIIP_Parametros.directory.Exists)
                {
                    var rows = Enumerable.Range(0, AFIIP_Parametros.directory.GetFiles().Length);

                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(AFIIP_Parametros.files[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> ARQUIVOEXCEL <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                if (AFIIP_Parametros.directory.Exists)
                {
                    var rows = Enumerable.Range(0, AFIIP_Parametros.directoryOriginal.GetFiles().Length);

                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(AFIIP_Parametros.filesOriginal[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> ARQUIVOORIGINAL <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdFotos_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();
                String CamninhoArquivo = Environment.CurrentDirectory + "\\CANDIDATOS\\FOTOS\\";

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;
                List<string> lstaarquivo = Directory.GetFiles(CamninhoArquivo, "*", System.IO.SearchOption.AllDirectories)
                          .Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).ToList();

                var rows = Enumerable.Range(0, lstaarquivo.Count);

                if (Directory.Exists(CamninhoArquivo))
                {
                    foreach (var i in rows)
                    {
                        FileInfo info = new FileInfo(lstaarquivo[i].ToString());

                        TreArquivo.Nodes.Add(info.Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> FOTOS <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdRedes_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryREDESOCIAIS = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\REDESOCIAIS\\");
                FileInfo[] filesREDESOCIAIS = directoryREDESOCIAIS.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryREDESOCIAIS.GetFiles().Length);

                if (directoryREDESOCIAIS.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesREDESOCIAIS[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> REDESOCIAIS <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtFechar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdSecao_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directorySECAO = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\SECAO\\");
                FileInfo[] filesSECAO = directorySECAO.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directorySECAO.GetFiles().Length);

                if (directorySECAO.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesSECAO[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> REDESOCIAIS <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdVotos_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryVotos = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOVOTO\\");
                FileInfo[] filesVotos = directoryVotos.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryVotos.GetFiles().Length);

                if (directoryVotos.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesVotos[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> VOTO MUNICIPIO <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdCandidatos_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\2020\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> 2020 <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdCand2018_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\2018\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> 2018 <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdCandTelZap_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\TELZAP\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdMunZona_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\MUNICIPIOZONA\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void BtPararSQL_Click(object sender, EventArgs e)
        {
            try
            {
                String comando = "net stop " + '"' + "SQL Server (INCIP)" + '"';

                ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;

                var proc = Process.Start(startInfo);

                await proc.StandardInput.WriteLineAsync(comando);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtIniciarSQL_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult pergunta = MessageBox.Show("DESEJA REALMENTE SINCRONIZAR OS ARQUIVOS?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (pergunta == DialogResult.Yes)
                {
                    DirectoryInfo directoryBoletimUrna = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\");
                    FileInfo[] filesBoletimUrna = directoryBoletimUrna.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                    if (!Directory.Exists(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\"))
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\");

                    var rows = Enumerable.Range(0, directoryBoletimUrna.GetFiles().Length);

                    if (rows.Count() == 0)
                        throw new Exception("NENHUM ARQUIVO A SER SINCRONIZADO");

                    foreach (var i in rows)
                    {
                        using (StreamReader sr = new StreamReader(filesBoletimUrna[i].FullName, Encoding.UTF8, true, 512))
                        {
                           await Criar_RegistroCarlito.ImportarCSVSQL("TABELA_BOLETIMURNA", filesBoletimUrna[i].FullName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdBoletimUrna_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\BOLETIMURNA\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdPartidoMunZona2018_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2018\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdPartidoMunZona2020_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\VOTACAOPARTIDO2020\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdMunZona2018_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2018\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdMunZona2020_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DETALHEVOTACAO2020\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdDelegadoPartidario_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\DELEGADOPARTIDARIO\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdFiliados_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\FILIADOS\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdGuarulhos_Click(object sender, EventArgs e)
        {
            try
            {
                TreArquivo.Nodes.Clear();

                DirectoryInfo directoryCandidato = new DirectoryInfo(Environment.CurrentDirectory + "\\CANDIDATOS\\GUARULHOS\\");
                FileInfo[] filesCandidato = directoryCandidato.GetFiles("*.csv", System.IO.SearchOption.AllDirectories);

                TxResultado.Text = "AGUARDANDO INICIO".PadLeft(100) + Environment.NewLine;
                TxResultado.Text += "-----------------------".PadLeft(100) + Environment.NewLine;

                var rows = Enumerable.Range(0, directoryCandidato.GetFiles().Length);

                if (directoryCandidato.Exists)
                {
                    foreach (var i in rows)
                    {
                        TreArquivo.Nodes.Add(filesCandidato[i].Name);
                    }
                }
                else
                {
                    throw new Exception("DIRETORIO ----> TELZAP <------ NÃO ENCONTRADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
