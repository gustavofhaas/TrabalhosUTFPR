using System.Collections.Generic;

public interface IPacienteRepository : IRepository<Paciente>
{
    IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima);
}
