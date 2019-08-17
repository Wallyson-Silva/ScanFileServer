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

            Console.WriteLine("Deseja abrir algum arquivo (s/n)?");
            bool continuarAbrindo = true;
            do
            {
                char abrirArquivo = char.Parse(Console.ReadLine());
                if (abrirArquivo == 's' || abrirArquivo == 'S')
                {
                    Console.Write("Digite o caminho do arquivo: ");
                    string caminhoDoArquivo = Console.ReadLine();
                    x.AbrirArquivoDesejado(caminhoDoArquivo);                    
                }
                else
                {
                    continuarAbrindo = false;
                }

            } while (continuarAbrindo);

        }
    }
}
