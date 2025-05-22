// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Agenda de Compromissos ===");
        Console.Write("Informe seu nome completo: ");
        string nomeUsuario = Console.ReadLine();

        var usuario = new Usuario(nomeUsuario);

        while (true)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1 - Registrar novo compromisso");
            Console.WriteLine("2 - Listar compromissos");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                RegistrarCompromisso(usuario);
            }
            else if (opcao == "2")
            {
                ListarCompromissos(usuario);
            }
            else if (opcao == "0")
            {
                Console.WriteLine("Saindo...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }

    static void RegistrarCompromisso(Usuario usuario)
    {
        try
        {
            Console.Write("Data e hora do compromisso (ex: 25/12/2025 14:00): ");
            DateTime dataHora = DateTime.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Nome do local: ");
            string nomeLocal = Console.ReadLine();

            Console.Write("Capacidade do local: ");
            int capacidade = int.Parse(Console.ReadLine());

            var local = new Local(nomeLocal, capacidade);

            var compromisso = new Compromisso(dataHora, descricao, usuario, local);

            // Adicionar participantes
            while (true)
            {
                Console.Write("Adicionar participante (deixe vazio para terminar): ");
                string nomeParticipante = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nomeParticipante)) break;
                var participante = new Participante(nomeParticipante);
                compromisso.AdicionarParticipante(participante);
            }

            // Adicionar anotações
            while (true)
            {
                Console.Write("Adicionar anotação (deixe vazio para terminar): ");
                string textoAnotacao = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(textoAnotacao)) break;
                compromisso.AdicionarAnotacao(textoAnotacao);
            }

            usuario.AdicionarCompromisso(compromisso);
            local.AdicionarCompromisso(compromisso);

            Console.WriteLine("Compromisso registrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao registrar compromisso: {ex.Message}");
        }
    }

    static void ListarCompromissos(Usuario usuario)
    {
        if (usuario.Compromissos.Count == 0)
        {
            Console.WriteLine("Nenhum compromisso registrado.");
            return;
        }

        Console.WriteLine("\nCompromissos:");
        int i = 1;
        foreach (var compromisso in usuario.Compromissos)
        {
            Console.WriteLine($"--- Compromisso #{i} ---");
            Console.WriteLine(compromisso.ToString());
            i++;
        }
    }
}
