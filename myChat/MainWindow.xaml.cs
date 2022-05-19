using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
            NetworkStream stream = client.GetStream();
            Encoding encoder = Encoding.GetEncoding("utf-8");

            StreamWriter writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            StreamReader reader = new StreamReader(stream, encoder);

            writer.WriteLine("getDept");

            DataTable dept = Utils.Utils.getJSONtoDataTable(reader.ReadLine());



            writer.WriteLine("getMember");

            DataTable Member = Utils.Utils.getJSONtoDataTable(reader.ReadLine());


            #region 가변적treeView구성
            foreach (DataRow row in dept.Rows)
            {
                MemberItem depart = new MemberItem() { Title = Utils.Utils.getObjectToString(row["DEPTNAME"]) };

                foreach (DataRow dr in Member.Rows)
                {
                    if (Utils.Utils.getObjectToString(row["DEPT"]) 
                        == Utils.Utils.getObjectToString(dr["DEPT"]))
                    {
                        MemberItem member = new MemberItem() {  Title = Utils.Utils.getObjectToString(dr["NAME"]) + " " + Utils.Utils.getObjectToString(dr["TITLE"]) };
                        depart.Items.Add(member);

                    }

                }
                MemberTreeView.Items.Add(depart);
            }
            #endregion

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock block = sender as TextBlock;

            string str = block.Text;

            #region
            MakeChattingRoom(str);
            #endregion
            

        }

        private void MakeChattingRoom(string chatMem)
        {
        }

    }
    public class MemberItem
    {
        public MemberItem()
        {
            this.Items = new ObservableCollection<MemberItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MemberItem> Items { get; set; }
    }
}
