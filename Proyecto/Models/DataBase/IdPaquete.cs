using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class IdPaquete
{
    public int IdPaquete1 { get; set; }

    public int IdSerivcio { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual IdServicio IdSerivcioNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
