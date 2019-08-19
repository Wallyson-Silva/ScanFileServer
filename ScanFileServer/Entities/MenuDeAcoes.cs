using System;

namespace ScanFileServer.Entities
{
    class MenuDeAcoes
    {
        public void Menu(ProcuraPalavraNoArquivo x)
        {
            bool continuar = true;
            do
            {
                Console.WriteLine("Para abrir um arquivo digite 1:\nPara excluir UM arquivo digite 2:\nPara excluir TODOS os arquivo digite 3:\nPara sair digite 4:\n");

                string opcaoEscolhida = Console.ReadLine();

                while (opcaoEscolhida != "1" && opcaoEscolhida != "2" && opcaoEscolhida != "3" && opcaoEscolhida != "4")
                {
                    Console.Write("Opção inválida. Digite novamante: ");
                    opcaoEscolhida = Console.ReadLine();
                }

                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.Write("Digite o caminho do arquivo que deseja abrir: ");
                        x.AbrirArquivoDesejado(Console.ReadLine());
                        Console.Clear();
                        break;
                    case "2":
                        Console.Write("Digite o caminho do arquivo que exluir abrir: ");
                        x.DeletarArquivoDesejado(Console.ReadLine());
                        Console.Clear();
                        break;                       
                    case "3":
                        Console.Write("Tem certeza que deseja exluir todos os arquivos (s/n)? ");
                        char resposta = char.Parse(Console.ReadLine());
                        while (resposta != 's' && resposta != 'n')
                        {
                            Console.Write("Opção inválida. Digite novamante: ");
                            resposta = char.Parse(Console.ReadLine());
                        }
                        if (resposta == 's')
                        {
                            x.DeletarTodosOsArquivos();
                            
                        }
                        Console.Clear();
                        Console.WriteLine("Arquivos deletados!\n");
                        break;                   
                    default:
                        continuar = false;
                        break;

                }
            } while (continuar);
        }
    }
}