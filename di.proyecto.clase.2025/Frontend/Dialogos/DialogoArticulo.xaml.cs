using di.proyecto.clase._2025.MVVM;
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
    /// Interaction logic for DialogoArticulo.xaml
    /// </summary>
    public partial class DialogoArticulo : MetroWindow
    {

        private MVArticulo _mvArticulo;

        public DialogoArticulo(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            DataContext = _mvArticulo;
        }

        private void btnCancelarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _mvArticulo.GuardarArticuloAsync();


                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el modelo de artículo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
