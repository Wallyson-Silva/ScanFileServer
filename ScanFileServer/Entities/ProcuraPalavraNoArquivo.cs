using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ScanFileServer.Entities
{
    class ProcuraPalavraNoArquivo
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
        HashSet<string> ConjuntoDeArquivos = new HashSet<string>();

        public void PercorreArquivo(string Arquivo)
        {
            StreamReader sr;
            sr = File.OpenText(Arquivo);

            while (!sr.EndOfStream)
            {
                string linhaDoArquivo = sr.ReadLine();
                foreach (Match match in Regex.Matches(linhaDoArquivo, PalavraProcurada, RegexOptions.IgnoreCase))
                {
                    cont++;
                    ConjuntoDeArquivos.Add(Arquivo);
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
                foreach(string caminhoDoArquivo in ConjuntoDeArquivos)
                {
                    sbo.AppendLine(caminhoDoArquivo);
                    sbo.AppendLine();
                }

            }           
            return sbo.ToString();
        }
    }
}