﻿using DALwcf.DTOs;
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
        public UserDTO CurrentUser { get; set; }

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
                    roomButton.Tag = item.Id;
                    roomButton.Click += new System.Windows.RoutedEventHandler((Sender, Args) =>
                    {
                        for (int i = 0; i < ButtonsPanel.Children.Count; i++)
                        {
                            //updated to C# 6.0
                            if (ButtonsPanel.Children[i] is RoomButton btn)
                            {
                                btn.UnSelect();
                            }
                        }
                        roomButton.Select();
                        ChatFrame.Content = new ChatControl(item.RoomDTO, CurrentUser);
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

        private void Button_ClickProfile(object sender, RoutedEventArgs e)
        {
            var profile = new Profile(CurrentUser);
            ChatFrame.Content = profile;
        }
        private void Button_Click_AddGroup(object sender, RoutedEventArgs e)
        {
            var newGroup = new AddGroup();
            ChatFrame.Content = newGroup;
        }
        private void Button_ClickLogOut(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Content = new LoginPage();
        }
    }
}
