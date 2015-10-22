using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MyTCPChat
{
    public partial class Client : Form
    {
        private static readonly IPAddress dafaultIP = IPAddress.Parse("127.0.0.1");
        TcpClient client;
        private static  int defaultPort;


        public Client(int port)
        {
            InitializeComponent();
            defaultPort = port;
            this.Text = String.Format("Client: {0}", port);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
                client.Close();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //создание экземпляра класса IPEndPoint
                IPEndPoint endPoint = new IPEndPoint(dafaultIP, defaultPort);
                client = new TcpClient();
                //установка соединения с использованием 
                //данных IP и номера порта
                client.Connect(endPoint);

                //получение сетевого потока
                NetworkStream nstream = client.GetStream();
                //преобразование строки сообщения в массив байт
                byte[] barray = Encoding.Unicode.GetBytes(tbxSend.Text);
                //запись в сетевой поток всего массива 
                nstream.Write(barray, 0, barray.Length);
                //закрытие клиента
                client.Close();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка :" + Ex.Message);
            }
        }
    }
}
