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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Solarizr
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Al hacer click sobre algun elemnto de la lista, se abrira la vista propia de la cita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listaCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(Cita));
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Al hacer click sobre el logo volveremos a la pagina anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stkLogo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            On_BackRequested();
        }
    }
}
