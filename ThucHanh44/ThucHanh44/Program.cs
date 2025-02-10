using System;
using System.Net;
using System.Net.NetworkInformation;



public class Program
{
    public static void Main(string[] args)
    {
        var ping = new Ping();
        var pingReply = ping.Send("google.com.vn");
        Console.WriteLine(pingReply.Status);
        if (pingReply.Status == IPStatus.Success)
        {
            Console.WriteLine(pingReply.RoundtripTime);
            Console.WriteLine(pingReply.Address);
        }


    }
}