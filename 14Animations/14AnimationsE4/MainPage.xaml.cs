using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Timers;
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

namespace _14AnimationsE4
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        double playerYPosition;
        double playerXPosition;
        int steps = 20;
        bool upMovement;
        bool downMovement;
        bool rightMovement;
        bool leftMovement;
        Timer timer = new Timer {  Interval = 50};

        public MainPage()
        {
            this.InitializeComponent();
            animacionEstrellas.Begin();
            start();
        }

        private void start()
        {
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }




        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            playerYPosition = (double)halcon.GetValue(Canvas.TopProperty);
            playerXPosition = (double)halcon.GetValue(Canvas.LeftProperty);

            if (args.VirtualKey == Windows.System.VirtualKey.Up)
            {
                upMovement = true;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Right)
            {
                rightMovement = true;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Down)
            {
                downMovement = true;
            }
            else if(args.VirtualKey == Windows.System.VirtualKey.Left)
            {
                leftMovement = true;
            }
            movePlayer();
            timer.Start();
        }


        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            playerYPosition = (double)halcon.GetValue(Canvas.TopProperty);
            playerXPosition = (double)halcon.GetValue(Canvas.LeftProperty);

            if (args.VirtualKey == Windows.System.VirtualKey.Up)
            {
                upMovement = false;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Right)
            {
                rightMovement = false;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Down)
            {
                downMovement = false;
            }
            else if (args.VirtualKey == Windows.System.VirtualKey.Left)
            {
                leftMovement = false;
            }
            movePlayer();
            //setAllFalse();
            if (!(upMovement || downMovement || leftMovement || rightMovement))
            {
                timer.Stop();
            }

        }


        private void movePlayer()
        {
            if (upMovement)
            {
                moveUp();
            }
            if (downMovement)
            {
                moveDown();
            }
            if (rightMovement)
            {
                moveRight();
            }
            if (leftMovement)
            {
                moveLeft();
            }

            

        }

        private void moveUp()
        {
            halcon.SetValue(Canvas.TopProperty, playerYPosition - steps);
        }

        private void moveDown()
        {
            halcon.SetValue(Canvas.TopProperty, playerYPosition + steps);
        }

        private void moveRight()
        {
            halcon.SetValue(Canvas.LeftProperty, playerXPosition + steps);
        }

        private void moveLeft()
        {
            halcon.SetValue(Canvas.LeftProperty, playerXPosition - steps);
        }

        private void setAllFalse()
        {
            upMovement = false;
            leftMovement = false;
            rightMovement = false;
            downMovement = false;
        }

    }
}
