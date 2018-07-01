using Microsoft.Win32;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class AddGroup : UserControl
    {
        public AddGroup()
        {
            InitializeComponent();

        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string strPath = openFileDialog.FileName;

                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(strPath, UriKind.RelativeOrAbsolute));
      
                ImageGroup.Fill = brush;
            }
        }
    }
}
