using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _caminhoArquivo;
    private List<T> _entidades;

    public GenericJsonRepository()
    {
        var nomeArquivo = typeof(T).Name.ToLower() + "s.json";
        _caminhoArquivo = nomeArquivo;
        _entidades = CarregarDoArquivo();
    }

    public void Adicionar(T entidade)
    {
        _entidades.Add(entidade);
        SalvarNoArquivo();
    }

    public T? ObterPorId(Guid id)
    {
        return _entidades.FirstOrDefault(e => e.Id == id);
    }

    public List<T> ObterTodos()
    {
        return new List<T>(_entidades);
    }

    public void Atualizar(T entidade)
    {
        var index = _entidades.FindIndex(e => e.Id == entidade.Id);
        if (index != -1)
        {
            _entidades[index] = entidade;
            SalvarNoArquivo();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _entidades.Remove(entidade);
            SalvarNoArquivo();
            return true;
        }
        return false;
    }

    private List<T> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<T>();

        var json = File.ReadAllText(_caminhoArquivo);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    private void SalvarNoArquivo()
    {
        var json = JsonSerializer.Serialize(_entidades, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoArquivo, json);
    }
}
