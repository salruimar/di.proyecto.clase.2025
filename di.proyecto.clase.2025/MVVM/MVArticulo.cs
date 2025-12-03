using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.MVVM
{
    public class MVArticulo : MVBase
    {
        #region Campos y propiedades privadas
        // Aquí irán las propiedades y métodos específicos del ViewModel de Artículo

        /// <summary>
        /// Objeto que guarda el modelo de articulo actual
        /// Está vinculado a la visdta para mostrar y editar los datos del artículo
        /// </summary>

        private Modeloarticulo _modeloArticulo;

        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los modelos de artículo
        /// </summary>

        private ModeloArticuloRespository _modeloArticuloRepository;

        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los tipos de artículo
        /// </summary>

        private TipoArticuloRepository _tipoArticuloRepository;

        private List<Tipoarticulo> _listaTipoArticulo;

        public List<Tipoarticulo> listaTipoArticulo => _listaTipoArticulo;

        #endregion


        #region Getters y Setters

        public Modeloarticulo modeloArticulo
        {

            get => _modeloArticulo;
            set => SetProperty(ref _modeloArticulo, value);
        }

        #endregion

        //Aquí puedes añadir propiedades y métodos específicos para el viewModel de artículo
        public MVArticulo(ModeloArticuloRespository modeloArticuloRespository,
                            TipoArticuloRepository tipoArticuloRepository)
        {
            _modeloArticuloRepository = modeloArticuloRespository;
            _tipoArticuloRepository = tipoArticuloRepository;
            _modeloArticulo = new Modeloarticulo();
        }

        public async Task Inicializa()
        {
            _listaTipoArticulo = await GetAllAsync<Tipoarticulo>(_tipoArticuloRepository);
        }

    }
}
