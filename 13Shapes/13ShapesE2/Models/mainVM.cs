using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

namespace _13ShapesE2.Models
{
    public class mainVM
    {

        public mainVM()
        {

        }

        public void Diference(object sender, TappedRoutedEventArgs e)
        {
            //usar el sender para cambiar la opacidad del elipse pulsado

            Ellipse elipse = (Ellipse)sender;

            elipse.Opacity = 1;

        }

    }
}
