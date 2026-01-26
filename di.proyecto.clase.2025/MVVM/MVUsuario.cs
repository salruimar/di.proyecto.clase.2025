using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM.Base;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using System.Security.Cryptography.X509Certificates;

namespace di.proyecto.clase._2025.MVVM
{
    public class MVUsuario : MVBase
    {
        #region Campos y propiedades privadas
        /// <summary>
        /// Objeto que guarda el modelo de artículo actual
        /// Está vinculado a la vista para mostrar y editar los datos del artículo
        /// </summary>
#region Campos y propiedades privadas
        private Usuario _usuario;

        private UsuarioRepository _usuarioRepository;
        private TipoUsuarioRepository _tipoUsuarioRepository;
        private RolRepository _rolRepository;
        private DepartamentoRepository _departamentoRepository;
        private GrupoRepository _grupoRepository;

        private List<Tipousuario> _listaTiposUsuarios;
        private List<Rol> _listaRoles;
        private List<Departamento> _listaDepartamentos;
        private List<Grupo> _listaGrupos;

        private List<Usuario> _listaUsuarios;

        #endregion

        //Getters y setters de listas y acabar constructor y init
        #region getters y setters
        public List<Tipousuario> listaTiposUsuarios => _listaTiposUsuarios;
        public List<Rol> listaRoles => _listaRoles;
        public List<Departamento> listaDepartamentos => _listaDepartamentos;
        public List<Grupo> listaGrupos => _listaGrupos;

        public List<Usuario> listaUsuarios => _listaUsuarios;

        public Usuario usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }
        #endregion






        #endregion
        // Aquí puedes añadir propiedades y métodos específicos para el ViewModel de Artículo
        public MVUsuario(UsuarioRepository usuarioRepository,
            TipoUsuarioRepository tipoUsuarioRepository,
            RolRepository rolRepository,
            DepartamentoRepository departamentoRepository,
            GrupoRepository grupoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _rolRepository = rolRepository;
            _departamentoRepository = departamentoRepository;
            _grupoRepository = grupoRepository;
            _usuario = new Usuario();
        }

        public async Task Inicializa()
        {
            try
            {
               _listaDepartamentos = await GetAllAsync<Departamento>(_departamentoRepository);
                _listaTiposUsuarios = await GetAllAsync<Tipousuario>(_tipoUsuarioRepository);
                _listaRoles = await GetAllAsync<Rol>(_rolRepository);
                _listaGrupos = await GetAllAsync<Grupo>(_grupoRepository);
                _listaUsuarios = await GetAllAsync<Usuario>(_usuarioRepository);
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN USUARIOS", "Error al cargar los tipos de usuario y rol", 0);
            }
        }

        public async Task<bool> GuardarUsuarioAsync()
        {
            bool correcto = true;
            try
            {
                if (usuario.Idusuario == 0)
                {
                    // Nuevo modelo de artículo
                    await _usuarioRepository.AddAsync(usuario);
                }
                else
                {
                    // Actualizar modelo de artículo existente
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch (Exception ex)
            {
                // Capturamos la excepción y la registramos en el log
                correcto = false;
            }
            return correcto;
        }


    }
}
