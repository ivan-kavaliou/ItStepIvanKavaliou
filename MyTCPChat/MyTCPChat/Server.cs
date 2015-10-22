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
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace MyTCPChat
{
    public partial class Server : Form
    {
        private static int clientPort = 10000;
        private static readonly IPAddress dafaultIP = IPAddress.Parse("127.0.0.1");
        private List<IPEndPoint> ipEndPointList=new List<IPEndPoint>();
        private Socket socket;
        TcpListener list;

        public Server()
        {
            InitializeComponent();
            ipEndPointList.Add(new IPEndPoint(dafaultIP, clientPort));
            //StartServer();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (list != null)
                list.Stop();
        }


        private void btnMakeClient_Click(object sender, EventArgs e)
        {
            clientPort++;
            Client newClient = new Client(clientPort);
            //добавляем в список активных клиентов чата
            lstbClients.Items.Add(String.Format("Client {0}", clientPort)).ToString();
            makeIPEndPoint(clientPort);
            newClient.Show();


            try
            {
                //создание экземпляра класса TcpListener
                //данные о хосте и порте читаются 
                //из текстовых окон
                list = new TcpListener(dafaultIP, clientPort);
                //начало прослушивания клиентов
                list.Start();
                //создание отдельного потока для чтения сообщения
                Thread thread = new Thread( new ThreadStart(ThreadFun) );
                thread.IsBackground = true;
                //запуск потока
                thread.Start();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета: " + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка : " + Ex.Message);
            }

        }


        void ThreadFun()
        {
            while (true)
            {
                //сервер сообщает клиенту о готовности к соединению
                TcpClient cl = list.AcceptTcpClient();
                //чтение данных из сети в формате Unicode
                StreamReader sr = new StreamReader( cl.GetStream(), Encoding.Unicode);
                string s = sr.ReadLine();
                //добавление полученного сообщения в список 
                lstbMainChat.Items.Add(s);
                cl.Close();
                //при получении сообщения EXIT завершить приложение
                if (s.ToUpper() == "EXIT")
                {
                    list.Stop();
                    this.Close();
                }
            }
        }


        public void makeIPEndPoint(int clientP)
        {
            ipEndPointList.Add(new IPEndPoint(dafaultIP, clientP));
        }

        


    }
}
