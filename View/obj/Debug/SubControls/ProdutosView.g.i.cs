﻿#pragma checksum "..\..\..\SubControls\ProdutosView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "971A8FFEBFEE29AA7EDB8694E004030A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using System.Windows.Forms.Integration;
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
using View.UserControls;


namespace View.UserControls {
    
    
    /// <summary>
    /// ProdutosView
    /// </summary>
    public partial class ProdutosView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UpperGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAdicionar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDeletar;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEstoque;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxExibir;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SubControls\ProdutosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridProduto;
        
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
            System.Uri resourceLocater = new System.Uri("/View;component/subcontrols/produtosview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SubControls\ProdutosView.xaml"
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
            
            #line 8 "..\..\..\SubControls\ProdutosView.xaml"
            ((View.UserControls.ProdutosView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UpperGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ButtonAdicionar = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\SubControls\ProdutosView.xaml"
            this.ButtonAdicionar.Click += new System.Windows.RoutedEventHandler(this.ButtonAdicionar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonDeletar = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\SubControls\ProdutosView.xaml"
            this.ButtonDeletar.Click += new System.Windows.RoutedEventHandler(this.ButtonDeletar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonEstoque = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\SubControls\ProdutosView.xaml"
            this.ButtonEstoque.Click += new System.Windows.RoutedEventHandler(this.ButtonEstoque_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboBoxExibir = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\SubControls\ProdutosView.xaml"
            this.ComboBoxExibir.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxExibir_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataGridProduto = ((System.Windows.Controls.DataGrid)(target));
            
            #line 29 "..\..\..\SubControls\ProdutosView.xaml"
            this.DataGridProduto.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.DataGridProduto_CellEditEnding);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

