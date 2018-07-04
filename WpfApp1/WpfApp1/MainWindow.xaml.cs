using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfApp1.ServiceReference1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainWindow : Window, IService1Callback
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Receive(Message message)
        {
            MessageBox.Show("Test");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            Service1Client _service2 = new Service1Client(instanceContext);
            Message message = new Message()
            {
                Text = "123",
                Room = new Room
                {
                    Id = 1,
                },
                Sender = new User
                {
                    Id = 1
                },
                SendTime = DateTime.Now
                
            };
            _service2.SendMesage(message);
        }
    }
}
