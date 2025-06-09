// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        var repositorio = new ArquivoDigitalJsonRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Arquivos Digitais ===");
            Console.WriteLine("1. Adicionar arquivo");
            Console.WriteLine("2. Listar arquivos");
            Console.WriteLine("3. Remover por ID");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var arquivo = new ArquivoDigital();
                    Console.Write("Nome do arquivo: ");
                    arquivo.NomeArquivo = Console.ReadLine();
                    Console.Write("Tipo do arquivo (ex: pdf, jpg): ");
                    arquivo.TipoArquivo = Console.ReadLine();
                    Console.Write("Tamanho em bytes: ");
                    arquivo.TamanhoBytes = long.Parse(Console.ReadLine());
                    arquivo.DataUpload = DateTime.Now;

                    repositorio.Adicionar(arquivo);
                    Console.WriteLine("\nArquivo adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Arquivos Cadastrados ---");
                    foreach (var a in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{a.Id} - {a.NomeArquivo}.{a.TipoArquivo} ({a.TamanhoBytes} bytes) - Upload: {a.DataUpload:dd/MM/yyyy HH:mm}");
                    }
                    break;

                case "3":
                    Console.Write("\nID do arquivo a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Arquivo removido.");
                        else
                            Console.WriteLine("Arquivo não encontrado.");
                    }
                    else
                        Console.WriteLine("ID inválido.");
                    break;

                case "0":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (executando)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

