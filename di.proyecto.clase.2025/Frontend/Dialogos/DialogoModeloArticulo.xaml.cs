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
        private DiinventarioexamenContext _context;
        private ILogger<GenericRepository<Modeloarticulo>> _logger; 
        private ModeloArticuloRespository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;
        public DialogoModeloArticulo()
        {
            InitializeComponent();
        }

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            _context = new DiinventarioexamenContext();
            _logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Modeloarticulo>>();
            _modeloArticuloRepository = new ModeloArticuloRespository(_context, _logger);
            _tipoArticuloRepository = new TipoArticuloRepository(_context, null);

            //Cargamos los tipos de artículo en el ComboBox
            List<Tipoarticulo> tipos = await _tipoArticuloRepository.GetAllAsync();
            cmbTipoArticulo.ItemsSource = tipos;
        }

        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            Modeloarticulo modeloarticulo = new Modeloarticulo();
            RecogeDatos(modeloarticulo);

            try
            {
                await _modeloArticuloRepository.AddAsync(modeloarticulo);
                _context.SaveChanges();
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
