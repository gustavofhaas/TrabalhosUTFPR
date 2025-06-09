// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var repositorio = new GenericJsonRepository<ItemCardapio>();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Cardápio do Restaurante ===");
            Console.WriteLine("1. Adicionar prato");
            Console.WriteLine("2. Adicionar bebida");
            Console.WriteLine("3. Listar itens do cardápio");
            Console.WriteLine("4. Remover item por ID");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var prato = new Prato();
                    Console.Write("Nome do prato: ");
                    prato.NomeItem = Console.ReadLine();
                    Console.Write("Preço: ");
                    prato.Preco = decimal.Parse(Console.ReadLine());
                    Console.Write("Descrição detalhada: ");
                    prato.DescricaoDetalhada = Console.ReadLine();
                    Console.Write("É vegetariano? (s/n): ");
                    prato.Vegetariano = Console.ReadLine().Trim().ToLower() == "s";
                    repositorio.Adicionar(prato);
                    Console.WriteLine("\nPrato adicionado!");
                    break;

                case "2":
                    var bebida = new Bebida();
                    Console.Write("Nome da bebida: ");
                    bebida.NomeItem = Console.ReadLine();
                    Console.Write("Preço: ");
                    bebida.Preco = decimal.Parse(Console.ReadLine());
                    Console.Write("Volume (ml): ");
                    bebida.VolumeMl = int.Parse(Console.ReadLine());
                    Console.Write("É alcoólica? (s/n): ");
                    bebida.Alcoolica = Console.ReadLine().Trim().ToLower() == "s";
                    repositorio.Adicionar(bebida);
                    Console.WriteLine("\nBebida adicionada!");
                    break;

                case "3":
                    Console.WriteLine("\n--- Itens do Cardápio ---");
                    foreach (var item in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"\nID: {item.Id}");
                        Console.WriteLine($"Nome: {item.NomeItem}");
                        Console.WriteLine($"Preço: R$ {item.Preco:F2}");

                        if (item is Prato p)
                        {
                            Console.WriteLine($"Tipo: Prato");
                            Console.WriteLine($"Descrição: {p.DescricaoDetalhada}");
                            Console.WriteLine($"Vegetariano: {(p.Vegetariano ? "Sim" : "Não")}");
                        }
                        else if (item is Bebida b)
                        {
                            Console.WriteLine($"Tipo: Bebida");
                            Console.WriteLine($"Volume: {b.VolumeMl}ml");
                            Console.WriteLine($"Alcoólica: {(b.Alcoolica ? "Sim" : "Não")}");
                        }
                    }
                    break;

                case "4":
                    Console.Write("\nID do item a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Item removido.");
                        else
                            Console.WriteLine("Item não encontrado.");
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

