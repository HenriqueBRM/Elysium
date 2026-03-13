using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Administrador
{
    public long AdministradorId { get; set; }

    public long UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
