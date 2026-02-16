using di.proyecto.clase._2025.MVVM;
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
    /// Interaction logic for UCArbolDepartamento.xaml
    /// </summary>
    public partial class UCArbolDepartamento : UserControl
    {
        private MVDepartamento _mvDepartamento;
        public UCArbolDepartamento(MVDepartamento mvDepartamento)
        {
            _mvDepartamento = mvDepartamento;
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvDepartamento.Inicializa();
            DataContext = _mvDepartamento;
        }
    }
}
