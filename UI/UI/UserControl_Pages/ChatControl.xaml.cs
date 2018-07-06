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
using System.ComponentModel;
using System.Collections.Specialized;

namespace UI
{
    /// <summary>
    /// Interaction logic for ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {
        public static UserDTO CurrentUser { get; set; }
        public static RoomDTO CurrentRoom { get; set; }
        private DALwcf.DAL _dal = new DALwcf.DAL();
        public ChatControl()
        {
            InitializeComponent();
            _dal.Messages.CollectionChanged += CollectionChangedMethod;


        }

        public static void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Message");

            if (e.NewItems != null)
            {
                MessageBox.Show("Message");
            }
        }

            public ChatControl(RoomDTO thisRoom, UserDTO thisUser)
        {
            InitializeComponent();
            CurrentUser = thisUser;
            CurrentRoom = thisRoom;
            Grid grid = new Grid();
            _dal.Messages.CollectionChanged += CollectionChangedMethod;
            foreach (var item in CurrentRoom.Messages)
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

        public  void ReceiveMessageInCurrentRoom(MessageDTO message)
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
            MessageBox.Show(DALwcf.DAL.i.ToString() + "     " + _dal.Messages.Count.ToString());
            MessageDTO message = new MessageDTO()
            {
                Sender = new UserDTO()
                {
                    Id = CurrentUser.Id
                },
                RoomDTO = CurrentRoom,
                SendTime = DateTime.Now,
                Text = Message.Text
            };
            _dal.SendMessage(message);
            
            Message.Text = String.Empty;
        }

        private void IfPutEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Click_SendMessage(sender, e);
        }
    }
}
