// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        var repositorio = new CursoOnlineJsonRepository();
        var servico = new CatalogoCursosService(repositorio);
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Plataforma de Cursos Online ===");
            Console.WriteLine("1. Registrar novo curso");
            Console.WriteLine("2. Listar cursos");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var curso = new CursoOnline();
                    Console.Write("Título do curso: ");
                    curso.Titulo = Console.ReadLine();
                    Console.Write("Instrutor: ");
                    curso.Instrutor = Console.ReadLine();
                    Console.Write("Carga horária (em horas): ");
                    curso.CargaHoraria = int.Parse(Console.ReadLine());

                    if (servico.RegistrarCurso(curso))
                        Console.WriteLine("Curso registrado com sucesso!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Cursos Disponíveis ---");
                    servico.ListarCursos();
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
