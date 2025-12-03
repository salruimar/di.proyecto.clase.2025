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
    /// Interaction logic for UCArticulos.xaml
    /// </summary>
    public partial class UCArticulos : UserControl
    {
        private DialogoModeloArticulo _dialogoModeloArticulo;
        private DialogoArticulo _dialogoArticulo;
        private readonly IServiceProvider _serviceProvider;

        public UCArticulos(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnAgregarModelo_Click(object sender, RoutedEventArgs e)
        {
            _dialogoModeloArticulo = _serviceProvider.GetRequiredService<DialogoModeloArticulo>();
            _dialogoModeloArticulo.ShowDialog();
        }

        private void btnAgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            _dialogoArticulo = _serviceProvider.GetRequiredService<DialogoArticulo>();
            _dialogoArticulo.ShowDialog();
        }
    }
}
