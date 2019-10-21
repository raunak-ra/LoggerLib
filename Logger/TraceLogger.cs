﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class TraceLogger : LogBase
    {
        public override string Type { get => "trace"; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string TimeElapsed { get; set; }

        public override List<KeyValuePair<string, object>> GetData()
        {
            var data = base.GetData();
            data.Add(new KeyValuePair<string, object>("type", this.Type));
            data.Add(new KeyValuePair<string, object>("message", this.Message));
            data.Add(new KeyValuePair<string, object>("status", this.Status));
            data.Add(new KeyValuePair<string, object>("time_elapsed", this.TimeElapsed));
            return data;
        }
    }
}
