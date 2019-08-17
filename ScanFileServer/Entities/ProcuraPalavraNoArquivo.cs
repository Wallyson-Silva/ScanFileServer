using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ScanFileServer.Entities
{
    class ProcuraPalavraNoArquivo : ArquivosQueConteemAPalavra
    {
        public string CaminhoDoDiretorio { get; set; }
        public string PalavraProcurada { get; set; }

        public ProcuraPalavraNoArquivo()
        {
        }

        public ProcuraPalavraNoArquivo(string caminhoDoDiretorio, string palavraProcurada)
        {
            CaminhoDoDiretorio = caminhoDoDiretorio;
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

            if (cont > 0)
            {
                imprime = "\nA palavra foi encontrada " + cont + " vez(es).\n\n";
            }
            else
            {
                imprime = "A palavra não foi encontrada.";
            }
            sr.Close();
        }

        public override string ToString()
        {
        
            StringBuilder sbo = new StringBuilder();
            sbo.AppendLine(imprime);
            if (cont>0)
            {
                arquivosQueConteemAPalavra.ImprimeConjuntoDeArquivos();
            }
            return sbo.ToString();
        }
    }
}