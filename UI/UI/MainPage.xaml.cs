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


            for (int i = 0; i < 3; i++)
            {

                //Button button = new Button();
                //Grid grid = new Grid();
                //button = SupperButton1;
                //button.Content = SupperButton1.ContentTemplate;
                //
                //DynamicResourceExtension dynamicResource = new DynamicResourceExtension();
                //dynamicResource.ResourceKey = "ButtonTemplate";
                //button.Content= Template.Resources.FindName("ButtonTemplate");
                //button.Content = dynamicResource;
                //RoomName.Text = "GEnerAL";
                //LastMessage.Text = "Heare will be message";
                //grid.Resources = MyGrid.Resources;

                //button.DataContext = SupperButton.DataContext;
                //button.Content = SupperButton1.ContentTemplate.LoadContent();
                //button.Content = SupperButton.Resources.Values;

                RoomButton roomButton = new RoomButton()
                {
                    UserName = i.ToString(),
                    Icon = userDTO.Icon,
                    LastMessage = "Some mesage fksdj fjsd jf Bla Bla Bla Olia Ila dalila Da da asfas asfd asd asfd asfd as afs as af asd asfd asdf asf asf a af a"
                };
                roomButton.SetContent();
                ButtonsPanel.Children.Add(roomButton);
            }
           
        }
    }
}
