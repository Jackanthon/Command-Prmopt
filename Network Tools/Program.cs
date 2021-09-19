using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;

public class Start
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Microsoft Windows[Version 10.0.19042.1165]\n" +
            "(c) Microsoft Corporation.All rights reserved.");
        menu();
        Console.ReadLine();
    }
    public static void menu()
    {
        Console.Write("\nC:\\Users\\JackA>");
        string userChoice = Console.ReadLine();
        if (userChoice == "ipconfig") { Network_Tools.ipconfig.Scan(); }
        if (userChoice.Length > 8 && userChoice.Substring(0,4) == "ping") {
            string pingThis = userChoice.Substring(5, (userChoice.Length - 5));
            Network_Tools.SocketListener.Ping(pingThis); }
        if (userChoice == "hostname") { hostname(); }
        if (userChoice == "??") {  }
        else { Console.WriteLine("'{0}' is not recognized as an internal or external command, \noperable program or batch file.", userChoice);
            menu();
        }
        Console.ReadLine();
    }
    public static void hostname()
    {
        string hostName = Dns.GetHostName();
        Console.WriteLine(hostName);
        menu();
    }
}




//3. Hostname Command
//A very simple command that displays the host name of your machine. This is much quicker than going to the control panel>system route.

//windows-network-command-hostname

//4. getmac Command
//Another very simple command that shows the MAC address of your network interfaces

//windows-network-command-getmac

//5. arp Command
//This is used for showing the address resolution cache. This command must be used with a command line switch arp -a is the most common.

//windows-network-command-arp

//Type arp at the command line to see all available options.


