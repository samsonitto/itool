﻿#pragma checksum "..\..\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "157885D7BD01296160E35A4BA0A3EAB4F024C85A"
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
using iTool;


namespace iTool {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgMainPageProfile;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUsername;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearchBar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearchTools;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCityFilter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbToolCategory;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTools;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgTool;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbToolName;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbToolCondition;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbPrice;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbDescription;
        
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
            System.Uri resourceLocater = new System.Uri("/iTool;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainPage.xaml"
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
            this.imgMainPageProfile = ((System.Windows.Controls.Image)(target));
            
            #line 15 "..\..\MainPage.xaml"
            this.imgMainPageProfile.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ImgMainPageProfile_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtUsername = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txbSearchBar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSearchTools = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.cbCityFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\MainPage.xaml"
            this.cbCityFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbCityFilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbToolCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\MainPage.xaml"
            this.cbToolCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbToolCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgTools = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\MainPage.xaml"
            this.dgTools.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgTools_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.imgTool = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.txbToolName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.txbToolCondition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.txbPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.txbDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

