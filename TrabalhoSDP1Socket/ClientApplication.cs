using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

namespace TrabalhoSDP1Socket
{
    class ClientApplication
    {
        static void Main(string[] args)
        {
            connection:
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1500);
                string messageToSend;

                Console.WriteLine("Conected to server, send a message:");
                messageToSend = Console.ReadLine();

                int byteCount = Encoding.UTF8.GetByteCount(messageToSend + 1);
                byte[] sendData = new byte[byteCount];
                sendData = Encoding.UTF8.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data to server...\n");
                Thread.Sleep(10);

                StreamReader _reader = new StreamReader(stream);
                string response = _reader.ReadLine();
                Console.WriteLine(response);

                stream.Close();
                client.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("error connecting to server...");
                Console.WriteLine("\n\n============\n\n" + e.Message + "\n\n============\n\n");
                Console.WriteLine("press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                goto connection;
            }
        }
    }
}
