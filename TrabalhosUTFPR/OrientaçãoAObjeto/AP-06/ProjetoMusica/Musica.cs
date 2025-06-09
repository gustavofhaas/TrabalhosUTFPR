using System;

public class Musica : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public TimeSpan Duracao { get; set; }

    public Musica()
    {
        Id = Guid.NewGuid();
    }
}
