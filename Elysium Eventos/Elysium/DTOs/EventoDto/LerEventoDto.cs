namespace Elysium.DTOs.EventoDto
{
    public class LerEventoDto
    {
        public long EventoId { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime Data { get; set; }
        public string Local { get; set; } = null!;
        public long PalestranteId { get; set; }
        public long CriadoPorUsuarioId { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? StatusEvento { get; set; }
    }
}
