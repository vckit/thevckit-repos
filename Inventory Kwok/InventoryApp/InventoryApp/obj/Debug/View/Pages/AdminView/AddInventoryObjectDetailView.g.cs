﻿#pragma checksum "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A7201771DA7A37C4AAE646E998DFCC5CD2BFAFD587A9C6C9CD913FA571B73A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InventoryApp.View.Pages.AdminView;
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


namespace InventoryApp.View.Pages.AdminView {
    
    
    /// <summary>
    /// AddInventoryObjectDetailView
    /// </summary>
    public partial class AddInventoryObjectDetailView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbTitleInventoryObject;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSeraiNumber;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListInventoryObjectDetails;
        
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
            System.Uri resourceLocater = new System.Uri("/InventoryApp;component/view/pages/adminview/addinventoryobjectdetailview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
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
            
            #line 7 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
            ((InventoryApp.View.Pages.AdminView.AddInventoryObjectDetailView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbTitleInventoryObject = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txbSeraiNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 25 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
            this.txbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ListInventoryObjectDetails = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 53 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonSelected_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 63 "..\..\..\..\..\View\Pages\AdminView\AddInventoryObjectDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

