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
    public class MVEspacio : MVBase
    {

        private Articulo _articuloSeleccionado;

        private EspacioRepository _espacioRepository;
        private ArticuloRepository _articuloRepository;
        private UsuarioRepository _usuarioRepository;
        private ModeloArticuloRespository _modeloArticuloRespository;
        private DepartamentoRepository _departamentoRepository;

        private List<Departamento> _listaDepartamentos;
        private List<Usuario> _listaUsuarios;
        private List<Modeloarticulo> _listaModelos;
        private List<Espacio> _listaEspacios;

        public List<Espacio> listaEspacios => _listaEspacios;
        public List<Departamento> listaDepartamentos => _listaDepartamentos;
        public List<Usuario> listaUsuarios => _listaUsuarios;
        public List<Modeloarticulo> listaModelos => _listaModelos;

        public Articulo articuloSeleccionado
        {
            get => _articuloSeleccionado;
            set => SetProperty(ref _articuloSeleccionado, value);
        }

        public MVEspacio(EspacioRepository espacioRepository, UsuarioRepository usuarioRepository, ModeloArticuloRespository modeloArticuloRespository, 
            DepartamentoRepository departamentoRepository, ArticuloRepository articuloRepository)
        {
            _espacioRepository = espacioRepository;
            _usuarioRepository = usuarioRepository;
            _modeloArticuloRespository = modeloArticuloRespository;
            _departamentoRepository = departamentoRepository;
            _articuloRepository = articuloRepository;
        }

        public async Task Inicializar()
        {
            try
            {
                _listaEspacios = await GetAllAsync<Espacio>(_espacioRepository);
                _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
                _listaUsuarios = await GetAllAsync<Usuario>(_usuarioRepository);
                _listaModelos = await GetAllAsync<Modeloarticulo>(_modeloArticuloRespository);
                
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN ESPACIOS", "Error al cargar losespacios\n" +
                    "No puedo conectar con la base de datos", 0);
            }
           
        }

    }
}
