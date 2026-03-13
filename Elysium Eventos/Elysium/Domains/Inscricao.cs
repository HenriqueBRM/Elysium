using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Inscricao
{
    public long InscricaoId { get; set; }

    public long EventoId { get; set; }

    public long ParticipanteId { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Participante Participante { get; set; } = null!;
}
