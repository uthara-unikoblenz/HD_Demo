using Markdig;
using Neo.Markdig.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UpdateDetails.xaml
    /// </summary>
    public partial class UpdateDetails : Window
    {
        public UpdateDetails()
        {


            try
            {
                InitializeComponent();
                var content = File.ReadAllText(@"Readme.md");
                var doc = MarkdownXaml.ToFlowDocument(content,
                    new MarkdownPipelineBuilder()
                    .UseXamlSupportedExtensions()
                    .Build()
                );
                flowDocumentViewer.Document = doc;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }



        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) =>
           DialogResult = false;


        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(String.Format("Link clicked: {0}", e.Parameter));
        }


    }
}

