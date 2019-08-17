using System;
using System.Collections.Generic;
using System.Text;

namespace ScanFileServer.Entities
{
    class ArquivosQueConteemAPalavra
    {
        public HashSet<string> ConjuntoDeArquivos = new HashSet<string>();

        public ArquivosQueConteemAPalavra()
        {
        }

        public void InsereArquivoNoConjunto(string ArquivoAtual)
        {
            ConjuntoDeArquivos.Add(ArquivoAtual);
        }

        public void ImprimeConjuntoDeArquivos()
        {
            foreach (string caminhoDoArquivo in ConjuntoDeArquivos)
            {
                Console.WriteLine($"{caminhoDoArquivo}\n");
            }
        }

        public void AbrirArquivoDesejado(string caminhoDoArquivo)
        {
            System.Diagnostics.Process.Start("notepad", caminhoDoArquivo);
        }

    }
}
