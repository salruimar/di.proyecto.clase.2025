using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using System.Windows;

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private UsuarioRepository _usuarioRepo;
        private MainWindow _ventanaPrincipal;

        public Login(UsuarioRepository usuarioRepo, MainWindow ventanaPrincipal)
        {
            InitializeComponent();
            _usuarioRepo = usuarioRepo;
            _ventanaPrincipal = ventanaPrincipal;
        }



        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
               
                bool loginCorrecto = await _usuarioRepo.LoginAsync(txtUsuario.Text, passClave.Password);
                if (loginCorrecto)
                {
                    Usuario usuLogin = await _usuarioRepo.GetByUsernameAsync(txtUsuario.Text);
                    _ventanaPrincipal.Show();
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
