﻿#pragma checksum "..\..\AddAToolWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "222A72C78F74A4AA2E4FCC1296C3C678B58BF707"
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
    /// AddAToolWindow
    /// </summary>
    public partial class AddAToolWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border brdTimage;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgAddTool;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtToolName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbToolCategories;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbToolCondition;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrowseToolImage;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowseToolImage;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddaToolToMysql;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddAToolWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblToolError;
        
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
            System.Uri resourceLocater = new System.Uri("/iTool;component/addatoolwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddAToolWindow.xaml"
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
            
            #line 8 "..\..\AddAToolWindow.xaml"
            ((iTool.AddAToolWindow)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.brdTimage = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.imgAddTool = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.txtToolName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbToolCategories = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbToolCondition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtBrowseToolImage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.btnBrowseToolImage = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AddAToolWindow.xaml"
            this.btnBrowseToolImage.Click += new System.Windows.RoutedEventHandler(this.btnBrowseToolImage_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnAddaToolToMysql = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AddAToolWindow.xaml"
            this.btnAddaToolToMysql.Click += new System.Windows.RoutedEventHandler(this.btnAddaToolToMysql_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.lblToolError = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

