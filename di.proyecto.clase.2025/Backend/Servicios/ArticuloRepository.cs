using di.proyecto.clase._2025.Backend.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.Backend.Servicios
{
    public class ArticuloRepository : GenericRepository<Articulo>
    {
        private DbContext _context;
        public ArticuloRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Articulo>> logger) : base(context, logger)
        {
            _context = context;
        }

        /// <summary>
        /// Comprueba si el valor de <see cref="Numserie"/> es único en la tabla.
        /// Excluye el propio registro (por ejemplo al actualizar).
        /// Pasa cualquier <see cref="DbContext"/> que contenga el DbSet{Articulo} (por ejemplo DiinventarioexamenContext).
        /// </summary>
        public async Task<bool> IsNumserieUniqueAsync(String Numserie)
        {
            // Si no hay número de serie consideramos que no hay conflicto aquí (ajusta según tu lógica)
            if (string.IsNullOrWhiteSpace(Numserie)) return true;

            try
            {
                var exists = await _context
                    .Set<Articulo>()
                    .AsNoTracking()
                    .AnyAsync(a => a.Numserie == Numserie)
                    .ConfigureAwait(false);

                return !exists;
            }
            catch (Exception ex)
            {
                // Reenvía una excepción con contexto claro
                throw new InvalidOperationException("Error comprobando unicidad de Numserie.", ex);
            }
        }
    }
}
