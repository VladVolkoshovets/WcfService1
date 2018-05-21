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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        

        public MainPage()
        {
            InitializeComponent();
            ChatFrame.Content = new NonSelectedChatPage();
            for (int i = 0; i < 3; i++)
            {
                Button button = new Button();
                Grid grid = new Grid();
                
                
                
                //RoomName.Text = "GEnerAL";
                //LastMessage.Text = "Heare will be message";
                grid.Resources = MyGrid.Resources;
               
                button.DataContext = SupperButton.DataContext;
                //button.Content = SupperButton.Content;
                button.Content = SupperButton.Resources.Values;
                ButtonsPanel.Children.Add(button);
            }
           
        }
    }
}
