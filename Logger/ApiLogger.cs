using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ApiLog : LogBase
    {
        public override string Type { get => "api"; }
        public override List<KeyValuePair<string, object>> GetData()
        {
            var data = base.GetData();
            data.Add(new KeyValuePair<string, object>("type", this.Type));
            return data;
        }
    }
}
