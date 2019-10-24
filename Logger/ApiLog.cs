using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ApiLog : LogBase
    {
        public override string Type { get => "api"; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public override List<KeyValuePair<string, object>> GetLogData()
        {
            var logData = base.GetLogData();
            logData.Add(new KeyValuePair<string, object>("type", this.Type));
            logData.Add(new KeyValuePair<string, object>("request", this.Request));
            logData.Add(new KeyValuePair<string, object>("response", this.Response));
            logData.Add(new KeyValuePair<string, object>("status", this.Status));
            return logData;
        }
    }
}
