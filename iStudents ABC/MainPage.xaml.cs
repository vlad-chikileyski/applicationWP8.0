using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using iStudents_ABC.Resources;
using Microsoft.WindowsAzure.MobileServices;

namespace iStudents_ABC
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MobileServiceCollection<users, users> items;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private async void btnIndexManifest(object sender, RoutedEventArgs e)
        {           

            MobileServiceInvalidOperationException exception = null;

            try
            {
                items = await App.MobileService.GetTable<users>()
                    .Where(todoItem => todoItem.login == txtLogin.Text && todoItem.password == pswBox.Password)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exception = ex;
            }

            if (exception == null)
            {
                NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));
           }
            
        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLogin.Text)) { txtLogin.Text = "Your phone number"; }
           
        }

        private void pswBox_GotFocus(object sender, RoutedEventArgs e)
        {
                        pswBox.Password = "";
                        labelPSW.Text = "";


        }

        private void pswBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(pswBox.Password)) { labelPSW.Text = "Password"; }
        }

        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}