using DALwcf;
using DALwcf.DTOs;
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
    /// Логика взаимодействия для RegistrationNewUser.xaml
    /// </summary>
    public partial class RegistrationNewUser : Page
    {
        private readonly DAL _dal = new DAL();
        public RegistrationNewUser()
        {
            InitializeComponent();

        }

        private void IfPutEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Regist_click(sender, e);
        }

        private void Regist_click(object sender, RoutedEventArgs e)
        {
            if (Pass1.Password == Pass2.Password)
            {
                UserDTO user = new UserDTO()
                {
                    UserName = UserName.Text,
                    Papassword = Pass1.Password
                };
                if (_dal.AddUser(user))
                {

                    ErrorLabel.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "The account was created successfully";
                    ErrorLabel.Foreground = Brushes.Green;
                }
                else
                {
                    ErrorLabel.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "Username already in use";
                    ErrorLabel.Foreground = Brushes.Red;
         
                }
              
               
            }
            else
            {
                ErrorLabel.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Passwords don't match";
                ErrorLabel.Foreground = Brushes.Red;
          
            }
           
        }


        private void BackToLogIn(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new LoginPage();
        }
    }
}
