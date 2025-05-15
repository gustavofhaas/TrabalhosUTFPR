using System;
using System.Collections.Generic;

public class Usuario
{
    public string NomeCompleto { get; private set; }

    private List<Compromisso> _compromissos = new List<Compromisso>();

    public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

    public Usuario(string nomeCompleto)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new ArgumentException("Nome não pode ser vazio.");
        NomeCompleto = nomeCompleto;
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException(nameof(compromisso));
        // Exemplo de validação: não permitir compromissos duplicados
        if (_compromissos.Contains(compromisso))
            throw new InvalidOperationException("Compromisso já adicionado.");
        _compromissos.Add(compromisso);
    }
}