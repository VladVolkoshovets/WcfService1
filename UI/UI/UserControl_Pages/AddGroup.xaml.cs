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
using UI.UserControl_Pages;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class AddGroup : UserControl
    {

        private Frame chatFrane = new Frame();

        public AddGroup(Frame _ChatFrame)
        {
            InitializeComponent();
            chatFrane = _ChatFrame;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new AddNewUserControl(NameForNewGroup.Text);
            chatFrane.Content = newUser;
        }
    }
}
