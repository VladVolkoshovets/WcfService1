using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace UI.Controls
{
    class RoomButton : Button
    {

        public String UserName { get; set; }
        public String LastMessage { get; set; }
        public System.Windows.Media.Imaging.BitmapImage Icon { get; set; }
        public RoomButton()
        {
            Height = 75;
            Padding = new System.Windows.Thickness(0,0, 0, 0);
            
        }
        public void SetContent()
        {
            
            Style = System.Windows.Application.Current.Resources["MaterialDesignFlatAccentButton"] as System.Windows.Style;
            Padding = new System.Windows.Thickness(4);
            //System.Windows.Thickness pading = Padding;
            //pading.Left = 1;
            //pading.Right = 1;
            //pading.Top = 1;
            //pading.Bottom = 1;
            //Padding = pading;
            VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
            HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;

            Grid gridContent = new Grid();

            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
           
            //colDef2.MinWidth = 50;
            colDef2.Width = new System.Windows.GridLength(2, System.Windows.GridUnitType.Star);
            //colDef3.MinWidth = 35;
            gridContent.ColumnDefinitions.Add(colDef1);
            gridContent.ColumnDefinitions.Add(colDef2);
            gridContent.ColumnDefinitions.Add(colDef3);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            gridContent.RowDefinitions.Add(rowDef1);
            gridContent.RowDefinitions.Add(rowDef2);

            Button buttonIcon = new Button();
            
            

            Image image = new Image();
            image.Source = Icon;
            
            buttonIcon.Content = image;
            buttonIcon.Style = System.Windows.Application.Current.Resources["MaterialDesignFloatingActionAccentButton"] as System.Windows.Style;
            buttonIcon.BorderBrush = Brushes.Transparent;
            buttonIcon.Padding = new System.Windows.Thickness(0);
            buttonIcon.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            buttonIcon.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            //image.Height = 34;
            image.MaxHeight = 54;
            image.MaxHeight = 54;
            image.MinWidth = 54;
            image.MaxWidth = 54;
            image.Height = 54;
            image.Width = 54;
            buttonIcon.Height = 54;
            buttonIcon.Width = 54;
            buttonIcon.IsHitTestVisible = false;
            //buttonIcon.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Grid.SetRowSpan(buttonIcon, 2);
            

            TextBlock userName = new TextBlock();
            userName.Text = UserName;
            userName.Margin = new System.Windows.Thickness(4);
            userName.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            userName.FontSize = 14;
            userName.Foreground = Brushes.Black;
            Grid.SetColumn(userName, 1);


            TextBlock lastMessage = new TextBlock();
            lastMessage.Text = LastMessage;
            lastMessage.FontSize = 10;
            lastMessage.Foreground = System.Windows.Application.Current.Resources["primary_text"] as Brush;
            lastMessage.TextWrapping = System.Windows.TextWrapping.Wrap;
            lastMessage.FontFamily = new FontFamily("Verdana");
            lastMessage.Margin = new System.Windows.Thickness(4);
            Grid.SetColumn(lastMessage, 1);
            Grid.SetRow(lastMessage, 1);
            Grid.SetColumnSpan(lastMessage, 2);

            gridContent.Children.Add(buttonIcon);
            gridContent.Children.Add(userName);
            gridContent.Children.Add(lastMessage);

            Content = gridContent;
        }
    }
}
