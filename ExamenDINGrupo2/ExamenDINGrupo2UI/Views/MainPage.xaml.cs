using ExamenDINGrupo2UI.ViewModels;
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

namespace ExamenDINGrupo2UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public loginVM ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new loginVM();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            string btnPress = btn.Content.ToString();

            if(btnPress == "Clear")
            {
                tbPin.Text = "";
            }
            else if(btnPress == "Delete")
            {
                string tbPinValue = tbPin.Text;

                string deleteLastChar = tbPinValue.Remove(tbPinValue.Length - 1, 1);

                tbPin.Text = deleteLastChar;
            }else
            {
                string tbValue = tbPin.Text;

                tbPin.Text = tbValue + btnPress;
            }

            

        }
    }
}
