using System;

public class Funcionario : IEntidade
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Cargo { get; set; }
    public Guid DepartamentoId { get; set; }

    public Funcionario()
    {
        Id = Guid.NewGuid();
    }
}
