﻿#pragma checksum "..\..\..\UserInterface.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2A8972E546F3C14309FAC2ECF6C26A53CEB9F38F"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using UI;


namespace UI {
    
    
    /// <summary>
    /// UserInterface
    /// </summary>
    public partial class UserInterface : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.UserInterface userWindow;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button home;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button wordcloud;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button graphs;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl cont;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.Tag username;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem minuteSelect;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem hourSelect;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem daySelect;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UserInterface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI;component/userinterface.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserInterface.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.userWindow = ((UI.UserInterface)(target));
            return;
            case 2:
            this.home = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\UserInterface.xaml"
            this.home.Click += new System.Windows.RoutedEventHandler(this.home_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.wordcloud = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\UserInterface.xaml"
            this.wordcloud.Click += new System.Windows.RoutedEventHandler(this.wordcloud_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.graphs = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\UserInterface.xaml"
            this.graphs.Click += new System.Windows.RoutedEventHandler(this.graphs_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cont = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 6:
            this.username = ((HandyControl.Controls.Tag)(target));
            
            #line 29 "..\..\..\UserInterface.xaml"
            this.username.Closed += new System.EventHandler(this.UserChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 31 "..\..\..\UserInterface.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.minuteSelect = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.hourSelect = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.daySelect = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 11:
            
            #line 36 "..\..\..\UserInterface.xaml"
            ((HandyControl.Controls.SearchBar)(target)).SearchStarted += new System.EventHandler<HandyControl.Data.FunctionEventArgs<string>>(this.SearchFeeling);
            
            #line default
            #line hidden
            return;
            case 12:
            this.t1 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
