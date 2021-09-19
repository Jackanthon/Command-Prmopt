using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading;
using System.Linq;
namespace Network_Tools
{
    public class SocketListener
    {
        public static void Ping(string website)
        {
            //Network_Tools.ipconfig.Scan();
            Ping pingSender = new Ping();
            //sending 32 bytes of data
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            int timeout = 10000; //wait 10 seconds
            PingOptions options = new PingOptions(64, true);
            //sends ICMP request
            try
            {
                PingReply reply = pingSender.Send(website, timeout, buffer, options);
                PingReply reply1 = pingSender.Send(website, timeout, buffer, options);
                PingReply reply2 = pingSender.Send(website, timeout, buffer, options);
                PingReply reply3 = pingSender.Send(website, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("\nPinging {0} [{1}] with {2} bytes of data:", website, reply.Address.ToString(), reply.Buffer.Length);
                    Console.WriteLine("Reply from {0}: bytes={1} time={2}ms TTL={3}", reply.Address.ToString(), reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl);
                    Thread.Sleep(1000);
                    Console.WriteLine("Reply from {0}: bytes={1} time={2}ms TTL={3}", reply.Address.ToString(), reply.Buffer.Length, reply1.RoundtripTime, reply.Options.Ttl);
                    Thread.Sleep(1000);
                    Console.WriteLine("Reply from {0}: bytes={1} time={2}ms TTL={3}", reply.Address.ToString(), reply.Buffer.Length, reply2.RoundtripTime, reply.Options.Ttl);
                    Thread.Sleep(1000);
                    Console.WriteLine("Reply from {0}: bytes={1} time={2}ms TTL={3}", reply.Address.ToString(), reply.Buffer.Length, reply3.RoundtripTime, reply.Options.Ttl);
                    Thread.Sleep(1000);
                    Console.WriteLine("\nPing statistics for {0}:", reply.Address.ToString());
                    long[] Arr = { reply.RoundtripTime, reply1.RoundtripTime, reply2.RoundtripTime, reply3.RoundtripTime };

                    Console.WriteLine("    Packets: Sent = 4, Received 4, Lost = 0 (0% loss,\n" +
                        "Approximate round trip times in milli-seonds:");
                    Console.WriteLine("    Minimum = {0}ms, Maximum = {1}ms, Average = {2}ms", Arr.Min(), Arr.Max(), Arr.Average());
                
                }
                else
                {
                    Console.WriteLine(reply.Status);
                    Start.menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ping request could not find host {0}. Please check the name and try again.",website);
                Start.menu();
            }
            Start.menu();
        }
    }
}
