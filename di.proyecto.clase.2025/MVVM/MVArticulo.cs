using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using System.Windows;
using System.Windows.Data;

namespace di.proyecto.clase._2025.MVVM
{
    public class MVArticulo : MVBase
    {
        #region Campos y propiedades privadas
        /// <summary>
        /// Objeto que guarda el modelo de artículo actual
        /// Está vinculado a la vista para mostrar y editar los datos del artículo
        /// </summary>
        private Modeloarticulo _modeloArticulo;

        private Articulo _articulo;

        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los modelos de artículo
        /// </summary>
        private ModeloArticuloRespository _modeloArticuloRepository;
        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los tipos de artículo
        /// </summary>
        private TipoArticuloRepository _tipoArticuloRepository;
        /// <summary>
        /// lista de tipos de artículos disponibles
        /// </summary>

        private UsuarioRepository _usuarioRepository;

        private ArticuloRepository _articuloRepository;

        private DepartamentoRepository _departamentoRepository;

        private EspacioRepository _espacioRepository;

        private Resultado _resultadoGuardarArticulo;

        //cosas de filtros
        private Tipoarticulo _tipoArticuloSeleccionado;
        private List<Predicate<Modeloarticulo>> _criteriosModelo;
        private Predicate<Modeloarticulo> _criteriosTipoArticulo;

        private DateTime _fechaInicioFiltro = DateTime.Now;
        private DateTime _fechaFinFiltro = DateTime.Now;
        private Espacio _espacioSeleccionado;
        private String _numSerieFiltro;
        private int? _numSalidasFiltro;
        private int _maxSalidasFiltro;
        private List<Predicate<Articulo>> _criteriosArticulo;
        private Predicate<Articulo> _criteriosFechaAlta;
        private Predicate<Articulo> _criteriosNumSerie;
        private Predicate<Articulo> _criteriosEspacio;
        private Predicate<Articulo> _criterioNumSalidas;

        //listas
        private List<Tipoarticulo> _listaTipoArticulos;
        private List<Usuario> _listaUsuarios;
        private List<Departamento> _listaDepartamentos;
        private List<Espacio> _listaEspacios; 
        private List<Modeloarticulo> _listaModelosArticulos; 
        private List<Articulo> _listaArticulos; 
        #endregion

        #region Getters y Setters
        public List<Tipoarticulo> listaTiposArticulos => _listaTipoArticulos;
        public List<Usuario> listaUsuarios => _listaUsuarios;
        public List<Departamento> listaDepartamentos => _listaDepartamentos;
        public List<Espacio> listaEspacios => _listaEspacios;
        public ListCollectionView listaModelosArticulos { get; set; }
        public ListCollectionView listaArticulos { get; set; }

        public Predicate<object> predicadoFiltroModeloArticulo;
        public Predicate<object> predicadoFiltroArticulo;

        public Modeloarticulo modeloArticulo
        {
            get => _modeloArticulo;
            set { _modeloArticulo = value;
            OnPropertyChanged(nameof(modeloArticulo)) ;}
        }

        public Articulo articulo
        {
            get => _articulo;
            set => SetProperty(ref _articulo, value);
        }

        public Resultado resultadoGuardarArticulo
        {
            get => _resultadoGuardarArticulo;
            set => SetProperty(ref _resultadoGuardarArticulo, value);
        }

        public Tipoarticulo tipoArticuloSeleccionado
        {
            get => _tipoArticuloSeleccionado;
            set => SetProperty(ref _tipoArticuloSeleccionado, value);
        }

        public DateTime fechaInicioFiltro
        {
            get => _fechaInicioFiltro;
            set => SetProperty(ref _fechaInicioFiltro, value);
        }

        public DateTime fechaFinFiltro
        {
            get => _fechaFinFiltro;
            set => SetProperty(ref _fechaFinFiltro, value);
        }

        public Espacio espacioSeleccionado
        {
            get => _espacioSeleccionado;
            set => SetProperty(ref _espacioSeleccionado, value);
        }

