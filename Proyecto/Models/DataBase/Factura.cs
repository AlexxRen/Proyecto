using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Total { get; set; }

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
