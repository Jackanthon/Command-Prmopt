using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;
using System.Linq;
namespace Network_Tools
{
    class ipconfig
    {
         public static void Scan()
        {
            string hostName = Dns.GetHostName();
            try
            {
                IPAddress[] iPAddresses = Dns.Resolve(hostName).AddressList;
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
               
                foreach (NetworkInterface networkInterface in networkInterfaces)

                {
                    Console.WriteLine("\n{0} {1}:", networkInterface.NetworkInterfaceType, networkInterface.Name);
                    if (networkInterface.OperationalStatus == OperationalStatus.Down)
                    {
                        Console.WriteLine("\n   Media State . . . . . . . . . . . : Media disconnected");
                        Console.WriteLine("   Connection-specific DNS Suffix  . :");
                    }
                    else if (networkInterface.OperationalStatus == OperationalStatus.Up)
                    {

                        foreach (IPAddress address in iPAddresses)
                        {
                            IPAddress[] iPAddressv6 = Dns.GetHostAddresses(hostName);
                            foreach (IPAddress ipv6 in iPAddressv6.Where(ip => ip.AddressFamily == AddressFamily.InterNetworkV6))
                            {
                                Console.WriteLine("   Connection-specific DNS Suffix  . : Home");
                                Console.WriteLine("   Link-local IPv6 Address . . . . . : " + ipv6);
                            }
                            Console.WriteLine("   IPv4 Address. . . . . . . . . . . : " + address);
                        }
                        foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
                            foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                            {
                                IPInterfaceProperties ipInterface = f.GetIPProperties();
                                foreach (UnicastIPAddressInformation unicastAddress in ipInterface.UnicastAddresses)
                                {
                                    string subnet = unicastAddress.IPv4Mask.ToString();
                                    if (subnet[0] == '2') { Console.WriteLine("   Sbunet mask . . . . . . . . . . . : " + subnet);}
                                }
                                Console.WriteLine("   Default Gateway . . . . . . . . . : {0}", d.Address);
                            }
                    }
                }
                Start.menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
                Start.menu();
            }
        }
    }
}
