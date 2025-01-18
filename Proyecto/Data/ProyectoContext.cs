using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext (DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

      
    }
}