        public String numSerieFiltro
        {
            get => _numSerieFiltro;
            set => SetProperty(ref _numSerieFiltro, value);
        }

        public int? numSalidasFiltro
        {
            get => _numSalidasFiltro;
            set => SetProperty(ref _numSalidasFiltro, value);
        }
        public int maxSalidasFiltro
        {
            get => _maxSalidasFiltro;
            private set => SetProperty(ref _maxSalidasFiltro, value);
        }

        #endregion
        // Aquí puedes añadir propiedades y métodos específicos para el ViewModel de Artículo
        public MVArticulo(ModeloArticuloRespository modeloArticuloRepository,
                          TipoArticuloRepository tipoArticuloRepository,
                          UsuarioRepository usuarioRepository,
                          ArticuloRepository articuloRepository,
                          DepartamentoRepository departamentoRepository,
                          EspacioRepository espacioRepository) 
        {
            _modeloArticuloRepository = modeloArticuloRepository;
            _tipoArticuloRepository = tipoArticuloRepository;
            _usuarioRepository = usuarioRepository;
            _articuloRepository = articuloRepository;
            _departamentoRepository = departamentoRepository;
            _espacioRepository = espacioRepository;
        }

        public async Task Inicializa()
        {
            try
            {


                 predicadoFiltroModeloArticulo = new Predicate<object>(FiltroCriteriosModeloArticulo);
                 predicadoFiltroArticulo = new Predicate<object>(FiltroCriteriosArticulo);

                _listaTipoArticulos = await GetAllAsync<Tipoarticulo>(_tipoArticuloRepository);
                _listaUsuarios = await GetAllAsync<Usuario>(_usuarioRepository);
                _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
                _listaEspacios = await GetAllAsync<Espacio>(_espacioRepository);
                _listaModelosArticulos = await GetAllAsync<Modeloarticulo>(_modeloArticuloRepository);
                listaModelosArticulos = new ListCollectionView(_listaModelosArticulos);
                _listaArticulos = await GetAllAsync<Articulo>(_articuloRepository);
                listaArticulos = new ListCollectionView(_listaArticulos);

                _criteriosModelo = new List<Predicate<Modeloarticulo>>();
                _criteriosArticulo = new List<Predicate<Articulo>>();


                CalculaMaxSalidasFiltro();
                InicializaCriterios();
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN ARTÍCULOS", "Error al cargar los tipos de artículos\n" +
                    "No puedo conectar con la base de datos", 0);
            }
        }

        private void InicializaCriterios()
        {
            _criteriosTipoArticulo = new Predicate<Modeloarticulo>(m => m.TipoNavigation != null 
            && m.TipoNavigation.Equals(_tipoArticuloSeleccionado));

            _criteriosFechaAlta = new Predicate<Articulo>(a => a.Fechaalta >= fechaInicioFiltro && a.Fechaalta <= fechaFinFiltro); 
            _criteriosNumSerie = new Predicate<Articulo>(a => a.Numserie != null && a.Numserie.Equals(_numSerieFiltro));
            _criteriosEspacio = new Predicate<Articulo>(a => a.EspacioNavigation != null && a.EspacioNavigation.Equals(_espacioSeleccionado));
            _criterioNumSalidas = new Predicate<Articulo>(a => a.Salida.Count == _numSalidasFiltro);
        }

        private void AddCriterios()
        {
            _criteriosModelo.Clear();
            if (_tipoArticuloSeleccionado != null)
            {
                _criteriosModelo.Add(_criteriosTipoArticulo);
            }
            
            _criteriosArticulo.Clear();
            if (_fechaInicioFiltro.Day != DateTime.Now.Day && _fechaFinFiltro.Day != DateTime.Now.Day && _fechaInicioFiltro < _fechaFinFiltro)
            {
                _criteriosArticulo.Add(_criteriosFechaAlta);
            }
            if (!String.IsNullOrEmpty(_numSerieFiltro))
            {
                _criteriosArticulo.Add(_criteriosNumSerie);
            }
            if (_espacioSeleccionado != null)
            {
                _criteriosArticulo.Add(_criteriosEspacio);
            }
            if (_numSalidasFiltro != null)
            {
                _criteriosArticulo.Add(_criterioNumSalidas);
            }
        }

