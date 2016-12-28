using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Phone.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace iStudents_ABC
{
    public partial class MyPostPage : PhoneApplicationPage
    {
                private MobileServiceCollection<post, post> items;

                string ID_USER_ASIC;

        public MyPostPage()
        {
            InitializeComponent();


        }

        private void btnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            GoToFirstView();
        }

        private void GoToFirstView()
        {
            
            NavigationService.Navigate(new Uri("/DashBoardPage.xaml", UriKind.RelativeOrAbsolute)); 
        }

        private async void myListView_Loaded(object sender, RoutedEventArgs e)
        {
       
            MessageBox.Show("Загрузка");
            MobileServiceInvalidOperationException exception = null;
            try
            {
                NavigationContext.QueryString.TryGetValue("ID_USER_ASIC", out ID_USER_ASIC);

                items = await App.MobileService.GetTable<post>().Where(todoItem => todoItem.id == ID_USER_ASIC).ToCollectionAsync();
                MessageBox.Show("ID_USER_ASIC" + items.Count);
                post listitem = myListView.ItemsSource as post;
                var firstFromGroup = items.First();
               txtValid_id.Text =  firstFromGroup.id;
               txtValid_title.Text = firstFromGroup.title;
               txtxValid_status.Text = firstFromGroup.status;
                MessageBox.Show(firstFromGroup.description);

                try
                {
                    OnMessageReceived(firstFromGroup.description);
                    txtDisplayText = null;
                }
                catch { }
                finally { 
             
                }


              /*  var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
               // var rawString = "house home go www.monstermmorpg.com nice hospital http://www.monstermmorpg.com.12/13123/1/23da.html this is incorrect url http://www.monstermmorpg.commerged continue";
                foreach (Match m in linkParser.Matches(firstFromGroup.description))
                {
                    OnMessageReceived(m.Value);
                }
             */   
            }
            catch (MobileServiceInvalidOperationException ex)
            {
               exception = ex;
            }

            if (exception == null) myListView.DataContext = items;
           
        }
        private void OnMessageReceived(string message)
        {
            var paragraph = new Paragraph();

            var runs = new List<Inline>();

            string[] wordArray = message.Split(' ', '\r');

            foreach (var word in wordArray)
            {
                Regex emailid = new Regex(@"^[A-Za-z0-9_\-\.]+@(([A-Za-z0-9\-])+\.)+([A-Za-z\-])+$");
                Regex phonenumber = new Regex(@"^(?:\(?([0-9]{3})\)?[-. ]?)?([0-9]{3})[-. ]?([0-9]{4})$");
                Uri uri;
                if (emailid.IsMatch(word))
                {
                    var link = new Hyperlink();
                    link.Inlines.Add(new Run() { Text = word });
                    link.Click += (sender, e) =>
                    {
                        var hyperLink = (sender as Hyperlink);
                        new EmailComposeTask() { To = word }.Show();
                    };
                    runs.Add(link);

                }

                else if (Uri.TryCreate(word, UriKind.Absolute, out uri) ||
                   (word.StartsWith("www.") || word.EndsWith(".com")) && Uri.TryCreate("http://" + word, UriKind.Absolute, out uri))
                {
                    var link = new Hyperlink();
                    link.Inlines.Add(new Run() { Text = word });
                    link.Click += (sender, e) =>
                    {
                        var hyperLink = (sender as Hyperlink);
                        new WebBrowserTask() { Uri = uri }.Show();
                    };

                    runs.Add(link);
                }
                //string number;
                //number = Regex.Replace(word, "[^+0-9]", "");
                else if (phonenumber.IsMatch(word))
                {
                    var link = new Hyperlink();
                    link.Inlines.Add(new Run() { Text = word });
                    link.Click += (sender, e) =>
                    {
                        var hyperLink = (sender as Hyperlink);
                        new PhoneCallTask() { PhoneNumber = word }.Show();
                    };

                    runs.Add(link);
                }
                else
                {
                    runs.Add(new Run() { Text = word });
                }

                runs.Add(new Run() { Text = " " });
            }

            foreach (var run in runs)
                paragraph.Inlines.Add(run);

            txtDisplayText.Blocks.Add(paragraph);
            //txtMessage.Text = "";
            
        }
      

       
        
        
    }
}