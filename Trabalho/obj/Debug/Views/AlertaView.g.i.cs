﻿#pragma checksum "..\..\..\Views\AlertaView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F5005517552A655F2007FE775923EA74F3F9F06324296A98ACC85F808DE8A3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Trabalho.Views;


namespace Trabalho.Views {
    
    
    /// <summary>
    /// Alerta
    /// </summary>
    public partial class Alerta : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID_Alerta_tb;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Descricao_tb;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Email_cb;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Windows_cb;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Antecipacao_cb;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NaoRealizacao_cb;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tempo_label;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tempo_tb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_horas;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_min;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\AlertaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tempo_minutos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Trabalho;component/views/alertaview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AlertaView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ID_Alerta_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\Views\AlertaView.xaml"
            this.ID_Alerta_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ID_Alerta_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\Views\AlertaView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Descricao_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Email_cb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 33 "..\..\..\Views\AlertaView.xaml"
            this.Email_cb.Checked += new System.Windows.RoutedEventHandler(this.Email_check);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Windows_cb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 35 "..\..\..\Views\AlertaView.xaml"
            this.Windows_cb.Checked += new System.Windows.RoutedEventHandler(this.Windows_check);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Antecipacao_cb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\..\Views\AlertaView.xaml"
            this.Antecipacao_cb.Checked += new System.Windows.RoutedEventHandler(this.Antecipação);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\Views\AlertaView.xaml"
            this.Antecipacao_cb.Unchecked += new System.Windows.RoutedEventHandler(this.Antecipacao_unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NaoRealizacao_cb = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\..\Views\AlertaView.xaml"
            this.NaoRealizacao_cb.Checked += new System.Windows.RoutedEventHandler(this.NaoRealizacao_check);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tempo_label = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.tempo_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.label_horas = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label_min = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.tempo_minutos = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

