using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pinging Google DNS Server 8.8.4.4;

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;
            string data = "Learn to ping some network provider";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeOut = 120;
            string address = "8.8.4.4";
            PingReply reply = pingSender.Send(address, timeOut, buffer, options);
            if(reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Response: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
        }
    }
}
