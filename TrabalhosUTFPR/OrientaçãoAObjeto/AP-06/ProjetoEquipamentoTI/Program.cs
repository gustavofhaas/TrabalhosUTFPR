using System;

class Program
{
    static void Main()
    {
        var repositorio = new InMemoryEquipamentoTIRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Inventário de Equipamentos de TI ===");
            Console.WriteLine("1. Adicionar equipamento");
            Console.WriteLine("2. Listar equipamentos");
            Console.WriteLine("3. Remover equipamento");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var equipamento = new EquipamentoTI();
                    Console.Write("Nome do equipamento: ");
                    equipamento.NomeEquipamento = Console.ReadLine();
                    Console.Write("Tipo (ex: Notebook, Monitor): ");
                    equipamento.TipoEquipamento = Console.ReadLine();
                    Console.Write("Número de série: ");
                    equipamento.NumeroSerie = Console.ReadLine();
                    Console.Write("Data de aquisição (AAAA-MM-DD): ");
                    equipamento.DataAquisicao = DateTime.Parse(Console.ReadLine());

                    repositorio.Adicionar(equipamento);
                    Console.WriteLine("\nEquipamento adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Equipamentos Cadastrados ---");
                    foreach (var eq in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{eq.Id} - {eq.NomeEquipamento} ({eq.TipoEquipamento}) - Série: {eq.NumeroSerie} - Aquisição: {eq.DataAquisicao:dd/MM/yyyy}");
                    }
                    break;

                case "3":
                    Console.Write("\nID do equipamento a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Equipamento removido.");
                        else
                            Console.WriteLine("Equipamento não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
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
