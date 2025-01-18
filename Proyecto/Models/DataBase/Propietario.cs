using System;
using System.Collections.Generic;

namespace Proyecto.Models.Database;

public partial class Propietario
{
    public int IdPropietario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal Cedula { get; set; }

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Establecimiento> Establecimientos { get; set; } = new List<Establecimiento>();
}
