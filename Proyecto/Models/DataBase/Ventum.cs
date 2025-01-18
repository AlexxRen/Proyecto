using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdUsuario { get; set; }

    public int IdPaquete { get; set; }

    public int IdMetodPago { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual MetodoPago IdMetodPagoNavigation { get; set; } = null!;

    public virtual IdPaquete IdPaqueteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
