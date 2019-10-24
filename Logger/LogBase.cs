﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public abstract class LogBase
    {
        public string SessionId { get; set; }
        public abstract string Type { get; }
        public string ApplicationName { get; set; }
        public string Method { get; set; }

        public List<KeyValuePair<string, object>> keyValuePair = new List<KeyValuePair<string, object>>();
        public virtual List<KeyValuePair<string, object>> GetLogData()
        {
            var logData = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("session_id", this.SessionId),
                new KeyValuePair<string, object>("type", this.Type),
                new KeyValuePair<string, object>("application_name", this.ApplicationName),
                new KeyValuePair<string, object>("method", this.Method)
            };
            if (keyValuePair.Count != 0)
            {
                foreach (var pair in keyValuePair)
                {
                    logData.Add(pair);
                }
            }
            return logData;
        }
    }
}
