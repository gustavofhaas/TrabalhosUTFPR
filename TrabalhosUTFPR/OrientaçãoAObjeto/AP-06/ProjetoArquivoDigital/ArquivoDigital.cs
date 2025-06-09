using System;

public class ArquivoDigital : IEntidade
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; }
    public string TipoArquivo { get; set; }
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }

    public ArquivoDigital()
    {
        Id = Guid.NewGuid();
    }
}
