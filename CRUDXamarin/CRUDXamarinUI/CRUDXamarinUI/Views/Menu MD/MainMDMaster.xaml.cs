using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarinUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMDMaster : ContentPage
    {
        public ListView ListView;

        public MainMDMaster()
        {
            InitializeComponent();

            BindingContext = new MainMDMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMDMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMDMasterMenuItem> MenuItems { get; set; }

            public MainMDMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMDMasterMenuItem>(new[]
                {
                    new MainMDMasterMenuItem { Id = 0, Title = "Personas", TargetType = typeof(Personas) },
                    new MainMDMasterMenuItem { Id = 1, Title = "Departamentos", TargetType = typeof(Departamentos) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}