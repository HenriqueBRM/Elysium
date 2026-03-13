using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Categoria
{
    public long CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<CategoriaEvento> CategoriaEvento { get; set; } = new List<CategoriaEvento>();
}
