using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class TxsLogger : ITxsLogger
    {
        public void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Information()
                         .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                         .Enrich.FromLogContext()
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose).WriteTo.RollingFile(@"Logs/Verbose/Verbose-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.RollingFile(@"Logs/Debug/Debug-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(@"Logs/Api/Api-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.RollingFile(@"Logs/Warning/Warning-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(@"Logs/Error/Error-{Date}.log"))
                         .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.RollingFile(@"Logs/Fatal/Fatal-{Date}.log"))
                         .CreateLogger();
        }


        public async Task WriteLogAsync(LogBase logger)
        {
            var logData = logger.GetLogData();

            if (logger is ErrorLog)
            {
                Log.Error("{@data}", logData);
            }
            else
            {
                Log.Information("{@data}", logData);
            }

        }

    }
}
