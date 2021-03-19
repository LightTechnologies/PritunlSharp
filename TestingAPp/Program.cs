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
            APICredentials.APIToken = "K4g99pZpt66HFIDjiXuRlSEKiXRa9reO";
            APICredentials.APISecret = "LuplBRrrWJnh1Iy9ZDPLIuk6hNpGBCbZ";
            APICredentials.APIUrl = "https://51.222.29.230:50000";
            var keybytes = await Users.GetKeys("LightVPNPro", "Toshi", Users.KeyType.Zip);

            await File.WriteAllBytesAsync("configs.zip", keybytes);
            Console.WriteLine(await Users.CreateUser("Test", "TestUser"));
            Console.WriteLine(await Users.DeleteUser("Test", "TestUser"));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
