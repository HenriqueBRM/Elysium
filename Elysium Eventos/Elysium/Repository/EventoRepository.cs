using Elysium.Contexts;
using Elysium.Domains;
using Elysium.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elysium.Repository
{
    public class EventoRepository : IEventoRepository   
    {
        private readonly ElysiumContext _context;
        public EventoRepository(ElysiumContext context)
        {
            _context = context;
        }


        public List<Evento> Listar()
        {
            List<Evento> eventos = _context.Evento
                .Include(evento => evento.Nome)
                .Include(evento => evento.Local)
                .Include(evento => evento.Data)
                .Include(evento => evento.Descricao)
                .Include(evento => evento.Categoria)
                .Include(evento => evento.Palestrante)
                .ToList();

            return eventos;
        }

        public Evento ObterPorId(int id)
        {
            Evento? evento = _context.Evento
                .Include(eventoDb => eventoDb.Nome)
                .Include(eventoDb => eventoDb.Local)
                .Include(eventoDb => eventoDb.Data)
                .Include(eventoDb => eventoDb.Descricao)
                .Include(eventoDb => eventoDb.Categoria)
                .Include(eventoDb => eventoDb.Palestrante)

                .FirstOrDefault(eventoDb => eventoDb.EventoId == id);

            return evento;                
        }

        bool NomeExiste(string Nome, int? eventoIdAtual)
        {
            var eventoConsultado = _context.Evento.AsQueryable();

            if (eventoIdAtual.HasValue)
            {
                eventoConsultado = eventoConsultado.Where(evento => evento.EventoId != eventoIdAtual.Value)
            }

            return eventoConsultado.Any(evento => evento.Nome == Nome);
        }

        public void Adicionar(Evento evento, List<long> categoriaIds)
        {
            List<Categoria> categorias = _context.Categoria
                .Where(categoria => categoriaIds.Contains(categoria.CategoriaId))
                .ToList();

            evento.Categoria = categorias;
            _context.Evento.Add(evento);
            _context.SaveChanges();

        }

        public void Atualizar(Evento evento, List<long> categoriaIds)
        {
            Evento? eventoBanco = _context.Evento
                .Include(evento => evento.Categoria)
                .FirstOrDefault(eventoAux => eventoAux.EventoId == evento.EventoId);
        }

    }
}
