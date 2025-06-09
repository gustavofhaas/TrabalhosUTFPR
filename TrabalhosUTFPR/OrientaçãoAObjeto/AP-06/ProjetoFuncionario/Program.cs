using System;

class Program
{
    static void Main()
    {
        var repoDepartamentos = new GenericJsonRepository<Departamento>();
        var repoFuncionarios = new GenericJsonRepository<Funcionario>();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Funcionários ===");
            Console.WriteLine("1. Adicionar departamento");
            Console.WriteLine("2. Listar departamentos");
            Console.WriteLine("3. Adicionar funcionário");
            Console.WriteLine("4. Listar funcionários com departamento");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var departamento = new Departamento();
                    Console.Write("Nome do departamento: ");
                    departamento.NomeDepartamento = Console.ReadLine();
                    Console.Write("Sigla: ");
                    departamento.Sigla = Console.ReadLine();

                    repoDepartamentos.Adicionar(departamento);
                    Console.WriteLine("\nDepartamento adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Departamentos ---");
                    foreach (var d in repoDepartamentos.ObterTodos())
                    {
                        Console.WriteLine($"{d.Id} - {d.NomeDepartamento} ({d.Sigla})");
                    }
                    break;

                case "3":
                    var funcionario = new Funcionario();
                    Console.Write("Nome completo: ");
                    funcionario.NomeCompleto = Console.ReadLine();
                    Console.Write("Cargo: ");
                    funcionario.Cargo = Console.ReadLine();

                    Console.WriteLine("\nDepartamentos disponíveis:");
                    var departamentos = repoDepartamentos.ObterTodos();
                    foreach (var d in departamentos)
                    {
                        Console.WriteLine($"{d.Id} - {d.NomeDepartamento}");
                    }

                    Console.Write("Digite o ID do departamento: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid depId) &&
                        departamentos.Exists(d => d.Id == depId))
                    {
                        funcionario.DepartamentoId = depId;
                        repoFuncionarios.Adicionar(funcionario);
                        Console.WriteLine("\nFuncionário adicionado!");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido ou departamento não encontrado.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- Funcionários ---");
                    foreach (var f in repoFuncionarios.ObterTodos())
                    {
                        var dep = repoDepartamentos.ObterPorId(f.DepartamentoId);
                        string nomeDep = dep != null ? dep.NomeDepartamento : "Desconhecido";
                        Console.WriteLine($"{f.NomeCompleto} - {f.Cargo} - Departamento: {nomeDep}");
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
