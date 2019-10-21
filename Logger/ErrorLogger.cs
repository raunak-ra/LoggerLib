using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ErrorLogger : LogBase
    {

        public Exception exception { get; set; }
        public override string Type { get => "error"; }
        public override List<KeyValuePair<string, object>> GetData()
        {
            var data = base.GetData();
            data.Add(new KeyValuePair<string, object>("type", this.Type));
            data.Add(new KeyValuePair<string, object>("message", this.exception.Message));
            data.Add(new KeyValuePair<string, object>("type", this.exception.GetType()));
            data.Add(new KeyValuePair<string, object>("stacktrace", this.exception.StackTrace));
            data.Add(new KeyValuePair<string, object>("inner_exception", this.exception.InnerException));

            return data;

        }
    }
}
