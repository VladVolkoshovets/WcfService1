using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DALwcf.DTOs;
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
    /// Interaction logic for ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {
        public UserDTO CurrentUser { get; set; }
        public RoomDTO CurrentRoom { get; set; }
        public ChatControl()
        {
            InitializeComponent();
        }

        public ChatControl(RoomDTO thisRoom, UserDTO thisUser)
        {
            InitializeComponent();
            CurrentUser = thisUser;
            CurrentRoom = thisRoom;
            Grid grid = new Grid();
            foreach (var item in thisRoom.Messages)
            {
                Border border = new Border();
                border.Padding = new System.Windows.Thickness(11);
                border.CornerRadius = new CornerRadius(8);
                border.MaxWidth = 350;
                if (item.Sender.Id == CurrentUser.Id)
                {
                    border.HorizontalAlignment = HorizontalAlignment.Right;
                    border.Background = System.Windows.Application.Current.Resources["background_message"] as Brush;
                }
                else
                {
                    border.HorizontalAlignment = HorizontalAlignment.Left;
                    border.Background = System.Windows.Application.Current.Resources["icons"] as Brush;
                }
                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text = item.Sender.UserName + ": " + item.Text;
                border.Child = textBlock;
                border.Margin = new System.Windows.Thickness(4);
                StackPanel.Children.Add(border);

            }
        }

        public void ReceiveMessage(MessageDTO message)
        {
            Border border = new Border();
            border.Padding = new System.Windows.Thickness(11);
            border.CornerRadius = new CornerRadius(8);
            border.MaxWidth = 350;
            if (message.Sender.Id == CurrentUser.Id)
            {
                border.HorizontalAlignment = HorizontalAlignment.Right;
                border.Background = System.Windows.Application.Current.Resources["background_message"] as Brush;
            }
            else
            {
                border.HorizontalAlignment = HorizontalAlignment.Left;
                border.Background = System.Windows.Application.Current.Resources["icons"] as Brush;
            }
            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Text = message.Sender.UserName + ": " + message.Text;
            border.Child = textBlock;
            border.Margin = new System.Windows.Thickness(4);
            StackPanel.Children.Add(border);
        }
        private void Button_Click_SendMessage(object sender, RoutedEventArgs e)
        {
            MessageDTO message = new MessageDTO()
            {
                Sender = CurrentUser,
                RoomDTO = 
            }
        

            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Text = CurrentUser.UserName + ": " + Message.Text;
            


            Message.Text = String.Empty;
        }

        private void IfPutEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Click_SendMessage(sender, e);
        }
    }
}
