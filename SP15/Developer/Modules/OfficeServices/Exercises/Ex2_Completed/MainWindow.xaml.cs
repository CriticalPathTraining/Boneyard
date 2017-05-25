using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Microfeed;
using Microsoft.SharePoint.Client.UserProfiles;

namespace SocialFeedViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientContext clientContext;
        MicrofeedManager microfeedMgr;
        Dictionary<int, string> idDictionary;

        public MainWindow()
        {
            InitializeComponent();

            clientContext = new ClientContext("http://officeservices.wingtip.com");
        }

        private void LoadThreads()
        {
            try
            {
                string targetUser = AccountNameTextBox.Text;

                // Get the MicrofeedManager object.
                microfeedMgr = new MicrofeedManager(clientContext);

                // Get the properties for the target user
                PersonProperties personProps = new PeopleManager(clientContext).GetPropertiesFor(targetUser);

                // Get Display Name and Account Name for the target user
                clientContext.Load(personProps, o => o.DisplayName, o => o.AccountName);
                clientContext.Load(microfeedMgr);
                clientContext.ExecuteQuery();

                // Specify the feed content that you want to retrieve.
                MicrofeedRetrievalOptions retrievalOptions = new MicrofeedRetrievalOptions();
                retrievalOptions.IncludedTypes = MicroBlogType.RootPost;
                retrievalOptions.ThreadCount = 5;

                // Get all of the target owner's posts and activities
                var threads = microfeedMgr.GetPublishedFeed(
                                personProps.AccountName,
                                retrievalOptions,
                                MicrofeedPublishedFeedType.Full);
                clientContext.ExecuteQuery();

                //Create a dictionary to store the thread identifiers
                idDictionary = new Dictionary<int, string>();

                FeedThreadsListBox.Items.Clear();

                for (int i = 0; i < threads.Value.Count; i++)
                {
                    MicrofeedThread thread = threads.Value[i];

                    // Keep only user-sourced threads (not events).
                    if (thread.DefinitionName == "Microsoft.SharePoint.Microfeed.UserPost")
                    {
                        //Save thread identifier
                        idDictionary.Add(i, thread.Identifier);

                        // get the posts
                        FeedThreadsListBox.Items.Add(string.Format("{0}: {1}. {2}",
                            personProps.DisplayName,
                            (i + 1),
                            thread.RootPost.Content));
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        private void GetActivitiesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadThreads();
        }

        private void PostReploy()
        {
            try
            {
                string threadId = string.Empty;

                // Get the thread identifier
                idDictionary.TryGetValue((Convert.ToInt32(ThreadCountTextBox.Text) - 1), out threadId);

                // Define properties for the reply.
                MicrofeedPostOptions postOptions = new MicrofeedPostOptions();
                postOptions.Content = ThreadResponseTextBox.Text;

                // Register the reply.
                microfeedMgr.PostReply(threadId, postOptions);

                // Make the changes on the server.
                clientContext.ExecuteQuery();

                MessageBox.Show("Reply Posted!");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void PostReplyButton_Click(object sender, RoutedEventArgs e)
        {
            PostReploy();
        }

    }
}
