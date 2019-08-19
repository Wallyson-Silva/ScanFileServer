using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ScanFileServer.Entities
{
    class ProcuraPalavraNoArquivo : ArquivosQueConteemAPalavra
    {
        public string PalavraProcurada { get; set; }

        public ProcuraPalavraNoArquivo()
        {
        }

        public ProcuraPalavraNoArquivo(string palavraProcurada)
        {
            PalavraProcurada = palavraProcurada;
        }

        int cont = 0;
        string imprime;
        ArquivosQueConteemAPalavra arquivosQueConteemAPalavra = new ArquivosQueConteemAPalavra();

        public void PercorreArquivo(string ArquivoAtual)
        {
            StreamReader sr;
            sr = File.OpenText(ArquivoAtual);
            while (!sr.EndOfStream)
            {
                string linhaDoArquivo = sr.ReadLine();
                foreach (Match match in Regex.Matches(linhaDoArquivo, PalavraProcurada, RegexOptions.IgnoreCase))
                {
                    cont++;
                    arquivosQueConteemAPalavra.ConjuntoDeArquivos.Add(ArquivoAtual);
                }
            }
            sr.Close();
        }  

        public override string ToString()
        {
            if (cont > 0)
            {
                imprime = "\nA palavra foi encontrada " + cont + " vez(es).\n";
                arquivosQueConteemAPalavra.CriarTxtDeConjuntoDeArquivos();
            }
            else
            {
                imprime = "\nA palavra não foi encontrada.\n";
            }

            StringBuilder sbo = new StringBuilder();
            sbo.Append(imprime);
            return sbo.ToString();
        }
    }
}