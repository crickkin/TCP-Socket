using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace TrabalhoSDP1Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            connection:
            try
            {
                //
            }
            catch (Exception e)
            {
                Console.WriteLine("error connecting to server...");
                Console.WriteLine("\n\n============\n\n" + e.Message + "\n\n============\n\n");
                Console.WriteLine("press any key to try again.");
                Console.ReadLine();
                goto connection;
            }
        }
    }
}
