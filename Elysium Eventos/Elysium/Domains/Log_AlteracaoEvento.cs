using System;
using System.Collections.Generic;

namespace Elysium.Domains;

public partial class Log_AlteracaoEvento
{
    public long Log_AlteracaoId { get; set; }

    public long Log_AlteracaoEventoId { get; set; }

    public string NomeAnterior { get; set; } = null!;

    public DateTime DataAnterior { get; set; }

    public string LocalAnterior { get; set; } = null!;

    public long PalestranteIdAnterior { get; set; }

    public DateTime? DataAlteracao { get; set; }

    public virtual Evento Log_AlteracaoEventoNavigation { get; set; } = null!;
}
