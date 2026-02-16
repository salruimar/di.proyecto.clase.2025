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
    /// Interaction logic for UCAdministracion.xaml
    /// </summary>
    public partial class UCAdministracion : UserControl
    {

        private UCArbolEspacio _ucArbolEspacios;
        private UCArbolDepartamento _ucArbolDepartamento;
        private UCArbolGrupo _ucArbolGrupo;

        public UCAdministracion(UCArbolEspacio ucArbolEspacios,UCArbolDepartamento ucArbolDepartamento,UCArbolGrupo ucArbolGrupo)
        {
            InitializeComponent();
            _ucArbolEspacios = ucArbolEspacios;
            _ucArbolDepartamento = ucArbolDepartamento;
            _ucArbolGrupo = ucArbolGrupo;
        }

        private void btnArbolEspacios_Click(object sender, RoutedEventArgs e)
        {
            panelCentral.Children.Clear();
            panelCentral.Children.Add(_ucArbolEspacios);
        }

        private void btnArbolGrupos_Click(object sender, RoutedEventArgs e)
        {
            panelCentral.Children.Clear();
            panelCentral.Children.Add(_ucArbolGrupo);
        }

        private void btnArbolDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            panelCentral.Children.Clear();
            panelCentral.Children.Add(_ucArbolDepartamento);
        }
    }
}
