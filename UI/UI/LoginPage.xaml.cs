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
using DALwcf;
using DALwcf.DTOs;
using MaterialDesignColors;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly DAL _dal = new DAL();

        public LoginPage()
        {
           InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            UserDTO userDTO = null;
            userDTO = _dal.Autorisation(UserName.Text, Password.Password);
            if (userDTO != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new MainPage(userDTO);
            } 

        }

        private void CreateNewUser(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new RegistrationNewUser();
        }

        private void IfPutEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SignInButton_Click(sender, e);
        }
    }
}
