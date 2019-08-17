using System;
using System.Collections.Generic;
using System.Text;

namespace ScanFileServer.Entities
{
    class MenuDeAcoes
    {
        public void Menu(ProcuraPalavraNoArquivo x)
        {
            bool continuarAbrindo = true;
            do
            {
                Console.WriteLine("Deseja abrir algum arquivo (s/n)?");
                char abrirArquivo = char.Parse(Console.ReadLine());
                if (abrirArquivo == 's' || abrirArquivo == 'S')
                {
                    Console.Write("Digite o caminho do arquivo: ");
                    x.AbrirArquivoDesejado(Console.ReadLine());
                }
                else
                {
                    continuarAbrindo = false;
                }

            } while (continuarAbrindo);

            bool continuarExcluindo = true;
            do
            {
                Console.WriteLine("Deseja excluir algum arquivo (s/n)?");
                char excluirArquivo = char.Parse(Console.ReadLine());
                if (excluirArquivo == 's' || excluirArquivo == 'S')
                {
                    Console.Write("Digite o caminho do arquivo: ");
                    x.DeletarArquivoDesejado(Console.ReadLine());
                }
                else
                {
                    continuarExcluindo = false;
                }

            } while (continuarExcluindo);
        }
    }
}
