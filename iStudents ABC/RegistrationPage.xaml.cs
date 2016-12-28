using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace iStudents_ABC
{
    public partial class RegistrationPage : PhoneApplicationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        
        private async void btnRegValidate(object sender, RoutedEventArgs e)
        {
            users item = new users
            {
                login = txtBMobileValid.Text,
                password = txtBPasswordValid.Text

            };
            await App.MobileService.GetTable<users>().InsertAsync(item);
            NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));
            MessageBox.Show("Hello," + txtBMobileValid.Text);

       
           
        }

        private void btnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void txtBMobileValid_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBMobileValid.Text = "";

        }

        private void txtBPasswordValid_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBPasswordValid.Text = "";

        }

        private void txtBMobileValid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBMobileValid.Text)) { txtBMobileValid.Text = "Your phone number"; }

        }

        private void txtBPasswordValid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBPasswordValid.Text)) { txtBPasswordValid.Text = "Password"; }

        }
        
       
    }
}