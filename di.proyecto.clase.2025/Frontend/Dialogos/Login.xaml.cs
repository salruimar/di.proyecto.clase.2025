using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private DiinventarioexamenContext _context;
        private UsuarioRepository _usuarioRepo;
        private ILogger<GenericRepository<Usuario>> _logger;

        public Login()
        {
            InitializeComponent();
        }

        private void ventana_Loaded(object sender, RoutedEventArgs e)
        {
            _context = new DiinventarioexamenContext();
            _logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Usuario>>();
            _usuarioRepo = new UsuarioRepository(_context, _logger);
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
               
                bool loginCorrecto = await _usuarioRepo.LoginAsync(txtUsuario.Text, passClave.Password);
                if (loginCorrecto)
                {
                    Usuario usuLogin = await _usuarioRepo.GetByUsernameAsync(txtUsuario.Text);
                    MainWindow ventanaPrincipal = new MainWindow();
                    ventanaPrincipal.Show();
                    this.Close();
                } else {
                    MessageBox.Show("Usuario o clave incorrectos.", "Error de autenticación", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Por favor, introduzca usuario y clave.", "Error de autenticación", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
