using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace myChat
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient client = null;
        public MainWindow()
        {
            InitializeComponent();
            if (client != null)
            {
                Console.WriteLine("이미 연결되어있습니다.");
            }
            else
            {
                Connect();
            }


        }

        private void Connect()
        {
            // 이전게시물에서 다룬 내용이니 따로 다루지 않겠습니다.
            client = new TcpClient();
            client.Connect("127.0.0.1", 9999);
            MessageBox.Show("서버연결 성공 이제 Message를 입력해주세요");
        }
    }
}
