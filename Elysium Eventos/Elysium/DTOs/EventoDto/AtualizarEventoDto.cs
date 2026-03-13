namespace Elysium.DTOs.EventoDto
{
    public class AtualizarEventoDto
    {
        public string Nome { get; set; } = null!;
        public string Local { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime Data { get; set; }
        public long PalestranteId { get; set; }
        public bool? StatusEvento { get; set; }
    }
}
