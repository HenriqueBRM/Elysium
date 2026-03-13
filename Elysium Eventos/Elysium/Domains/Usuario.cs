using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Usuario
{
    public long UsuarioId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public bool? StatusUsuario { get; set; }

    public virtual ICollection<Administrador> Administrador { get; set; } = new List<Administrador>();

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();

    public virtual ICollection<Palestrante> Palestrante { get; set; } = new List<Palestrante>();

    public virtual Participante? Participante { get; set; }
}
