﻿#pragma checksum "..\..\..\..\Views\Pages\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4580F60730E0EDA0553AE0834B00D3F7FA77204EB42F2D9AE77F04D85ED37542"
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
using WpfApp2.Views.Pages;


namespace WpfApp2.Views.Pages {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDisctrictList;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxDebt;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ListData;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/views/pages/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\MainPage.xaml"
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
            
            #line 7 "..\..\..\..\Views\Pages\MainPage.xaml"
            ((WpfApp2.Views.Pages.MainPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\..\Views\Pages\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonUpdateData_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.txbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbDisctrictList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.cmbDisctrictList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CheckBoxDebt = ((System.Windows.Controls.CheckBox)(target));
            
            #line 44 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.CheckBoxDebt.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxDebt_Checked);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.CheckBoxDebt.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxDebt_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            
            #line 72 "..\..\..\..\Views\Pages\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\..\..\Views\Pages\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEdit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 79 "..\..\..\..\Views\Pages\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

