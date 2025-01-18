using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class IdServicio
{
    public int IdSerivcio { get; set; }

    public int IdEstablecimiento { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public virtual Establecimiento IdEstablecimientoNavigation { get; set; } = null!;

    public virtual ICollection<IdPaquete> IdPaquetes { get; set; } = new List<IdPaquete>();
}
