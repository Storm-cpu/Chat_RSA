using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Linq;

namespace Chat_server
{
    public partial class Form1 : Form
    {
        int clientCount = 0;
        Dictionary<string, TcpClient> dtthread = new Dictionary<string, TcpClient>();
        List<string> clientEndpoints;
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> publicKeys = new Dictionary<string, string>();
        private void btnStart_Click(object sender, EventArgs e)
        {
            int count = 0;
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            tnameServer.Text = "Server started!";
            tnameServer.Refresh();
            while (true)
            {
                if (clientCount < 2)
                {
                    TcpClient client = server.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byteCount = stream.Read(buffer, 0, buffer.Length);
                    string publicKey = Encoding.Unicode.GetString(buffer, 0, byteCount);

                    publicKeys[client.Client.RemoteEndPoint.ToString()] = publicKey;

                    dtthread.Add(client.Client.RemoteEndPoint.ToString(), client);
                    ThreadParam para = new ThreadParam(client, dtthread);
                    Thread t = new Thread(Connect);
                    t.Start(para);
                    count++;
                    clientCount++;
                }
                else
                {
                    clientEndpoints = dtthread.Keys.ToList();

                    var client1PublicKey = publicKeys[clientEndpoints[0]];
                    var client2PublicKey = publicKeys[clientEndpoints[1]];

                    byte[] buffer1 = Encoding.Unicode.GetBytes(client1PublicKey);
                    NetworkStream stream1 = dtthread[clientEndpoints[1]].GetStream();
                    stream1.Write(buffer1, 0, buffer1.Length);

                    byte[] buffer2 = Encoding.Unicode.GetBytes(client2PublicKey);
                    NetworkStream stream2 = dtthread[clientEndpoints[0]].GetStream();
                    stream2.Write(buffer2, 0, buffer2.Length);

                    break;
                }
            }

        }

        public void Connect(object o)
        {
            ThreadParam para = (ThreadParam)o;
            Dictionary<string, TcpClient> dtthread = para.List;
            TcpClient localClient = para.c;
            string localEndpoint = localClient.Client.RemoteEndPoint.ToString();
            string lastSentData = null; 

            while (true)
            {
                NetworkStream readStream = localClient.GetStream();
                byte[] buffer = new byte[1024];
                int count = readStream.Read(buffer, 0, buffer.Length);
                byte[] format = new byte[count];
                Array.Copy(buffer, format, count);
                string data = Encoding.Unicode.GetString(format);

                if (data == "RESEND" && lastSentData != null)
                {
                    data = lastSentData; // Resend the last sent data
                }

                if (localEndpoint == clientEndpoints[0] && dtthread[clientEndpoints[1]].Connected)
                {
                    byte[] buffer2 = Encoding.Unicode.GetBytes(data);
                    NetworkStream writeStream = dtthread[clientEndpoints[1]].GetStream();
                    writeStream.Write(buffer2, 0, buffer2.Length);
                    lastSentData = data; // Update the last sent data
                }
                else if (localEndpoint == clientEndpoints[1] && dtthread[clientEndpoints[0]].Connected)
                {
                    byte[] buffer2 = Encoding.Unicode.GetBytes(data);
                    NetworkStream writeStream = dtthread[clientEndpoints[0]].GetStream();
                    writeStream.Write(buffer2, 0, buffer2.Length);
                    lastSentData = data; // Update the last sent data
                }
            }
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            foreach (var client in dtthread.Values)
            {
                client.Close();
            }
            Application.Exit();
        }

    }
}
