using Modelos;
using Persistencia;
using System;
using System.Collections.Generic;

class Program
{
    static RepositorioCompromissos repositorio = new RepositorioCompromissos();
    static Usuario usuarioAtual = null!;

    static void Main(string[] args)
    {
        Console.WriteLine("== Sistema de Compromissos ==");

        Console.Write("Digite seu nome completo: ");
        string? nomeUsuario = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nomeUsuario))
        {
            Console.WriteLine("Nome não pode ser vazio.");
            return;
        }
        usuarioAtual = new Usuario(nomeUsuario);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Criar compromisso");
            Console.WriteLine("2 - Listar compromissos");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarCompromisso();
                    break;
                case "2":
                    ListarCompromissos();
                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CriarCompromisso()
    {
        try
        {
            Console.Write("Data (AAAA-MM-DD): ");
            string? dataStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dataStr) || !DateTime.TryParse(dataStr, out DateTime data))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Console.Write("Hora (HH:mm): ");
            string? horaStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(horaStr) || !TimeSpan.TryParse(horaStr, out TimeSpan hora))
            {
                Console.WriteLine("Hora inválida.");
                return;
            }

            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Descrição não pode ser vazia.");
                return;
            }

            Console.Write("Nome do local: ");
            string? nomeLocal = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nomeLocal))
            {
                Console.WriteLine("Nome do local não pode ser vazio.");
                return;
            }

            Console.Write("Capacidade do local: ");
            string? capacidadeStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(capacidadeStr) || !int.TryParse(capacidadeStr, out int capacidade))
            {
                Console.WriteLine("Capacidade inválida.");
                return;
            }

            Local local = new Local(nomeLocal, capacidade);

            DateTime dataHora = data.Add(hora);
            Compromisso compromisso = new Compromisso(dataHora, descricao, usuarioAtual, local);

            // Participantes
            while (true)
            {
                Console.Write("Adicionar participante? (s/n): ");
                string? resp = Console.ReadLine();
                if (resp == null || resp.Trim().ToLower() != "s") break;

                Console.Write("Nome do participante: ");
                string? nomeParticipante = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nomeParticipante))
                {
                    Console.WriteLine("Nome do participante não pode ser vazio.");
                    continue;
                }

                Participante p = new Participante(nomeParticipante);
                compromisso.AdicionarParticipante(p);
                p.AdicionarCompromisso(compromisso); // vínculo bidirecional
            }

            // Anotações
            while (true)
            {
                Console.Write("Adicionar anotação? (s/n): ");
                string? resp = Console.ReadLine();
                if (resp == null || resp.Trim().ToLower() != "s") break;

                Console.Write("Texto da anotação: ");
                string? texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("Texto da anotação não pode ser vazio.");
                    continue;
                }

                Anotacao anotacao = new Anotacao(texto, usuarioAtual);
                compromisso.AdicionarAnotacao(anotacao);
            }

            usuarioAtual.AdicionarCompromisso(compromisso);
            repositorio.Adicionar(compromisso);

            Console.WriteLine("Compromisso criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar compromisso: {ex.Message}");
        }
    }

    static void ListarCompromissos()
    {
        Console.WriteLine("\nCompromissos cadastrados:");
        foreach (var c in repositorio.Compromissos)
        {
            Console.WriteLine(c); // ToString da classe Compromisso
        }
    }
}
