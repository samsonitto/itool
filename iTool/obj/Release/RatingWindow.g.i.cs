﻿#pragma checksum "..\..\RatingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CF880C26BC9BE9BB371AFBFA31DB6D8D1D7B1A73"
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
    /// RatingWindow
    /// </summary>
    public partial class RatingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRatedPerson;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRating;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRating;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRatingFeedback;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRatingComments;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCharCount;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGiveRating;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RatingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessagesRating;
        
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
            System.Uri resourceLocater = new System.Uri("/iTool;component/ratingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RatingWindow.xaml"
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
            this.lblRatedPerson = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblRating = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtRating = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lblRatingFeedback = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtRatingComments = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\RatingWindow.xaml"
            this.txtRatingComments.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtRatingComments_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblCharCount = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnGiveRating = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\RatingWindow.xaml"
            this.btnGiveRating.Click += new System.Windows.RoutedEventHandler(this.BtnGiveRating_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblMessagesRating = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

