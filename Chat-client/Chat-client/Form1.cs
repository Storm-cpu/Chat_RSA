using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.IO;

namespace Chat_client
{
    public partial class Form1 : Form
    {
        public class RSAKeyPair
        {
            public string PublicKey { get; set; }
            public string PrivateKey { get; set; }

            public RSAKeyPair(string publicKey, string privateKey)
            {
                PublicKey = publicKey;
                PrivateKey = privateKey;
            }
        }

        TcpClient client;
        NetworkStream stream;
        byte[] data;
        string _privateKey;
        string recipientPublicKey;

        public Form1()
        {
            InitializeComponent();
        }

        public RSAKeyPair GenerateRSAKeyPair()
        {
            using (var rsa = new RSACryptoServiceProvider(2048)) 
            {
                return new RSAKeyPair(
                    publicKey: rsa.ToXmlString(false),
                    privateKey: rsa.ToXmlString(true));
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string server = "127.0.0.1";
            Int32 port = 5000;
            client = new TcpClient();
            client.Connect(server, port);
            stream = client.GetStream();

            // Generate RSA key pair
            var keyPair = GenerateRSAKeyPair();

            // Store the private key for later use
            _privateKey = keyPair.PrivateKey;

            // Send public key to server
            var publicKeyMessage = "PUBLICKEY " + keyPair.PublicKey;
            data = Encoding.Unicode.GetBytes(publicKeyMessage);
            stream.Write(data, 0, data.Length);

            Thread threat = new Thread(receive);
            threat.Start();
        }

        private void receive()
        {
            int resendRequestCount = 0;
            const int MAX_RESEND_REQUESTS = 5;
            while (true)
            {

                if (!client.Connected)
                {
                    break;
                }

                data = new byte[1024];
                string response = String.Empty;
                try
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    if (data != null)
                    {
                        response = Encoding.Unicode.GetString(data, 0, bytes);
                        resendRequestCount = 0;
                    }
                    else
                    {
                        if (resendRequestCount < MAX_RESEND_REQUESTS)
                        {
                            byte[] resendRequest = Encoding.Unicode.GetBytes("RESEND");
                            stream.Write(resendRequest, 0, resendRequest.Length);
                            resendRequestCount++;
                        }
                        else
                        {
                            break;
                        }
                        continue;
                    }

                    if (response.StartsWith("PUBLICKEY "))
                    {
                        recipientPublicKey = response.Substring("PUBLICKEY ".Length);
                    }
                    else if (response.StartsWith("ENCRYPTED "))
                    {
                        string encryptedMessage = response.Substring("ENCRYPTED ".Length);
                        var rsa = new RSACryptoServiceProvider();
                        rsa.FromXmlString(_privateKey);
                        var decryptedMessageBytes = rsa.Decrypt(Convert.FromBase64String(encryptedMessage), false);

                        string decryptedMessage = Encoding.Unicode.GetString(decryptedMessageBytes);

                        this.Invoke((MethodInvoker)delegate {
                            lchat.Items.Add(decryptedMessage);
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lchat.Items.Add(response);
                        });
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(recipientPublicKey))
            {
                try
                {
                    var rsa = new RSACryptoServiceProvider();

                    rsa.FromXmlString(recipientPublicKey);

                    var encryptedMessage = rsa.Encrypt(Encoding.Unicode.GetBytes(tname.Text + ">>> " + tchat.Text), false);

                    var encryptedMessageString = "ENCRYPTED " + Convert.ToBase64String(encryptedMessage);

                    data = Encoding.Unicode.GetBytes(encryptedMessageString);

                    stream.Write(data, 0, data.Length);

                    data = null;

                    this.Invoke((MethodInvoker)delegate
                    {
                        lchat.Items.Add(tname.Text + ">>> " + tchat.Text);
                    });

                    tchat.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Waiting for recipient's public key...");
            }
            }

    }
}
