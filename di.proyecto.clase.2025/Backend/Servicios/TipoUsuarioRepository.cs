using di.proyecto.clase._2025.Backend.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.Backend.Servicios
{
    public class TipoUsuarioRepository : GenericRepository<Tipousuario>
    {
        public TipoUsuarioRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Tipousuario>> logger)
        : base(context, logger)
        {
        }
    }
}
