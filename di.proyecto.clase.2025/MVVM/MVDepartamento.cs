using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.MVVM
{
    public class MVDepartamento : MVBase
    {
        private DepartamentoRepository _departamentoRepository;
        private List<Departamento> _listaDepartamentos;

        public List<Departamento> listaDepartamentos => _listaDepartamentos;

        public MVDepartamento(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task Inicializa()
        {
            try
            {
                _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN DEPARTAMENTOS", "Error al cargar los departamentos\n" +
                    "No puedo conectar con la base de datos", 0);
            }
        }
    }
}
