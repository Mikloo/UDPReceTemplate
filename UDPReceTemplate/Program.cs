using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPReceTemplate
{
    class Program
    {
        private const int Port = 7001;

        static void Main(string[] args)
        {
            //Oprettet en tom udpreciever, så der kan modtages UDP broadcasts, tager en Port som parameter
            UdpClient udpServer = new UdpClient(Port);

            //IPEndpoint er den ipadresse der bliver sendt fra, altså den source der broadcaster
            //kan være alle ip adresser
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);

            try
            {
                Console.WriteLine("Reciever is started");
                while (true)
                {
                    // Modtager den data broadcaster receiver 
                    Byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);
                 
                    // Transformer byte til string så vi kan print det ud senere
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    // Splitter dataen på /n og putter det ind i en array
                    string[] data = receivedData.Split('\n');
                    string data1 = data[0];
                    string data2 = data[1];
                    string data3 = data[2];

                    Console.WriteLine(data1);
                    Console.WriteLine(data2);
                    Console.WriteLine(data3);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
