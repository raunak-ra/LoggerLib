using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ErrorLog : LogBase
    {

        public Exception exception { get; set; }
        public override string Type { get => "error"; }
        public override List<KeyValuePair<string, object>> GetLogData()
        {
            var logData = base.GetLogData();
            logData.Add(new KeyValuePair<string, object>("message", this.exception.Message));
            logData.Add(new KeyValuePair<string, object>("exception_type", this.exception.GetType().Name));
            logData.Add(new KeyValuePair<string, object>("stacktrace", this.exception.StackTrace));
            logData.Add(new KeyValuePair<string, object>("inner_exception", this.exception.InnerException));
            return logData;
        }
    }
}
