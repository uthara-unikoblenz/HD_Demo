using System;
using System.Collections.Generic;
using System.Deployment.Application;
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
using System.Xml;

namespace HD_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                


                Updater.InstallUpdateSyncWithInfo();

                InitializeComponent();


            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Hello {FirstNameText.Text} ");
        }

        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as MenuItem;
            MessageBox.Show($"{item.Header} was clicked");
        }


        private void ShowContextMenu()
        {
            var contextMenu = Resources["contextMenu"] as ContextMenu;
            contextMenu.IsOpen = true;
        }

        private void FileMenu_Click(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as MenuItem;
            UpdateCheckInfo info = null;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                if (info.UpdateAvailable)
                {
                    Updater.InstallUpdateSyncWithInfo();
                }
                else
                {
                    MessageBox.Show("There are no pending updates.");
                }
            }
        }
    }
}
