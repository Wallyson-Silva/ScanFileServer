using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScanFileServer.Entities
{   // Nesta classe eu irei realizar as operções e manipulações nos arqivos encontrados que conteem dentro de si a palavra que foi procurada;
    class ArquivosQueConteemAPalavra : MenuDeAcoes
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

        public void DeletarArquivoDesejado(string caminhoDoArquivo)
        {
            File.Delete(caminhoDoArquivo);
        }

    }
}
