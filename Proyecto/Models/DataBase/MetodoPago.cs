using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class MetodoPago
{
    public int IdMetodPago { get; set; }

    public string Metodo { get; set; } = null!;

    public decimal Comision { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
