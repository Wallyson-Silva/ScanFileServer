using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        public void PercorreArquivo(string Arquivo)
        {
            StreamReader sr;
            sr = File.OpenText(Arquivo);

            string[] stringSeparador = new string[] { " ", "!", "@", ",", ";", ", ", "; ", "#", "$", "%", "&", "*", "(", ")", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ":", ": ", "-", " - ", " -", "- " };


            while (!sr.EndOfStream)
            {
                string palavras = sr.ReadLine();
                string[] cortaPalavra = palavras.Split(stringSeparador, StringSplitOptions.RemoveEmptyEntries);

                foreach (string obj in cortaPalavra)
                {
                    if (obj.StartsWith(PalavraProcurada, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cont++;
                    }
                }
            }
            if (cont > 0)
            {
                 imprime = "\nA palavra foi encontrada " + cont + " veze(s).\n\n"
                            + Arquivo;
            }
            else
            {
                 imprime = "A palavra não foi encontrada.";
            }
        }

        public override string ToString()
        {
            return imprime;
        }

    }
}         