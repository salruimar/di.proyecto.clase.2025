using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using System.Windows;

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






        private List<Tipoarticulo> _listaTipoArticulos;
        private List<Usuario> _listaUsuarios;
        private List<Departamento> _listaDepartamentos;
        private List<Espacio> _listaEspacios; 
        private List<Modeloarticulo> _listaModelosArticulos; 
        #endregion
        #region Getters y Setters
        public List<Tipoarticulo> listaTiposArticulos => _listaTipoArticulos;
        public List<Usuario> listaUsuarios => _listaUsuarios;
        public List<Departamento> listaDepartamentos => _listaDepartamentos;
        public List<Espacio> listaEspacios => _listaEspacios;
        public List<Modeloarticulo> listaModelosArticulos => _listaModelosArticulos;

        public Modeloarticulo modeloArticulo
        {
            get => _modeloArticulo;
            set => SetProperty(ref _modeloArticulo, value);
        }

        public Articulo articulo
        {
            get => _articulo;
            set => SetProperty(ref _articulo, value);
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
            _modeloArticulo = new Modeloarticulo();
            _articulo = new Articulo();
        }

        public async Task Inicializa()
        {
            try
            {
                _listaTipoArticulos = await GetAllAsync<Tipoarticulo>(_tipoArticuloRepository);
                _listaUsuarios = await GetAllAsync<Usuario>(_usuarioRepository);
                _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
                _listaEspacios = await GetAllAsync<Espacio>(_espacioRepository);
                _listaModelosArticulos = await GetAllAsync<Modeloarticulo>(_modeloArticuloRepository);
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN ARTÍCULOS", "Error al cargar los tipos de artículos\n" +
                    "No puedo conectar con la base de datos", 0);
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

        public async Task<bool> GuardarArticuloAsync()
        {
            bool correcto = true;
            try
            {
                if (articulo.Idarticulo == 0)
                {
                    var lastId = await _articuloRepository.GetLastIdAsync(a => a.Idarticulo);

                    int nextId = (lastId ?? 0) + 1;
                    //articulo.Idarticulo = nextId;

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
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos en el log
                MessageBox.Show("Error al guardar el artículo:\n" + ex.Message, "GESTIÓN ARTÍCULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                correcto = false;
            }
            return correcto;
        }
    }
}
