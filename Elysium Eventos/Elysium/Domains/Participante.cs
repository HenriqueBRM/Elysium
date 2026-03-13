using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Participante
{
    public long ParticipanteId { get; set; }

    public long UsuarioId { get; set; }

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();

    public virtual Usuario Usuario { get; set; } = null!;
}
