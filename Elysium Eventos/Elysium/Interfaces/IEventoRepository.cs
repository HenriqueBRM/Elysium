using Elysium.Domains;

namespace Elysium.Interfaces
{
    public interface IEventoRepository
    {
        List<Evento> Listar();
        Evento ObterPorId(int id);
        bool NomeExiste(string Nome, int? eventoIdAtual = null);
        void Adicionar(Evento evento, List<long> categoriaIds);
        void Atualizar(Evento evento, List<long> categoriaIds);
        void Remover(int id);
    }
}
