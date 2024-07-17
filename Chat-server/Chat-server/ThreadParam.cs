using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat_server
{
    internal class ThreadParam
    {
        public TcpClient c;
        public Dictionary<string, TcpClient> List;
        public ThreadParam (TcpClient c, Dictionary<string, TcpClient> list)
        {
            this.c = c;
            this.List = list;
        }
    }
}
