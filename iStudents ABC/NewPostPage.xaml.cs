using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;


namespace iStudents_ABC
{
    public partial class NewPostPage : PhoneApplicationPage
    {
        public NewPostPage()
        {
            InitializeComponent();
        }
        void TaskCompletedPhoto(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                MessageBox.Show("Этот");


                imageMakePhotoGALERIA.Source = bmp;
                btnGallery.IsEnabled = false;
                btnMakePhoto.IsEnabled = false;
                btnDelImage.Visibility = Visibility.Visible;

                
            }
        }

        void TaskCompletedGallery(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                imageMakePhoto.Source = bmp;
                btnGallery.IsEnabled = false;
               btnMakePhoto.IsEnabled = false;
               btnDelImageG.Visibility = Visibility.Visible;

            }
        }


        private void btnAddValidate(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute)); 

        }

        private void txtDesc_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBDesc.Text = "";
        }

        private void txtDesc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBDesc.Text)) { txtBDesc.Text = "Write a description"; }

        }

        private void btnMakePhoto_Click(object sender, RoutedEventArgs e)
        {
            var cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += TaskCompletedPhoto;
            cameraCaptureTask.Show();
           
        }

        private void btnGallery_Click(object sender, RoutedEventArgs e)
        {
            var photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += TaskCompletedGallery;
            photoChooserTask.Show();
        }

        private void btnDelImage_Click(object sender, RoutedEventArgs e)
        {
            imageMakePhotoGALERIA.Source = null;
            btnGallery.IsEnabled = true;
            btnMakePhoto.IsEnabled = true;
            Visibility = Visibility.Visible;
            btnDelImage.Visibility = Visibility.Collapsed;
        }

        private void btnDelImageG_Click(object sender, RoutedEventArgs e)
        {
            imageMakePhoto.Source = null;
            btnGallery.IsEnabled = true;
            btnMakePhoto.IsEnabled = true;
            btnDelImageG.Visibility = Visibility.Collapsed;

        }
        private void txtBTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBTitle.Text = "";

        }
        private void txtBTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBTitle.Text)) { txtBTitle.Text = "Title"; }
           
        }

        private async void btnAddNewPost(object sender, RoutedEventArgs e)
        {
            
                post item = new post
                {
                    title = txtBTitle.Text,
                    status = txtBStatus.Text,
                    description = txtBDesc.Text


                };
                await App.MobileService.GetTable<post>().InsertAsync(item);
                NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));
           
        }

        private void txtBStatus_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBStatus.Text = "";
        }

        private void txtBStatus_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBStatus.Text)) { txtBStatus.Text = "Status"; }

        }

       
    }
}