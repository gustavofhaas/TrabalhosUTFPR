namespace Modelos
{
    using System;
    using System.Collections.Generic;

    public class Anotacao
    {
        public string Texto { get; private set; }
        public DateTime DataHora { get; private set; }

        public Anotacao(string texto, Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("Texto não pode ser nulo ou vazio.", nameof(texto));

            Texto = texto;
            DataHora = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Anotação: {Texto}";
        }
    }
}