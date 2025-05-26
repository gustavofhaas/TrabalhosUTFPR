using System.Text.Json;
using System.Text.Json.Serialization;
using Modelos;

namespace Persistencia
{
    public class RepositorioCompromissos
    {
        private const string CaminhoArquivo = "compromissos.json";

        public List<Compromisso> Compromissos { get; private set; }

        public RepositorioCompromissos()
        {
            Compromissos = Carregar();
        }

        public void Adicionar(Compromisso compromisso)
        {
            Compromissos.Add(compromisso);
            Salvar();
        }

        public void Remover(Compromisso compromisso)
        {
            Compromissos.Remove(compromisso);
            Salvar();
        }

        public void Salvar()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var json = JsonSerializer.Serialize(Compromissos, options);
            File.WriteAllText(CaminhoArquivo, json);
        }

        public List<Compromisso> Carregar()
        {
            if (!File.Exists(CaminhoArquivo))
                return new List<Compromisso>();

            var json = File.ReadAllText(CaminhoArquivo);
            return JsonSerializer.Deserialize<List<Compromisso>>(json) ?? new List<Compromisso>();
        }
    }
}
