using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class CategoriaEvento
{
    public long CategoriaEventoId { get; set; }

    public long EventoId { get; set; }

    public long CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Evento Evento { get; set; } = null!;
}
