// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        var repositorio = new ReservaHotelJsonRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Reservas de Hotel ===");
            Console.WriteLine("1. Adicionar reserva");
            Console.WriteLine("2. Listar todas as reservas");
            Console.WriteLine("3. Filtrar por status");
            Console.WriteLine("4. Remover reserva");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var reserva = new ReservaHotel();
                    Console.Write("Nome do cliente: ");
                    reserva.NomeCliente = Console.ReadLine();
                    Console.Write("Data de entrada (AAAA-MM-DD): ");
                    reserva.DataEntrada = DateTime.Parse(Console.ReadLine());
                    Console.Write("Data de saída (AAAA-MM-DD): ");
                    reserva.DataSaida = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Status (0 = Pendente, 1 = Confirmada, 2 = Cancelada): ");
                    reserva.Status = Enum.TryParse(Console.ReadLine(), out StatusReserva status) ? status : StatusReserva.Pendente;

                    repositorio.Adicionar(reserva);
                    Console.WriteLine("Reserva adicionada!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Todas as Reservas ---");
                    foreach (var r in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{r.Id} - {r.NomeCliente} | {r.DataEntrada:dd/MM} até {r.DataSaida:dd/MM} | Status: {r.Status}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Filtrar por status (0 = Pendente, 1 = Confirmada, 2 = Cancelada): ");
                    if (Enum.TryParse(Console.ReadLine(), out StatusReserva filtroStatus))
                    {
                        var filtradas = repositorio.ObterPorStatus(filtroStatus);
                        Console.WriteLine($"\nReservas com status {filtroStatus}:");
                        foreach (var r in filtradas)
                        {
                            Console.WriteLine($"{r.NomeCliente} - {r.DataEntrada:dd/MM} a {r.DataSaida:dd/MM}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Status inválido.");
                    }
                    break;

                case "4":
                    Console.Write("ID da reserva a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Reserva removida.");
                        else
                            Console.WriteLine("Reserva não encontrada.");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
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

