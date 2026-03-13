namespace Elysium.DTOs.UsuarioDto
{
    public class LerUsuarioDto
    {
        public long UsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public bool? StatusUsuario { get; set; }
        
    }
}
