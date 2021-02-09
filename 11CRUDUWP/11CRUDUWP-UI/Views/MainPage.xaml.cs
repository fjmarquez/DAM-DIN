using _11CRUDUWP_UI.Views;
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

namespace _11CRUDUWP_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            NavigationViewControl.IsPaneOpen = false;

            mainFrame.Navigate(typeof(welcome));
        }

        private void item_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string selected = ((ContentControl)sender).Content.ToString();

            if (selected == "Personas")
            {
                mainFrame.Navigate(typeof(personas));
            }
            else if (selected == "Departamentos")
            {
                mainFrame.Navigate(typeof(departamentos));
            }

        }
    }
}
