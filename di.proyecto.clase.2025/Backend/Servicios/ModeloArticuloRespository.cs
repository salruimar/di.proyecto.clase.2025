using Castle.Core.Logging;
using di.proyecto.clase._2025.Backend.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.Backend.Servicios
{
    public class ModeloArticuloRespository : GenericRepository<Modeloarticulo>
    {
        public ModeloArticuloRespository(DiinventarioexamenContext context, ILogger<GenericRepository<Modeloarticulo>> logger) 
        : base(context, logger)
        {

        }
    }
}
