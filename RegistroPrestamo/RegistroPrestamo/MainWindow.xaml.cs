using RegistroPrestamo.BLL;
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

namespace RegistroPrestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Prestamo LlenaClase()
        {
            Prestamo prestamo = new Prestamo();
            prestamo.PrestamoId = Convert.ToInt32(PrestamoIdTextBox.Text);
            prestamo.Fecha = FechaDatePicker.DisplayDate;
            prestamo.Monto = Convert.ToInt32(MontoTextBox.Text);
            prestamo.Semanas = Convert.ToInt32(SemanasTextBox.Text);

            return prestamo;
        }

        private void Limpiar()
        {
            PrestamoIdTextBox.Text = string.Empty;
            FechaDatePicker.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            SemanasTextBox.Text = string.Empty;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Prestamo prestamo = PrestamoBLL.Buscar((int)Convert.ToInt32(PrestamoIdTextBox.Text));
            return (prestamo != null);
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;


            Prestamo prestamo = new Prestamo();
            bool paso = false;

            if (Convert.ToInt32(PrestamoIdTextBox) == 0)
                paso = PrestamoBLL.Calcular(prestamo);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar Prestamo que no existe", "Fallo");
                    return;
                }
                paso = PrestamoBLL.Modificar(prestamo);

            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!","Exito",MessageBoxButton.OK,MessageBoxImage.Information);

            

        }

        private bool Validar()
        {
            bool paso = true;

            if(FechaDatePicker.Text == string.Empty)
            {
                FechaDatePicker.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MontoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SemanasTextBox.Text))
            {
                SemanasTextBox.Focus();
                paso = false;
            }

            return paso;
        }
    }
}
