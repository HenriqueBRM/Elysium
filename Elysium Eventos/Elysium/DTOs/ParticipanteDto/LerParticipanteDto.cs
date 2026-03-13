namespace Elysium.DTOs.ParticipanteDto
{
    public class LerParticipanteDto
    {
        public long ParticipanteId { get; set; }
        public long UsuarioId { get; set; }
        public string Nome { get; set; } = null!;
    }
}
