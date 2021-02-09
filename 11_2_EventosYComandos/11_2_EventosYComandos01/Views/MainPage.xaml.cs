using _11_2_EventosYComandos01.Models;
using _11_2_EventosYComandos01.ViewModels;
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

namespace _11_2_EventosYComandos01
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageVM ViewModel { get; }
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new MainPageVM();

            //ViewModel.EliminarCommand.RaiseCanExecuteChanged();
        }

        async void lista_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //codigo para seleccionar item correspondiente en la lista textblock
            //lista.SelectedItem = (sender as FrameworkElement).DataContext;

            //codigo para seleccionar item correspondiente en la listview
            ViewModel.PersonaSeleccionada = (clsPersona)((FrameworkElement)e.OriginalSource).DataContext;
        }
    }
}
