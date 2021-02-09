using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _08LayoutsE6
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Se ejecuta al hacer click sobre el boton 'Add', su funcion es vaciar los TextBox indicados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            AppBarButton btnAdd = (AppBarButton)sender;
            btnAdd.Background = new SolidColorBrush(Windows.UI.Colors.Aqua);
            tbNombre.Text = "";
            tbApellidos.Text = "";
            tbFechaNacimiento.Text = "";
        }

        /// <summary>
        /// Se ejecuta al hacer click sobre el boton 'Save', su funcion es validar los TextBox y mostrar un mensaje de error o aprobacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            String nombre = tbNombre.Text;
            String apellidos = tbApellidos.Text;
            String fechaNacimiento = tbFechaNacimiento.Text;
            int contador = 0;
            String mensajeError = "Este campo no puede estar vacio";

            reiniciarErrores();

            if (nombre.Length > 0)
            {
                contador++;
            }
            else
            {
                txtErrorNombre.Text = mensajeError;
            }

            if (apellidos.Length > 0)
            {
                contador++;
            }
            else
            {
                txtErrorApellidos.Text = mensajeError;
            }

            if (fechaNacimiento.Length > 0)
            {
                contador++;
            }
            else
            {
                txtErrorFechaNacimiento.Text = mensajeError;
            }

            comprobarErrores(contador);

        }

        /// <summary>
        /// Muestra un mensaje de aprobacion si todos los campos estan rellenos
        /// </summary>
        /// <param name="errores"></param>
        private void comprobarErrores(int errores)
        {

            txtCorrecto.Text = "";
            String mensajeCorrecto = "Todos los datos han sido introducidos";

            if (errores == 3)
            {
                txtCorrecto.Text = mensajeCorrecto;
            }
        }

        /// <summary>
        /// Vacia los campos TextBlock
        /// </summary>
        private void reiniciarErrores()
        {
            txtErrorNombre.Text = txtErrorApellidos.Text = txtErrorFechaNacimiento.Text = "";
        }

        /// <summary>
        /// Se ejecuta al hacer click sobre el boton 'Delete', su funcion es comprobar si los campos estan rellenados
        /// y mostrar un mensaje si se cumple la condicion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "¿Eliminar el usuario?",
                Content = "Estas a punto de eliminar un usuario, ¿Estas Seguro?",
                PrimaryButtonText = "Si",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {

                String nombre = tbNombre.Text;
                String apellidos = tbApellidos.Text;
                String fechaNacimiento = tbFechaNacimiento.Text;
                String mensajeUsuarioEliminado = "Usuario eliminado correctamente";

                if ( nombre.Length > 0 && apellidos.Length > 0 && fechaNacimiento.Length > 0)
                {
                    tbNombre.Text = "";
                    tbApellidos.Text = "";
                    tbFechaNacimiento.Text = "";

                    txtCorrecto.Text = mensajeUsuarioEliminado;
                }

                
            }
        }
    }
}
