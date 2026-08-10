using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Names
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> lstNames1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
            
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (saveFileDialog.ShowDialog(this) == true)
            {
                using (Stream stream = saveFileDialog.OpenFile())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    foreach (var item in lstNames.Items)
                    {
                        writer.WriteLine(item?.ToString());
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Read file from hard drive

            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";   
            }

            // and place contents of file into list

            if (openFileDialog.ShowDialog() == true)
            {
                using Stream stream = openFileDialog.OpenFile();
                using StreamReader reader = new StreamReader(stream);
                string input;
                while ((input = reader.ReadLine()) != null)
                {
                    lstNames.Items.Add(input);
                }
            }
        }
    }
}