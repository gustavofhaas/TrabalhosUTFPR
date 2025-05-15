using System;
using System.Collections.Generic;

public class Participante
{
    public string NomeCompleto { get; private set; }

    private List<Compromisso> _compromissos = new List<Compromisso>();
    public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

    public Participante(string nomeCompleto)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new ArgumentException("Nome não pode ser vazio.");
        NomeCompleto = nomeCompleto;
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException(nameof(compromisso));
        if (_compromissos.Contains(compromisso))
            throw new InvalidOperationException("Compromisso já adicionado para este participante.");

        _compromissos.Add(compromisso);

        // Atualização bidirecional: adiciona este participante ao compromisso, se ainda não estiver
        if (!compromisso.Participantes.Contains(this))
        {
            compromisso.AdicionarParticipante(this);
        }
    }
}