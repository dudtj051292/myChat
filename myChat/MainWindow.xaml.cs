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
using System.Windows.Input;
using myChatClass;
using myChat;

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

        public MainWindow(string sabun)
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

            DataTable dept = Utils.getJSONtoDataTable(reader.ReadLine());



            writer.WriteLine("getMember" );

            DataTable Member = Utils.getJSONtoDataTable(reader.ReadLine());


            #region 가변적treeView구성
            foreach (DataRow row in dept.Rows)
            {
                MemberItem depart = new MemberItem() { Title = Utils.getObjectToString(row["DEPTNAME"]) };

                foreach (DataRow dr in Member.Rows)
                {
                    if (Utils.getObjectToString(row["DEPT"])
                        == Utils.getObjectToString(dr["DEPT"]))
                    {
                        MemberItem member = new MemberItem() { Title = Utils.getObjectToString(dr["NAME"]) + " " + Utils.getObjectToString(dr["TITLE"]) };
                        depart.Items.Add(member);
                        FncWorker worker = new FncWorker(Utils.getObjectToString(dr["NAME"]), 
                                                         Utils.getObjectToString(dr["TITLE"]) ,
                                                         Utils.getObjectToString(row["DEPT"]),
                                                         Utils.getObjectToDecimal(dr["SEQ"]));
                        Fnc.Workers.Add(worker);
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
            this.chatFrame.Navigate("ChatRoom.xaml", UriKind.RelativeOrAbsolute);

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
