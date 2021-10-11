using P1_AP1_Junior_20190009.BLL;
using P1_AP1_Junior_20190009.Entidades;
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

namespace P1_AP1_Junior_20190009.UI
{
    /// <summary>
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        public rAportes()
        {
            InitializeComponent();
        }


        private void Buscarbutton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Aportes aportes = new Aportes();
            int.TryParse(AportesIDTextBox.Text, out id);

            Limpiar();

            aportes = AporteBLL.Buscar(id);

            if (aportes != null)
            {
                MessageBox.Show("El aporte ha sido encontrado");
                LlenarCampos(aportes);
            }
            else
            {
                MessageBox.Show("El aporte no ha sido encontrado o no esta registrado");
            }
        }

        private void Nuevobutton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, RoutedEventArgs e)
        {
            Aportes aportes;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            aportes = LlenarClase();
            paso = AporteBLL.Guardar(aportes);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Aporte modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Aporte guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Eliminarbutton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(AportesIDTextBox.Text, out id);
            Limpiar();
            if (AporteBLL.Eliminar(id))
            {
                MessageBox.Show("Aporte eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Este ID no existe en la base de datos");
            }
        }

        private void LlenarCampos(Aportes aportes)
        {
            AportesIDTextBox.Text = aportes.AporteID.ToString();
            FechaTextBox.SelectedDate = aportes.Fecha;
            PersonaTextBox.Text = aportes.Persona;
            ConceptoTextBox.Text = aportes.Concepto;
            MontoTextBox.Text = aportes.Monto.ToString();
        }

        private Aportes LlenarClase()
        {
            Aportes aportes = new Aportes();
            aportes.AporteID = Utilidad.ToInt(AportesIDTextBox.Text);
            aportes.Fecha = (DateTime)FechaTextBox.SelectedDate;
            aportes.Persona = PersonaTextBox.Text;
            aportes.Concepto = ConceptoTextBox.Text;
            aportes.Monto = Utilidad.ToInt(MontoTextBox.Text);

            return aportes;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Aportes aportes = AporteBLL.Buscar(Utilidad.ToInt(AportesIDTextBox.Text));

            return (aportes!= null);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (PersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void Limpiar()
        {
            AportesIDTextBox.Text = string.Empty;
            FechaTextBox.SelectedDate = DateTime.Now;
            PersonaTextBox.Text = string.Empty;
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;;
        }
    }
}
