using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace ServerSDP1
{
    class ServerApplication
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1500);
            listener.Start();

            while (true)
            {
                Console.WriteLine("waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("client accepted.");

                NetworkStream stream = client.GetStream();
                StreamReader _reader = new StreamReader(client.GetStream());
                StreamWriter _writer = new StreamWriter(client.GetStream());

                try
                {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);

                    int usedBytes = 0;
                    foreach (byte b in buffer)
                    {
                        if (b != 0)
                        {
                            usedBytes++;
                        }
                    }
                    string request = Encoding.UTF8.GetString(buffer, 0, usedBytes);
                    Console.WriteLine("request received: " + request);
                    _writer.WriteLine("Message received succefully!");
                    _writer.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine("something went wrong..."); 
                    Console.WriteLine("\n\n============\n\n" + e.Message + "\n\n============\n\n");
                    Console.ReadKey();
                }
            }
        }
    }
}
