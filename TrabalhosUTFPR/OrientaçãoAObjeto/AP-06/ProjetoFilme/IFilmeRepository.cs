using System.Collections.Generic;

public interface IFilmeRepository : IRepository<Filme>
{
    IEnumerable<Filme> ObterPorGenero(string genero);
}
