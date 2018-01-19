using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientData
    {
        public Socket Client { get; set; }
        public string Email { get; set; }
        public int VoteQuestionId { get; set; }

        public ClientData(Socket socket)
        {
            Client = socket;
        }
    }
}
