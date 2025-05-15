using System;

public class Anotacao
{
    public string Texto { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public Anotacao(string texto, DateTime? dataCriacao = null)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException("O texto da anotação não pode ser vazio.");
        Texto = texto;
        DataCriacao = dataCriacao ?? DateTime.Now;
    }
}