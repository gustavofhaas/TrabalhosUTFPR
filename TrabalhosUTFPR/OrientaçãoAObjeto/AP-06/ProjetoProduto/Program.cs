// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        var repositorio = new ProdutoJsonRepository();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Produtos ===");
            Console.WriteLine("1. Adicionar produto");
            Console.WriteLine("2. Listar produtos");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Atualizar produto");
            Console.WriteLine("5. Remover produto");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var produto = new Produto();
                    Console.Write("Nome: ");
                    produto.Nome = Console.ReadLine();
                    Console.Write("Descrição: ");
                    produto.Descricao = Console.ReadLine();
                    Console.Write("Preço: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());
                    Console.Write("Estoque: ");
                    produto.Estoque = int.Parse(Console.ReadLine());

                    repositorio.Adicionar(produto);
                    Console.WriteLine("\nProduto adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\n--- Lista de Produtos ---");
                    foreach (var p in repositorio.ObterTodos())
                    {
                        Console.WriteLine($"{p.Id} - {p.Nome} - R$ {p.Preco:F2} - Estoque: {p.Estoque}");
                    }
                    break;

                case "3":
                    Console.Write("\nID do produto: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idBusca))
                    {
                        var encontrado = repositorio.ObterPorId(idBusca);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Nome: {encontrado.Nome}\nDescrição: {encontrado.Descricao}\nPreço: R$ {encontrado.Preco:F2}\nEstoque: {encontrado.Estoque}");
                        }
                        else Console.WriteLine("Produto não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "4":
                    Console.Write("\nID do produto a atualizar: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idAtualizar))
                    {
                        var existente = repositorio.ObterPorId(idAtualizar);
                        if (existente != null)
                        {
                            Console.Write("Novo nome: ");
                            existente.Nome = Console.ReadLine();
                            Console.Write("Nova descrição: ");
                            existente.Descricao = Console.ReadLine();
                            Console.Write("Novo preço: ");
                            existente.Preco = decimal.Parse(Console.ReadLine());
                            Console.Write("Novo estoque: ");
                            existente.Estoque = int.Parse(Console.ReadLine());

                            repositorio.Atualizar(existente);
                            Console.WriteLine("Produto atualizado!");
                        }
                        else Console.WriteLine("Produto não encontrado.");
                    }
                    else Console.WriteLine("ID inválido.");
                    break;

                case "5":
                    Console.Write("\nID do produto a remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid idRemover))
                    {
                        if (repositorio.Remover(idRemover))
                            Console.WriteLine("Produto removido.");
                        else
                            Console.WriteLine("Produto não encontrado.");
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

