using System;

public class CursoOnline : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Instrutor { get; set; }
    public int CargaHoraria { get; set; }

    public CursoOnline()
    {
        Id = Guid.NewGuid();
    }
}
