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
using UI.UserControl_Pages;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UserDTO CurrentUser { get; set; }
        public static string nameForGroup;

        public MainPage(UserDTO userDTO)
        {
            InitializeComponent();
            CurrentUser = userDTO;
            foreach (var item in CurrentUser.ParticipantDTO)
            {

                if (item.RoomDTO.Messages != null)
                {
                    RoomButton roomButton = new RoomButton()
                    {
                        UserName = item.RoomDTO.Name,
                        
                        LastMessage = String.Empty
                    };

                    roomButton.LastMessage = item.RoomDTO.Messages.Last().Sender.UserName + ": " + item.RoomDTO.Messages.Last().Text;
                    roomButton.Icon = item.RoomDTO.Messages.Last().Sender.Icon;
                    //roomButton.Tag = item.Id;
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
                        ChatFrame.Content = new ChatControl(item.RoomDTO, CurrentUser);
                    });

                    roomButton.MouseRightButtonDown += new MouseButtonEventHandler((Sender, Args) =>
                    {
                        nameForGroup = roomButton.UserName;
                        ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
                        cm.PlacementTarget = Sender as Button;
                        cm.IsOpen = true;

                    });


                    roomButton.SetContent();
                    ButtonsPanel.Children.Add(roomButton);
                }

            }
        }

        //Методи на кнопці меню
        private void Button_ClickProfile(object sender, RoutedEventArgs e)
        {
            var profile = new Profile();
            ChatFrame.Content = profile;
        }
        private void Button_Click_AddGroup(object sender, RoutedEventArgs e)
        {
            var newGroup = new AddGroup(ChatFrame);
            ChatFrame.Content = newGroup;
        }
        private void Button_ClickLogOut(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new LoginPage();
        }

        //Методи на групі/чаті
        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            var newUser = new AddNewUserControl(nameForGroup);
            ChatFrame.Content = newUser;
        }
        private void LogOutGroup(object sender, RoutedEventArgs e)
        {
            var newWindowCheack = new CheackFor_Delete_LogOut("Do you want log out!!!");

            if (newWindowCheack.ShowDialog() == true)
            {
                //log out
            }
            else
            {
                //Not log out
            }
        }
        private void Delete_Group_Room(object sender, RoutedEventArgs e)
        {

            var newWindowCheack = new CheackFor_Delete_LogOut("Do you want delete this!!!");

            if(newWindowCheack.ShowDialog() == true)
            {
                //Delete
            }
            else
            {
                //Not Delete
            }
        }
    }
}
