﻿#pragma checksum "C:\Users\Administrator\Documents\GitHub\applicationWP8.0\iStudents ABC\MyPostPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "403DC6CC4C6C2C4E9C6BCCA2E32DE27C"
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
    
    
    public partial class MyPostPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ListBox myListView;
        
        internal System.Windows.Controls.TextBlock txtValid_id;
        
        internal System.Windows.Controls.TextBlock txtxValid_status;
        
        internal System.Windows.Controls.TextBlock txtValid_title;
        
        internal System.Windows.Controls.RichTextBox txtDisplayText;
        
        internal System.Windows.Controls.Button btnPrevPage;
        
        internal System.Windows.Controls.TextBlock txtNumPost;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/iStudents%20ABC;component/MyPostPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.myListView = ((System.Windows.Controls.ListBox)(this.FindName("myListView")));
            this.txtValid_id = ((System.Windows.Controls.TextBlock)(this.FindName("txtValid_id")));
            this.txtxValid_status = ((System.Windows.Controls.TextBlock)(this.FindName("txtxValid_status")));
            this.txtValid_title = ((System.Windows.Controls.TextBlock)(this.FindName("txtValid_title")));
            this.txtDisplayText = ((System.Windows.Controls.RichTextBox)(this.FindName("txtDisplayText")));
            this.btnPrevPage = ((System.Windows.Controls.Button)(this.FindName("btnPrevPage")));
            this.txtNumPost = ((System.Windows.Controls.TextBlock)(this.FindName("txtNumPost")));
        }
    }
}

