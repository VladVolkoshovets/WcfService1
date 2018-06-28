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



            ChatFrame.Content = new NonSelectedChatPage();

            foreach (var item in userDTO.ParticipantDTO)
            {

                if (item.RoomsDTO.Messages != null)
                    {
                    RoomButton roomButton = new RoomButton()
                    {
                        UserName = item.RoomsDTO.Name,
                            
                            LastMessage = String.Empty
                        };

                        roomButton.LastMessage = item.RoomsDTO.Messages.Last().Sender.UserName + ": " + item.RoomsDTO.Messages.Last().Text;
                        roomButton.Icon = item.RoomsDTO.Messages.Last().Sender.Icon;
                        roomButton.Tag = item.Id;
                        roomButton.Click += new System.Windows.RoutedEventHandler((Sender, Args) =>
                        {
                            for (int i = 0; i < ButtonsPanel.Children.Count; i++)
                            {
                                if (ButtonsPanel.Children[i] is RoomButton)
                                {
                                    (ButtonsPanel.Children[i] as RoomButton).UnSelect();
                                }
                            }
                            roomButton.Select();
                            ChatFrame.Content = new ChatPage(item.RoomsDTO, userDTO);
                        });
                        roomButton.SetContent();
                        ButtonsPanel.Children.Add(roomButton);
                    }

                    //RadioButtonExperement roomButton = new RadioButtonExperement()
                    //{
                    //    UserName = item.Name,
                    //    LastMessage = String.Empty
                    //};
                    //if (item.Messages != null)
                    //{
                    //
                    //    roomButton.LastMessage = item.Messages.Last().Sender.UserName + ": " + item.Messages.Last().Text;
                    //    roomButton.Icon = item.Messages.Last().Sender.Icon;
                    //}
                    //roomButton.SetContent();
                    //ButtonsPanel.Children.Add(roomButton);

                

            }
        }
    }
}
