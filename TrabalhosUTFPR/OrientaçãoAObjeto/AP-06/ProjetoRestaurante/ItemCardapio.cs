using System;

public abstract class ItemCardapio : IEntidade
{
    public Guid Id { get; set; }
    public string NomeItem { get; set; }
    public decimal Preco { get; set; }

    public ItemCardapio()
    {
        Id = Guid.NewGuid();
    }
}
