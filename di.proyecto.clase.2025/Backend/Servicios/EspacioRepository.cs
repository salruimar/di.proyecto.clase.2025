using di.proyecto.clase._2025.Backend.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.Backend.Servicios
{
    public class EspacioRepository : GenericRepository<Espacio>
    {
        public EspacioRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Espacio>> logger) : base(context, logger)
        {
        }
    }
}
