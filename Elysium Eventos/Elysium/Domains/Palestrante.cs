using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Palestrante
{
    public long PalestranteId { get; set; }

    public long UsuarioId { get; set; }

    public string AreaAtuacao { get; set; } = null!;

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();

    public virtual Usuario Usuario { get; set; } = null!;
}
