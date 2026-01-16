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
    /// Interaction logic for UCUsuarios.xaml
    /// </summary>
    public partial class UCUsuarios : UserControl
    {
        private DialogoUsuario _dialogoUsuario;
        private readonly IServiceProvider _serviceProvider;

        public UCUsuarios(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            _dialogoUsuario = _serviceProvider.GetRequiredService<DialogoUsuario>();
            _dialogoUsuario.ShowDialog();
        }
    }
}
