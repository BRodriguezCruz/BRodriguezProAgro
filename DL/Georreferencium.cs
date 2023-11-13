using System;
using System.Collections.Generic;

namespace DL;

public partial class Georreferencium
{
    public int IdGeorreferencia { get; set; }

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }

    public int? IdEstado { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }
}
