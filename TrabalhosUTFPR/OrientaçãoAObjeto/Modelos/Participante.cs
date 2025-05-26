using System;
using System.Collections.Generic;

public class Participante
{
    public string Nome { get; private set; }

    private List<Compromisso> compromissos = new List<Compromisso>();
    public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();

    public Participante(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(nome));

        Nome = nome;
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException(nameof(compromisso), "Compromisso não pode ser nulo.");

        if (compromissos.Contains(compromisso))
            throw new InvalidOperationException("Compromisso já adicionado.");

        compromissos.Add(compromisso);
    }

    public override string ToString()
    {
        return $"Participante: {Nome}, Compromissos: {compromissos.Count}";
    }
}