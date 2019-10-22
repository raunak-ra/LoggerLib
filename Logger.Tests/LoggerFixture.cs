using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests
{
    public class LoggerFixture
    {
        private readonly ITxsLogger l = new TxsLogger();
        public string PropA { get; set; }
        public string PropB { get; set; }

        [Fact]
        public void Testing_for_apilogger()
        {
            var log = new ApiLog();
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            l.WriteLogAsync(log);
            Assert.Equal(5, log.GetData().Count);
        }

        [Fact]
        public void Testing_for_extradata()
        {

            var log = new ApiLog();
            PropA = "propertyA";
            PropB = "propertyB";
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            log.keyValuePair.Add(new KeyValuePair<string, object>("prop_a", this.PropA));
            log.keyValuePair.Add(new KeyValuePair<string, object>("prop_b", this.PropB));
            l.WriteLogAsync(log);
            Assert.Equal(7, log.GetData().Count);
        }

        [Fact]
        public void Testing_for_errorlogger()
        {

            var log = new ErrorLog();
            Exception ex = new NotImplementedException();
            log.exception = ex;
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            l.WriteLogAsync(log);
            Assert.Equal(9, log.GetData().Count);
        }

        [Fact]
        public void Testing_for_tracelogger()
        {

            var log = new TraceLog();
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            log.Message = "calling sorting method";
            log.Method = "method A";
            log.TimeElapsedInMilliSeconds = "12ms";
            l.WriteLogAsync(log);
            Assert.Equal(8, log.GetData().Count);
        }
    }
}
