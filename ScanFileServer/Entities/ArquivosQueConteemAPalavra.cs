using System.Collections.Generic;
using System.IO;

namespace ScanFileServer.Entities
{   // Nesta classe eu irei realizar as operções e manipulações nos arquivos encontrados que conteem dentro de si a palavra que foi procurada;
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

        string caminhoParaSalvarTxt = @"C:\Windows\Temp\ListaDeArquivosTPFSSCAN.txt";
        public void CriarTxtDeConjuntoDeArquivos()
        {
            StreamWriter sw;            
            sw = File.CreateText(caminhoParaSalvarTxt);

            foreach (string caminhoDoArquivo in ConjuntoDeArquivos)
            {
                sw.WriteLine($"{caminhoDoArquivo}\n");
            }
            sw.Close();
        }

        public void AbrirArquivoDesejado(string caminhoDoArquivo)
        {
            System.Diagnostics.Process.Start("notepad", caminhoDoArquivo);
        }

        public void DeletarArquivoDesejado(string caminhoDoArquivo)
        {
            File.Delete(caminhoDoArquivo);
        }

        public void DeletarTodosOsArquivos()
        {
            StreamReader caminhoDoArquivo;
            caminhoDoArquivo = File.OpenText(caminhoParaSalvarTxt);
            while (!caminhoDoArquivo.EndOfStream)
            {                  
                string linhaDoArquivo = caminhoDoArquivo.ReadLine();
                if (File.Exists(linhaDoArquivo))
                {
                    File.Delete(linhaDoArquivo);
                } 
            }
            caminhoDoArquivo.Close();
        }

    }
}
