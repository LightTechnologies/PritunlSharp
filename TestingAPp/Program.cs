using System;
using System.IO;
using System.Threading.Tasks;
using Pritunl.Wrapper;
using Pritunl.Wrapper.Models;

namespace TestingAPp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var pritunl = new PritunlClient("https://51.222.29.230:50000", "K4g99pZpt66HFIDjiXuRlSEKiXRa9reO", "LuplBRrrWJnh1Iy9ZDPLIuk6hNpGBCbZ");
            Console.WriteLine(await pritunl.Servers.GetServersAsync());

            //Console.WriteLine(await Users.CreateUser("Test", "TestUser"));
            //Console.WriteLine(await Users.DeleteUser("Test", "TestUser"));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
