using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.MVVM;
using DI.tema2.ejercicio7.Frontend.Mensajes;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoModeloArticulo.xaml
    /// </summary>
    public partial class DialogoModeloArticulo : MetroWindow
    {
        private MVArticulo _mvArticulo;

        public DialogoModeloArticulo(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
            
        }

        public async Task Inicializa(Modeloarticulo modeloarticulo)
        {
            await _mvArticulo.Inicializa();
            _mvArticulo.modeloArticulo = modeloarticulo;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvArticulo.OnErrorEvent));
            DataContext = _mvArticulo;
        }

        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            //otra posibilidad de impedir que se guarde si hay errores de validacion es usando
            if (!_mvArticulo.IsValid(this))
            {
                MensajeError.Mostrar("MODELO ARTÍCULO", "Existen errores de validación. Por favor, corríjalos antes de guardar.");
            }


            try
            {
               _mvArticulo.GuardarModeloArticuloAsync();


                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el modelo de artículo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
