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
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public UserDTO CurrentUser { get; set; }
        public ChatPage()
        {
            InitializeComponent();
        }
        public ChatPage(RoomDTO room, UserDTO thisUser )
        {
            InitializeComponent();
            CurrentUser = thisUser;
            Grid grid = new Grid();
            foreach (var item in room.Messages)
            {
                Border border = new Border();
                border.Padding = new System.Windows.Thickness(11);
                border.CornerRadius = new CornerRadius(8);

                if (item.Sender.UserName == CurrentUser.UserName)
                {
                    border.Background = System.Windows.Application.Current.Resources["divider"] as Brush;
                }
                else
                {
                    border.Background = System.Windows.Application.Current.Resources["icons"] as Brush;
                }
                TextBlock textBlock = new TextBlock();
                textBlock.Text = item.Sender.UserName + ": " + item.Text;
                border.Child = textBlock;
                border.Margin = new System.Windows.Thickness(4);
                StackPanel.Children.Add(border);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Border border = new Border();
            border.Padding = new System.Windows.Thickness(11);
            border.CornerRadius = new CornerRadius(8);
            border.Background = System.Windows.Application.Current.Resources["divider"] as Brush;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = CurrentUser.UserName + ": " + Message.Text;
            border.Child = textBlock;
            border.Margin = new System.Windows.Thickness(4);
            StackPanel.Children.Add(border);


            Message.Text = String.Empty;
        }
    }
}
