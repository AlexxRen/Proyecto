using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class Establecimiento
{
    public int IdEstablecimiento { get; set; }

    public int IdPropietario { get; set; }

    public string NombreEstablecimiento { get; set; } = null!;

    public string DireccionEstablecimiento { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string TipoEstablecimiento { get; set; } = null!;

    public virtual Propietario IdPropietarioNavigation { get; set; } = null!;

    public virtual ICollection<IdServicio> IdServicios { get; set; } = new List<IdServicio>();
}
