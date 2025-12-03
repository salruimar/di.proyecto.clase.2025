using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace di.proyecto.clase._2025.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoModeloArticulo.xaml
    /// </summary>
    public partial class DialogoModeloArticulo : MetroWindow
    {
        private ModeloArticuloRespository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;
        public DialogoModeloArticulo(DiinventarioexamenContext context,ModeloArticuloRespository modeloArticuloRepository, TipoArticuloRepository tipoArticuloRepository)
        {
            InitializeComponent();

            _modeloArticuloRepository = modeloArticuloRepository;
            _tipoArticuloRepository = tipoArticuloRepository;
        }

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargamos los tipos de artículo en el ComboBox
            cmbTipoArticulo.ItemsSource = await _tipoArticuloRepository.GetAllAsync();
        }

        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            Modeloarticulo modeloarticulo = new Modeloarticulo();
            RecogeDatos(modeloarticulo);

            try
            {
                await _modeloArticuloRepository.AddAsync(modeloarticulo);
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

        private void RecogeDatos(Modeloarticulo modeloarticulo)
        {
            modeloarticulo.Nombre = txtNombre.Text;
            modeloarticulo.Descripcion = txtDescripcion.Text;
            modeloarticulo.Marca = txtMarca.Text;
            modeloarticulo.Modelo = txtModelo.Text;

            if (cmbTipoArticulo.SelectedItem != null)
            {
                modeloarticulo.TipoNavigation = (Tipoarticulo)cmbTipoArticulo.SelectedItem;
            }

        }

    }
}
