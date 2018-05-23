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
using UI.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        

        public MainPage(UserDTO userDTO)
        {
            InitializeComponent();

            Image image = new Image();
            image.Source = userDTO.Icon;

            IconButton = image;

            ChatFrame.Content = new NonSelectedChatPage();
            foreach (var item in userDTO.Rooms)
            {
                RoomButton roomButton = new RoomButton()
                {
                    UserName = item.Name,
                    LastMessage = String.Empty
                };
                if (item.Messages != null)
                {
                    roomButton.LastMessage = item.Messages.Last().Sender.UserName + ": " + item.Messages.Last().Text;
                    roomButton.Icon = item.Messages.Last().Sender.Icon;
                }
                roomButton.SetContent();
                ButtonsPanel.Children.Add(roomButton);
            }
           
        }
    }
}
