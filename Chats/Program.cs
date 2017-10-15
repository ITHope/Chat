﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chats
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();
            Console.WriteLine("Waiting for a client...");
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client was connected. Waititng for activity...");
                    NetworkStream stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);
                    BinaryWriter writer = new BinaryWriter(stream);

                    while (true)
                    {
                        string data = reader.ReadString();
                        Console.WriteLine($"Client: {data}");
                        writer.Write(data);
                        Console.WriteLine($"Server: {data}");
                    }
                }
                catch
                {
                    Console.WriteLine("Client was disconnected.");
                }
            }

        }
    }
}
