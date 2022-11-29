using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Eum.Shared.Common.Helpers.SeriLog
{
    public class EumSeriLogHelper
    {
        public static void ConfigureEumLogger(HostBuilderContext context, LoggerConfiguration config)
        {
            //appsetting ? or hard-coding
            config.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
        
        }
    }
}
