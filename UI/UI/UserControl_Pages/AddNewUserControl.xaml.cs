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

namespace UI.UserControl_Pages
{
    /// <summary>
    /// Interaction logic for AddNewUserControl.xaml
    /// </summary>
    public partial class AddNewUserControl : UserControl
    {

        public AddNewUserControl(string NameGroup)
        {
            InitializeComponent();


            NameForGroup.Content = "Group: " + NameGroup;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Metod Add New User");
        }
    }
}
