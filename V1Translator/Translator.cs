using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace V1Translator
{
    public class Translator
    {
        public const string ServerName = "netCore ntrip Translator\r\n";

        public static void StartSync(string ip, int port, string remote)
        {
            var tl = new TcpListener(System.Net.IPAddress.Parse(ip), port);

            tl.Start();

            Socket sock;
            
            while ((sock = tl.AcceptSocket()) != null)
            {
                var thr = new Thread(HandleSocket);
                thr.Start(sock);
            }
        }

        private static void HandleSocket(object sockObj)
        {
            var sock = (Socket)sockObj;

            var myStream = new NetworkStream(sock);

            var req = XttpRequest.ReadXttpReq(myStream);



        }

        

    }
}
