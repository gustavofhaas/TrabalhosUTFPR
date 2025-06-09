using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryEquipamentoTIRepository : IEquipamentoTIRepository
{
    private readonly List<EquipamentoTI> _equipamentos = new();

    public void Adicionar(EquipamentoTI equipamento)
    {
        _equipamentos.Add(equipamento);
    }

    public EquipamentoTI? ObterPorId(Guid id)
    {
        return _equipamentos.FirstOrDefault(e => e.Id == id);
    }

    public List<EquipamentoTI> ObterTodos()
    {
        return new List<EquipamentoTI>(_equipamentos);
    }

    public void Atualizar(EquipamentoTI equipamento)
    {
        var index = _equipamentos.FindIndex(e => e.Id == equipamento.Id);
        if (index != -1)
            _equipamentos[index] = equipamento;
    }

    public bool Remover(Guid id)
    {
        var equipamento = ObterPorId(id);
        if (equipamento != null)
        {
            _equipamentos.Remove(equipamento);
            return true;
        }
        return false;
    }
}
