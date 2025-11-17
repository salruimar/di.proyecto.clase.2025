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
        public UCArticulos()
        {
            InitializeComponent();
        }

        private void btnAgregarModelo_Click(object sender, RoutedEventArgs e)
        {
            DialogoModeloArticulo dialogo = new DialogoModeloArticulo();
            dialogo.ShowDialog();
        }

        private void btnAgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogoArticulo dialogo = new DialogoArticulo();
            dialogo.ShowDialog();
        }
    }
}
