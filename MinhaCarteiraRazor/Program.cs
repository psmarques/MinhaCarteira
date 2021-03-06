﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MinhaCarteiraRazor.Data;

namespace MinhaCarteiraRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            if (!File.Exists("minhaCarteira.db"))
            {
                MigrateDatabase(host);
            }

            host.Run();
        }

        private static void MigrateDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MinhaCarteiraDbContext>();
                db.Database.Migrate();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
