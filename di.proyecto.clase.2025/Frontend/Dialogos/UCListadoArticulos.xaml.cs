using di.proyecto.clase._2025.MVVM;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for UCListadoArticulos.xaml
    /// </summary>
    public partial class UCListadoArticulos : UserControl
    {
        private MVArticulo _mvArticulo;
        private readonly IServiceProvider _serviceProvider;
        private DialogoArticulo _dialogoArticulo;
        public UCListadoArticulos(MVArticulo mvArticulo, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
            _serviceProvider = serviceProvider;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.DataContext = _mvArticulo;
        }

        private async void EditarArticulo_Click(object sender, RoutedEventArgs e)
        {
            _dialogoArticulo = _serviceProvider.GetRequiredService<DialogoArticulo>();
            await _dialogoArticulo.Inicializa(_mvArticulo.articulo);

            _dialogoArticulo.ShowDialog();

            if (_dialogoArticulo.DialogResult == true)
            {
                //Refrescar la lista de artículos
                _mvArticulo.listaArticulos.Refresh();
            }
        }

        private void EliminarArticulo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            _mvArticulo.LimpiarFiltros();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            _mvArticulo.Filtrar();
        }
    }
}
