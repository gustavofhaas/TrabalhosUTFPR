using System;
using System.Collections.Generic;
using System.Linq;

public class PacienteJsonRepository : GenericJsonRepository<Paciente>, IPacienteRepository
{
    public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima)
    {
        var hoje = DateTime.Today;
        return ObterTodos().Where(p =>
        {
            var idade = hoje.Year - p.DataNascimento.Year;
            if (p.DataNascimento > hoje.AddYears(-idade)) idade--; // ajuste se ainda não fez aniversário
            return idade >= idadeMinima && idade <= idadeMaxima;
        });
    }
}
