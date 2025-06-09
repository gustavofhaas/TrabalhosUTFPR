public interface ICursoOnlineRepository : IRepository<CursoOnline>
{
    CursoOnline? ObterPorTitulo(string titulo);
}
