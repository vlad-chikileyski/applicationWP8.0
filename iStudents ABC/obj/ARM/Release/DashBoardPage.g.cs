﻿#pragma checksum "C:\Users\Administrator\documents\visual studio 2012\Projects\iStudents ABC\iStudents ABC\DashBoardPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A185C488DDA07BD06D0059F4D5EFFBBC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace iStudents_ABC {
    
    
    public partial class DashBoardPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Canvas canvas;
        
        internal System.Windows.Media.Animation.Storyboard moveAnimation;
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal System.Windows.Controls.Grid grdCommands;
        
        internal System.Windows.Controls.Button btnAddNewPost;
        
        internal System.Windows.Controls.ListBox myListView;
        
        internal System.Windows.Controls.Button MenuBtnNewPost;
        
        internal System.Windows.Controls.Button MenuBtnDashboard;
        
        internal System.Windows.Controls.Button MenuBtnReg;
        
        internal System.Windows.Controls.Button MenuBtnLog;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/iStudents%20ABC;component/DashBoardPage.xaml", System.UriKind.Relative));
            this.canvas = ((System.Windows.Controls.Canvas)(this.FindName("canvas")));
            this.moveAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("moveAnimation")));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.grdCommands = ((System.Windows.Controls.Grid)(this.FindName("grdCommands")));
            this.btnAddNewPost = ((System.Windows.Controls.Button)(this.FindName("btnAddNewPost")));
            this.myListView = ((System.Windows.Controls.ListBox)(this.FindName("myListView")));
            this.MenuBtnNewPost = ((System.Windows.Controls.Button)(this.FindName("MenuBtnNewPost")));
            this.MenuBtnDashboard = ((System.Windows.Controls.Button)(this.FindName("MenuBtnDashboard")));
            this.MenuBtnReg = ((System.Windows.Controls.Button)(this.FindName("MenuBtnReg")));
            this.MenuBtnLog = ((System.Windows.Controls.Button)(this.FindName("MenuBtnLog")));
        }
    }
}

