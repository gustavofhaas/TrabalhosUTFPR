using System;

class Program
{
    static void Main()
    {
        var repositorio = new GenericJsonRepository<Musica>();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Biblioteca de Músicas ===");
            Console.WriteLine("1. Adicionar música");
            Console.WriteLine("2. Listar músicas");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Remover música");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var musica = new Musica();
                    Console.Write("Título: ");
                    musica.Titulo = Console.ReadLine();
                    Console.Write("Artista: ");
                    musica.Artista = Console.ReadLine();
                    Console.Write("Álbum: ");
                    musica.Album = Console.ReadLine();
                    Console.Write("Duração (em minutos): ");
                    if (double.TryParse(Console.ReadLine(), out double minutos))
                        musica.Duracao = TimeSpan.FromMinutes(minutos);
                    else
                        musica.Duracao = TimeSpan.Zero;

                    repositorio.Adicionar(musica);
                    Console.WriteLine("\nMúsica adicionada!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Lista de Músicas ---");
                    foreach (var m in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{m.Id} - {m.Titulo} - {m.Artista} ({m.Duracao:mm\\:ss})");
                    }
                    break;

                case "3":
                    Console.Write("\nID da música: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idBusca))
                    {
                        var encontrada = repositorio.ObterPorId(idBusca);
                        if (encontrada != null)
                        {
                            Console.WriteLine($"Título: {encontrada.Titulo}\nArtista: {encontrada.Artista}\nÁlbum: {encontrada.Album}\nDuração: {encontrada.Duracao:mm\\:ss}");
                        }
                        else Console.WriteLine("Música não encontrada.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "4":
                    Console.Write("\nID da música a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Música removida.");
                        else
                            Console.WriteLine("Música não encontrada.");
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
