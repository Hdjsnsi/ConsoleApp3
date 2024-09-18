using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Chon chuc nang: 1.Server , 2.Client");
        int i = int.Parse(Console.ReadLine());
        switch (i)
        {
            case 1:
                Server();
                break;
            case 2:
                Client();
                break;
        }

    }
    static void Server()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8080);
        server.Start();
        Console.WriteLine("Server start...");
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            NetworkStream network = client.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes("Hello,Client");
            network.Write(buffer, 0, buffer.Length);
            client.Close();
        }
    }
    static void Client()
    {

        Console.WriteLine("Nhap ip: ");
        string serverIp = Console.ReadLine();
        Console.WriteLine("Nhap port: ");
        int port = int.Parse(Console.ReadLine());
        TcpClient client = new TcpClient();
        client.Connect(serverIp, port);
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
        client.Close();
    }
}