﻿using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
namespace Api
{
    public class LambdaEntryPoint : APIGatewayHttpApiV2ProxyFunction

    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Program>();
        }
    }
}
