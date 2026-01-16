using di.proyecto.clase._2025.MVVM;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using MahApps.Metro.Controls;
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

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoUsuario.xaml
    /// </summary>
    public partial class DialogoUsuario : MetroWindow
    {
        private MVUsuario _mvUsuario;
        public DialogoUsuario(MVUsuario mvUsuario)
        {
            InitializeComponent();
            _mvUsuario = mvUsuario;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvUsuario.Inicializa();
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvUsuario.OnErrorEvent));
            DataContext = _mvUsuario;
        }

        private async void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!_mvUsuario.IsValid(this))
            {
                MensajeError.Mostrar("MODELO ARTÍCULO", "Existen errores de validación. Por favor, corríjalos antes de guardar.");
            } else
            {

                try
                {
                    _mvUsuario.GuardarUsuarioAsync();


                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el modelo de artículo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
