using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class TraceLog : LogBase
    {
        public override string Type { get => "trace"; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string TimeElapsedInMilliSeconds { get; set; }

        public override List<KeyValuePair<string, object>> GetLogData()
        {
            var logData = base.GetLogData();
            logData.Add(new KeyValuePair<string, object>("message", this.Message));
            logData.Add(new KeyValuePair<string, object>("status", this.Status));
            logData.Add(new KeyValuePair<string, object>("time_elapsed_in_millisecond", this.TimeElapsedInMilliSeconds));
            return logData;
        }
    }
}
