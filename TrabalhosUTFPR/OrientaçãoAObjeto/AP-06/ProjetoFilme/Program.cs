using System;

class Program
{
    static void Main()
    {
        var repositorio = new FilmeJsonRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Catálogo de Filmes ===");
            Console.WriteLine("1. Adicionar filme");
            Console.WriteLine("2. Listar todos os filmes");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Remover filme");
            Console.WriteLine("5. Buscar por gênero");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var filme = new Filme();
                    Console.Write("Título: ");
                    filme.Titulo = Console.ReadLine();
                    Console.Write("Diretor: ");
                    filme.Diretor = Console.ReadLine();
                    Console.Write("Ano de lançamento: ");
                    filme.AnoLancamento = int.Parse(Console.ReadLine());
                    Console.Write("Gênero: ");
                    filme.Genero = Console.ReadLine();

                    repositorio.Adicionar(filme);
                    Console.WriteLine("\nFilme adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Lista de Filmes ---");
                    foreach (var f in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{f.Id} - {f.Titulo} ({f.AnoLancamento}) - {f.Diretor} - Gênero: {f.Genero}");
                    }
                    break;

                case "3":
                    Console.Write("\nID do filme: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idBusca))
                    {
                        var encontrado = repositorio.ObterPorId(idBusca);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Título: {encontrado.Titulo}\nDiretor: {encontrado.Diretor}\nAno: {encontrado.AnoLancamento}\nGênero: {encontrado.Genero}");
                        }
                        else Console.WriteLine("Filme não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "4":
                    Console.Write("\nID do filme a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Filme removido.");
                        else
                            Console.WriteLine("Filme não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "5":
                    Console.Write("\nDigite o gênero: ");
                    string genero = Console.ReadLine();
                    var filmesGenero = repositorio.ObterPorGenero(genero);
                    Console.WriteLine($"\nFilmes do gênero '{genero}':");
                    foreach (var f in filmesGenero)
                    {
                        Console.WriteLine($"{f.Titulo} ({f.AnoLancamento}) - {f.Diretor}");
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
