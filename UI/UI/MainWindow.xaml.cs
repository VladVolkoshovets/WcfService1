
using DALwcf;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>S
    public partial class MainWindow : Window
    {
        private readonly DAL _dal = new DAL();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LoginPage();
           
            _dal.FakeWork();
            //var l = _dal.GetUsers();
            //string res = String.Empty;
            //foreach (var item in l)
            //{
            //    res += item.Id + " " + item.UserName + " " + item.Papassword + "\n";
            //
            //MessageBox.Show(res);
        }

       
    }
}
