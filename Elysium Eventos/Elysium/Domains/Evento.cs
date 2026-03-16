using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Evento
{
    public long EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime Data { get; set; }

    public string Local { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public long CriadoPorUsuarioId { get; set; }

    public long PalestranteId { get; set; }

    public bool? StatusEvento { get; set; }

    public virtual ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();

    public virtual Usuario CriadoPorUsuario { get; set; } = null!;

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();

    public virtual ICollection<Log_AlteracaoEvento> Log_AlteracaoEvento { get; set; } = new List<Log_AlteracaoEvento>();

    public virtual Palestrante Palestrante { get; set; } = null!;
}
