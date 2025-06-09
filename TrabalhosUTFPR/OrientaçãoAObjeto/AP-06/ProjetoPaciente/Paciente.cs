using System;

public class Paciente : IEntidade
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string ContatoEmergencia { get; set; }

    public Paciente()
    {
        Id = Guid.NewGuid();
    }
}
