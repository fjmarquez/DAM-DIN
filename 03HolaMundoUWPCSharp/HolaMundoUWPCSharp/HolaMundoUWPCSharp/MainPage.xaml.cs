using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace HolaMundoUWPCSharp
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

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Modal que saluda segun el nombre que hayamos insertado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void ButtonClicked(object sender, RoutedEventArgs e)
        {
            /*
            this.lblAviso.Text = "";
            String nombre = this.txtNombre.Text;


            if (nombre.Length > 0)
            {
                ContentDialog saludarDialog = new ContentDialog
                {
                    Title = "Saludar",
                    Content = ("Hola " + nombre),
                    CloseButtonText = "Adios"
                };

                ContentDialogResult result = await saludarDialog.ShowAsync();
            }
            else
            {
                this.lblAviso.Text = "Debes introducir un nombre.";
            }
            */

            persona p1;
            

            if (txtNombre.Text.Length > 0)
            {
                p1 = new persona(txtNombre.Text);

                ContentDialog saludarDialog = new ContentDialog
                {
                    Title = "Saludar",
                    Content = ("Hola " + p1.Nombre),
                    CloseButtonText = "Adios"
                };

                ContentDialogResult result = await saludarDialog.ShowAsync();
            }
            else
            {
                this.lblAviso.Text = "Debes introducir un nombre.";
            }

        }
    }
}
