using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class client
{

    public TcpClient _client;

    public int port;

    public IPAddress remote;

    public client(int port, IPAddress remote)
    {

        this.port = port;
        this.remote = remote;
    }

    public void connect()
    {
        this._client = new TcpClient();
        _client.Connect(remote, port);
    }
    public void disconnect()
    {
        _client.Close();
    }
    public void send(string msg)
    {
        byte[] data = Encoding.Default.GetBytes(msg);
        _client.GetStream().Write(data, 0, data.Length);
    }
    public void Receive()
    {
        byte[] buffer=new byte[256];
        int dataCount = _client.GetStream().Read(buffer, 0, buffer.Length);
        string value= Encoding.ASCII.GetString(buffer, 0, dataCount);
        Console.WriteLine("服务器发送数据-"+ value);
        

    }
}