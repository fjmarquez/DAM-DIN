﻿using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarinUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPersonas : ContentPage
    {
        public FormularioPersonas()
        {
            InitializeComponent();
        }

        public FormularioPersonas(clsPersona persona)
        {
            InitializeComponent();
        }

    }
}