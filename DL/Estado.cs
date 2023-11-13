using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Georreferencium> Georreferencia { get; set; } = new List<Georreferencium>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
