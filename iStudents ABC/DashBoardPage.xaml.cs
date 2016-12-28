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
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace iStudents_ABC
{
    public partial class DashBoardPage : PhoneApplicationPage
    {
        private MobileServiceCollection<post, post> items;
        MobileServiceInvalidOperationException exception = null;


        public DashBoardPage()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "Normal", false);
            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            myListView.SelectedIndex = -1;

        }
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
           // ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            //ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            //appBarButton.Text = AppResources.AppBarButtonText;
           // ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
           // ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
           // ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private void OpenCloseMenuLeft(object sender, RoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -100)
            {
              //  ApplicationBar.IsVisible = true;
                MoveViewWindow(-230);
            }
            else
            {
                //ApplicationBar.IsVisible = false;
                MoveViewWindow(0);
            }
        }

        private void canvas_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (_viewMoved)
                return;
            if (Math.Abs(initialPosition - left) < 100)
            {
                //bouncing back
                MoveViewWindow(initialPosition);
                return;
            }
            //change of state
            if (initialPosition - left > 0)
            {
                //slide to the left
                if (initialPosition > -420)
                    MoveViewWindow(-230);
                else
                    MoveViewWindow(-840);
            }
            else
            {
                //slide to the right
                if (initialPosition < -420)
                    MoveViewWindow(-420);
                else
                    MoveViewWindow(0);
            }
        }

        private void canvas_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            if (e.DeltaManipulation.Translation.X != 0)
                Canvas.SetLeft(LayoutRoot, Math.Min(Math.Max(-840, Canvas.GetLeft(LayoutRoot) + e.DeltaManipulation.Translation.X), 0));
        }


        double initialPosition;
        bool _viewMoved = false;
        private void canvas_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            _viewMoved = false;
            initialPosition = Canvas.GetLeft(LayoutRoot);
        }
        void MoveViewWindow(double left)
        {
            _viewMoved = true;
            //if (left == -420)
           //     ApplicationBar.IsVisible = true;
           // else
            //    ApplicationBar.IsVisible = false;
            ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = left;
            ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
        }

        private async void myListView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                items = await App.MobileService.GetTable<post>().ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exception = ex;
            }
            if (exception == null) myListView.DataContext = items;
        }

        private  void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GoToFirstView();

        }

        private void GoToFirstView()
        {
                post listitem = myListView.SelectedValue as post;

                
                NavigationService.Navigate(new Uri("/MyPostPage.xaml?ID_USER_ASIC="+ listitem.id, UriKind.RelativeOrAbsolute));
                MessageBox.Show(listitem.id);
        }


        private void btnAddNewPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewPostPage.xaml", UriKind.Relative));
        }

        private void MenuBtnNewPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewPostPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void MenuBtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void MenuBtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RegistrationPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void MenuBtnLog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
           
        }

        

    }
}