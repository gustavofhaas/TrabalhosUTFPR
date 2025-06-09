using System.Collections.Generic;
using System.Linq;

public class FilmeJsonRepository : GenericJsonRepository<Filme>, IFilmeRepository
{
    public IEnumerable<Filme> ObterPorGenero(string genero)
    {
        return ObterTodos().Where(f => f.Genero.Equals(genero, System.StringComparison.OrdinalIgnoreCase));
    }
}
