namespace Modelos
{
    using System;
    using System.Collections.Generic;

    public class Local
    {
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }

        public Local(string nome, int capacidade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(nome));

            if (capacidade <= 0)
                throw new ArgumentException("Capacidade deve ser maior que zero.", nameof(capacidade));

            Nome = nome;
            Capacidade = capacidade;
        }

        public bool ValidarCapacidade(int quantidadeParticipantes)
        {
            return quantidadeParticipantes <= Capacidade;
        }

        public override string ToString()
        {
            return $"Local: {Nome}, Capacidade: {Capacidade}";
        }
    }
}