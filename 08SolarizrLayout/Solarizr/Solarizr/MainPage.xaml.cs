using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Solarizr
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
        /// Comprobamos que los TB de usuario y contraseña no estan vacios, si lo estan muestra un mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbUsuario.Text.Length > 0)
            {
                if (tbContraseña.Password.Length > 0)
                {
                    Frame.Navigate(typeof(Menu));
                }
                else
                {
                    ContentDialog contraseñaVacia = new ContentDialog
                    {
                        Title = "No puede dejar un campo vacio",
                        Content = ("El campo contraseña esta vacio."),
                        CloseButtonText = "Cerrar"
                    };

                    ContentDialogResult result = await contraseñaVacia.ShowAsync();
                }

            }
            else
            {
                ContentDialog usuarioVacio = new ContentDialog
                {
                    Title = "No puede dejar un campo vacio",
                    Content = ("El campo usuario esta vacio."),
                    CloseButtonText = "Cerrar"
                };

                ContentDialogResult result = await usuarioVacio.ShowAsync();
            }

            
        }
    }
}
