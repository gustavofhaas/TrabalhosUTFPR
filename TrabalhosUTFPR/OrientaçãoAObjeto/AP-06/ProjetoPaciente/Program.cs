using System;

class Program
{
    static void Main()
    {
        var repositorio = new PacienteJsonRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Pacientes ===");
            Console.WriteLine("1. Adicionar paciente");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Remover paciente");
            Console.WriteLine("5. Filtrar por faixa etária");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var paciente = new Paciente();
                    Console.Write("Nome completo: ");
                    paciente.NomeCompleto = Console.ReadLine();
                    Console.Write("Data de nascimento (AAAA-MM-DD): ");
                    paciente.DataNascimento = DateTime.Parse(Console.ReadLine());
                    Console.Write("Contato de emergência: ");
                    paciente.ContatoEmergencia = Console.ReadLine();

                    repositorio.Adicionar(paciente);
                    Console.WriteLine("\nPaciente cadastrado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Pacientes Cadastrados ---");
                    foreach (var p in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{p.Id} - {p.NomeCompleto} - Nasc.: {p.DataNascimento.ToShortDateString()}");
                    }
                    break;

                case "3":
                    Console.Write("\nID do paciente: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idBusca))
                    {
                        var encontrado = repositorio.ObterPorId(idBusca);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Nome: {encontrado.NomeCompleto}\nNascimento: {encontrado.DataNascimento:dd/MM/yyyy}\nContato: {encontrado.ContatoEmergencia}");
                        }
                        else Console.WriteLine("Paciente não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "4":
                    Console.Write("\nID do paciente a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Paciente removido.");
                        else
                            Console.WriteLine("Paciente não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "5":
                    Console.Write("Idade mínima: ");
                    int idadeMin = int.Parse(Console.ReadLine());
                    Console.Write("Idade máxima: ");
                    int idadeMax = int.Parse(Console.ReadLine());

                    var filtrados = repositorio.ObterPorFaixaEtaria(idadeMin, idadeMax);
                    Console.WriteLine($"\nPacientes entre {idadeMin} e {idadeMax} anos:");
                    foreach (var p in filtrados)
                    {
                        int idade = DateTime.Today.Year - p.DataNascimento.Year;
                        if (p.DataNascimento > DateTime.Today.AddYears(-idade)) idade--;
                        Console.WriteLine($"{p.NomeCompleto} - {idade} anos");
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
