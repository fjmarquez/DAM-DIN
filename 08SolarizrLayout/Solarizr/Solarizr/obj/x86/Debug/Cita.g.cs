﻿#pragma checksum "C:\Users\Francisco J. Márquez\GitHub\DIN\08SolarizrLayout\Solarizr\Solarizr\Cita.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F32F5942907B1E643327A18B3E31B98A20A62BB3ED654DEE730E40F05C5B442C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solarizr
{
    partial class Cita : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.stkLogo = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 16 "..\..\..\Cita.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)this.stkLogo).Tapped += this.stkLogo_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.stkUsuario = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 47 "..\..\..\Cita.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.btnEnviarDatos_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
