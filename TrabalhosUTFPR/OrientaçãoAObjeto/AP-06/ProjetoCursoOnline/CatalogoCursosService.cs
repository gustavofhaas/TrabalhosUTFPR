using System;

public class CatalogoCursosService
{
    private readonly ICursoOnlineRepository _repositorio;

    public CatalogoCursosService(ICursoOnlineRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public bool RegistrarCurso(CursoOnline curso)
    {
        if (_repositorio.ObterPorTitulo(curso.Titulo) != null)
        {
            Console.WriteLine("Já existe um curso com esse título.");
            return false;
        }

        _repositorio.Adicionar(curso);
        return true;
    }

    public void ListarCursos()
    {
        foreach (var c in _repositorio.ObterTodos())
        {
            Console.WriteLine($"{c.Id} - {c.Titulo} ({c.CargaHoraria}h) - Instrutor: {c.Instrutor}");
        }
    }
}
