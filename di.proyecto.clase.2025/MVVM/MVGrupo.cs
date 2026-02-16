using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.MVVM
{
    public class MVGrupo : MVBase
    {
        private GrupoRepository _grupoRepository;

        public MVGrupo(GrupoRepository grupoRepository) { 
            _grupoRepository = grupoRepository;
        }

        public async Task Inicializa()
        {

        }

    }
}
