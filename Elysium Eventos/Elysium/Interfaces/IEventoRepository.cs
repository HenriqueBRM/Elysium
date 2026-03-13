using Elysium.Domains;

namespace Elysium.Interfaces
{
    public interface IEventoRepository
    {
        List<Evento> Listar();
        Evento ObterPorId(int id);
        bool NomeExiste(string Nome, int ? produtoIdAtual = null)
    }
}
