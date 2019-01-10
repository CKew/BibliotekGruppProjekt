using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BibliotekGruppProjekt
{
    public class Program
    {
        // Program happens first when code runs
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // Here it jumps to startup.cs
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
