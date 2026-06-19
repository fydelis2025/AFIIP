using AFIIP_SINCRONIZADOR.BANCO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AFIIP_SINCRONIZADOR.Classes
{
    public class AFIIP_Parametros
    {
        public static DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory + "\\ARQUIVOEXCEL");
        public static FileInfo[] files = directory.GetFiles("*.csv", SearchOption.AllDirectories);
        public static DirectoryInfo directoryOriginal = new DirectoryInfo(Environment.CurrentDirectory + "\\ARQUIVOORIGINAL");
        public static FileInfo[] filesOriginal = directoryOriginal.GetFiles("*.csv", SearchOption.AllDirectories);
        public static List<TabelaCarlito> Lista;
        public static List<Tabela_Original> Lista_Original;
        public static List<AFIIP_Orgao> _ListaOrgao;
        public static int contador;
        public static String caminhoArquivoFinalizado;
        public static int CodigoLog;
        public static String FormatarArquivo = String.Empty;
        public static string Semacento(string _texto)
        {
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcen = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                _texto = _texto.Replace(acentos[i], semAcen[i]);
            }

            _texto = Regex.Replace(_texto, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(3.5));

            return _texto.Trim();
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }


    }
}