        private bool FiltroCriteriosModeloArticulo(object item)
        {
            bool correcto = true;
            Modeloarticulo modelo = (Modeloarticulo)item;

            if (_criteriosModelo != null)
            {
                correcto = _criteriosModelo.TrueForAll(criterio => criterio(modelo));
            }

            return correcto;
        }

        private bool FiltroCriteriosArticulo(object item)
        {
            bool correcto = true;
            Articulo articulo = (Articulo)item;

            if (_criteriosModelo != null)
            {
                correcto = _criteriosArticulo.TrueForAll(criterio => criterio(articulo));
            }

            return correcto;
        }

        public void Filtrar()
        {
            AddCriterios();
            listaModelosArticulos.Filter = predicadoFiltroModeloArticulo;
            listaArticulos.Filter = predicadoFiltroArticulo;
        }

        public void LimpiarFiltros()
        {
            tipoArticuloSeleccionado = null;
            listaModelosArticulos.Filter = null;

            fechaInicioFiltro = DateTime.Now;
            fechaFinFiltro = DateTime.Now;
            numSerieFiltro = null;
            espacioSeleccionado = null;
            numSalidasFiltro = null;
            listaArticulos.Filter = null;
        }

        public void CalculaMaxSalidasFiltro()
        {
            try
            {
                if (listaArticulos == null)
                {
                    maxSalidasFiltro = 0;
                    return;
                }

                // Enumeramos la vista (items actualmente visibles en listaArticulos)
                var max = listaArticulos
                    .OfType<Articulo>()
                    .Select(a => a.Salida?.Count ?? 0)
                    .DefaultIfEmpty(0)
                    .Max();

                maxSalidasFiltro = max;
            }
            catch
            {
                // En caso de error dejamos 0 (no lanzar para no romper la UI)
                maxSalidasFiltro = 0;
            }
        }
        public async Task<bool> GuardarModeloArticuloAsync()
        {
            bool correcto = true;
            try
            {
                if (modeloArticulo.Idmodeloarticulo == 0)
                {
                    // Nuevo modelo de artículo
                    await _modeloArticuloRepository.AddAsync(modeloArticulo);
                }
                else
                {
                    // Actualizar modelo de artículo existente
                    await _modeloArticuloRepository.UpdateAsync(modeloArticulo);
                }
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos en el log
                correcto = false;
            }
            return correcto;
        }


       public enum Resultado
        {
            Correcto,
            ErrorInsert,
            ErrorNumSerieDuplicado
        }

        public async Task<Resultado> GuardarArticuloAsync()
        {
            _resultadoGuardarArticulo = Resultado.Correcto;

            try
            {

                bool numSerieUnico = await _articuloRepository.IsNumserieUniqueAsync(articulo.Numserie);
                if (!numSerieUnico)
                {
                    _resultadoGuardarArticulo = Resultado.ErrorNumSerieDuplicado;
                } else
                {
                    if (articulo.Idarticulo == 0)
                    {

                        IEnumerable<Articulo> allArticulos = await _articuloRepository.GetAllAsync();
                        var codigo = allArticulos.Last<Articulo>().Idarticulo + 1;
                        articulo.Idarticulo = 5009;

                        await _articuloRepository.AddAsync(articulo);
                    }
                    else
                    {
                        await _articuloRepository.UpdateAsync(articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos en el log
                MessageBox.Show("Error al guardar el artículo:\n" + ex.Message, "GESTIÓN ARTÍCULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                _resultadoGuardarArticulo = Resultado.ErrorInsert;
            }
            return _resultadoGuardarArticulo;
        }
    }
}
