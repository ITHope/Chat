using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect("127.0.0.1", 8080);

                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);
                    BinaryWriter writer = new BinaryWriter(stream);

                    while (true)
                    {
                        Console.WriteLine("Server:" + reader.ReadString());
                        Console.Write("Client:");
                        writer.Write(Console.ReadLine());
                        Console.WriteLine("Server:" + reader.ReadString());
                    }
                }
                catch
                {
                    Console.WriteLine("Cannot connect to server.");
                }
            }
        }
    }
}
