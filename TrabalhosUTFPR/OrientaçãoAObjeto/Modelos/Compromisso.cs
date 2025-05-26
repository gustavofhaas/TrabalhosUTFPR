using System;
using System.Collections.Generic;

public class Compromisso
{
    public DateTime DataHora { get; private set; }
    public string Descricao { get; private set; }

    public Usuario Usuario { get; private set; }
    public Local Local { get; private set; }

    private List<Participante> participantes = new List<Participante>();
    private List<Anotacao> anotacaos = new List<Anotacao>();

    public IReadOnlyCollection<Participante> Participantes => participantes.AsReadOnly();
    public IReadOnlyCollection<Anotacao> Anotacaos => anotacaos.AsReadOnly();

    public Compromisso(DateTime dataHora, string descricao, Usuario usuario, Local local)
    {
        if (dataHora <= DateTime.Now)
            throw new ArgumentException("Data e hora do compromisso devem ser futuras.", nameof(dataHora));

        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição não pode ser nula ou vazia.", nameof(descricao));

        DataHora = dataHora;
        Descricao = descricao;
        Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        Local = local ?? throw new ArgumentNullException(nameof(local));
    }

    public void AdicionarParticipante(Participante participante)
    {
        if (participante == null)
            throw new ArgumentNullException(nameof(participante), "Participante não pode ser nulo.");

        if (participantes.Contains(participante))
            throw new InvalidOperationException("Participante já adicionado.");

        if (!Local.ValidarCapacidade(participantes.Count + 1)) // Corrigido nome do método
            throw new InvalidOperationException("Capacidade do local excedida.");

        participantes.Add(participante);
    }

    public void AdicionarAnotacao(Anotacao anotacao)
    {
        if (anotacao == null)
            throw new ArgumentNullException(nameof(anotacao), "Anotação não pode ser nula.");

        if (string.IsNullOrWhiteSpace(anotacao.Texto))
            throw new ArgumentException("Texto da anotação não pode ser nulo ou vazio.", nameof(anotacao));

        anotacaos.Add(anotacao);
    }

    public override string ToString()
    {
        return $"Compromisso: {Descricao}, Data e Hora: {DataHora}, Local: {Local.Nome}, Participantes: {participantes.Count}, Anotações: {anotacaos.Count}";
    }
}