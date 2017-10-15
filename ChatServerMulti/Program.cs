﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServerMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatServer server = new ChatServer("127.0.0.1", 9050);
            server.Start();
        }
    }
}