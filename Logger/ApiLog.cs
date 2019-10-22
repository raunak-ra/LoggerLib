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
        public override List<KeyValuePair<string, object>> GetData()
        {
            var data = base.GetData();
            data.Add(new KeyValuePair<string, object>("type", this.Type));
            data.Add(new KeyValuePair<string, object>("request", this.Request));
            data.Add(new KeyValuePair<string, object>("response", this.Response));
            data.Add(new KeyValuePair<string, object>("status", this.Status));
            return data;
        }
    }
}
