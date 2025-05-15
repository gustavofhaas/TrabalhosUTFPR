using System;
using System.Collections.Generic;
using System.Text;

public class Compromisso
{
    public DateTime DataHora { get; private set; }
    public string Descricao { get; private set; }
    public Usuario Responsavel { get; private set; }
    public Local Local { get; private set; }

    private List<Participante> _participantes = new List<Participante>();
    public IReadOnlyCollection<Participante> Participantes => _participantes.AsReadOnly();

    private List<Anotacao> _anotacoes = new List<Anotacao>();
    public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes.AsReadOnly();

    public Compromisso(DateTime dataHora, string descricao, Usuario responsavel, Local local)
    {
        if (dataHora <= DateTime.Now)
            throw new ArgumentException("A data e hora devem ser futuras.");
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição é obrigatória.");
        if (responsavel == null)
            throw new ArgumentNullException(nameof(responsavel));
        if (local == null)
            throw new ArgumentNullException(nameof(local));

        DataHora = dataHora;
        Descricao = descricao;
        Responsavel = responsavel;
        Local = local;
    }

    public void AdicionarParticipante(Participante participante)
    {
        if (participante == null)
            throw new ArgumentNullException(nameof(participante));
        if (_participantes.Contains(participante))
            throw new InvalidOperationException("Participante já adicionado.");
        if (Local.Capacidade > 0 && _participantes.Count + 1 > Local.Capacidade)
            throw new InvalidOperationException("Capacidade do local excedida.");
        _participantes.Add(participante);
    }

    public void AdicionarAnotacao(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException("Texto da anotação não pode ser vazio.");
        _anotacoes.Add(new Anotacao(texto, DateTime.Now));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Compromisso: {Descricao}");
        sb.AppendLine($"Data/Hora: {DataHora}");
        sb.AppendLine($"Responsável: {Responsavel.NomeCompleto}");
        sb.AppendLine($"Local: {Local.Nome} (Capacidade: {Local.Capacidade})");
        sb.AppendLine($"Participantes: {Participantes.Count}");
        sb.AppendLine($"Anotações: {Anotacoes.Count}");
        return sb.ToString();
    }
}