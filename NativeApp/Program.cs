using System;
using System.Threading.Tasks;

namespace NativeApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new TestCustomAPIService();
            await service.FreeGetAsync();
            await service.ChargedGetAsync("this is a test");
            Console.ReadLine();
        }
    }
}
