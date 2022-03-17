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
using System.Windows.Shapes;

namespace HD_Demo
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void FileMenu_Click(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as MenuItem;
            Updater.InstallUpdateSyncWithInfo();
        }

        //private void ShowContextMenu()
        //{
        //    var contextMenu = Resources["menu1"] as ContextMenu;
        //    contextMenu.IsOpen = true;
        //}

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Hello {FirstNameText.Text} ");
        }
    }
}
