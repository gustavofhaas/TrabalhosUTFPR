using System.Linq;

public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
{
    public CursoOnline? ObterPorTitulo(string titulo)
    {
        return ObterTodos().FirstOrDefault(c => c.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }
}
