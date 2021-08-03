using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var chat = new Chat();
            await chat.Start();
        }
    }
}
