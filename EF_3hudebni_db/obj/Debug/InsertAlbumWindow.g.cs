﻿#pragma checksum "..\..\InsertAlbumWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8C7F5DC8C5E3EBC8458D715E345C61B50B58E590D75D2A8619F5F924EE4DB4B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EF_3hudebni_db;
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


namespace EF_3hudebni_db {
    
    
    /// <summary>
    /// InsertAlbumWindow
    /// </summary>
    public partial class InsertAlbumWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\InsertAlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAuthorName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\InsertAlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAlbumName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\InsertAlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReleased;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\InsertAlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddAlbum;
        
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
            System.Uri resourceLocater = new System.Uri("/EF_3hudebni_db;component/insertalbumwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InsertAlbumWindow.xaml"
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
            this.txtAuthorName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtAlbumName = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\InsertAlbumWindow.xaml"
            this.txtAlbumName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtAlbumName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtReleased = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\InsertAlbumWindow.xaml"
            this.txtReleased.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtReleased_TextChanged);
            
            #line default
            #line hidden
            
            #line 27 "..\..\InsertAlbumWindow.xaml"
            this.txtReleased.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericOnly);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddAlbum = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\InsertAlbumWindow.xaml"
            this.btnAddAlbum.Click += new System.Windows.RoutedEventHandler(this.btnAddAlbum_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

