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
using System.Threading;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly DAL _dal;

        public LoginPage()
        {
            _dal = new DAL();
            InitializeComponent();
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            _dal.Autorisation(UserName.Text, Password.Password);
            await Task.Run(() => Thread.Sleep(100));
            if (DAL.CourentUser != null)
            {
                ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new MainPage(DAL.CourentUser);
            }
            else
            {
                ErrorLabel.Visibility = Visibility.Visible;
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
