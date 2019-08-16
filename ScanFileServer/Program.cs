using System;
using System.IO;
using ScanFileServer.Entities;

namespace ScanFileServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o caminho do diretório: ");
            string caminhoDoDiretorio = Console.ReadLine();

            Console.Write("Entre com a palavra procurada: ");
            string palavraProcurada = Console.ReadLine();

            ProcuraPalavraNoArquivo x = new ProcuraPalavraNoArquivo(caminhoDoDiretorio, palavraProcurada);

            try
            {
                var arquivos = Directory.EnumerateFiles(caminhoDoDiretorio, "*.*", SearchOption.AllDirectories);

                foreach (string arquivoAtual in arquivos)
                {
                    x.PercorreArquivo(arquivoAtual);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(x);

        }
    }
}
