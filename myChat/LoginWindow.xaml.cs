using DataModule;
using myChat.Popup;
using myChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;

namespace myChat
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if(Connector.Login(fncTextSabun.Text, fncTextPassword.Text, fncTextIP.Text) == myChatClass.LOGIN_STATUS.SUCCESS)
                {

                }
                else
                {
                    
                    return;
                }
            }
            catch (ArgumentNullException ex)
            {
                string errorMsg = string.Format("메시지: {0}\n경로 : {1}\n", ex.Message, ex.StackTrace);
                ErrorPopup errorPopup = new ErrorPopup("ArgumentNullException", errorMsg);
                errorPopup.ShowDialog();
                return;
            }
            catch (SocketException ex)
            {
                string errorMsg = string.Format("메시지: {0}\n경로 : {1}\n", ex.Message, ex.StackTrace);
                ErrorPopup errorPopup = new ErrorPopup("SocketException", errorMsg);
                errorPopup.ShowDialog();
                return;
            }
            fncUser user = fncUser.getUser;

            MainWindow window = new MainWindow();
            //LoginModule.userInfo.setSeq(NameTextBox.Text);

            window.ShowDialog();

            
            this.Close();
        }

        private void IpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            myChatClass.Definition.SERVER_IP = (sender as TextBox).Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fncCheckSaveID.IsChecked = Properties.Settings.Default.SaveID;
            fncCheckAutoLogin.IsChecked = Properties.Settings.Default.autoLogin ;

            if (fncCheckSaveID.IsChecked == true)
            {
                fncTextSabun.Text = Properties.Settings.Default.SavedID;
                fncTextPassword.Text = Properties.Settings.Default.SavedPW;
            }

            var host = Dns.GetHostEntry(Dns.GetHostName());
            string IP_address = string.Empty;

#if DEBUG
            IP_address = "127.0.0.1";
#else
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            IP_address = ip.ToString();
                        }
                    }

#endif

            fncTextIP.Text = IP_address;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveID = (bool)fncCheckSaveID.IsChecked;
            if (Properties.Settings.Default.SaveID == true)
            {
                Properties.Settings.Default.SavedID = fncTextSabun.Text;
                Properties.Settings.Default.SavedPW = fncTextPassword.Text;
            }
            else
            {
                Properties.Settings.Default.SavedID = "";
                Properties.Settings.Default.SavedPW = "";
            }
            Properties.Settings.Default.Save();
        }
    }
}
