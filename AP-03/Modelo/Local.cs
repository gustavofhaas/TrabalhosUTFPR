using System;
using System.Collections.Generic;

public class Local
{
    public string Nome { get; private set; }
    public int Capacidade { get; private set; }

    private List<Compromisso> _compromissos = new List<Compromisso>();
    public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

    public Local(string nome, int capacidade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do local não pode ser vazio.");
        if (capacidade < 1)
            throw new ArgumentException("Capacidade deve ser maior que zero.");
        Nome = nome;
        Capacidade = capacidade;
    }

    public void ValidarCapacidade(int quantidade)
    {
        if (quantidade > Capacidade)
            throw new InvalidOperationException("Quantidade de pessoas excede a capacidade do local.");
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException(nameof(compromisso));
        if (!_compromissos.Contains(compromisso))
            _compromissos.Add(compromisso);
    }
}