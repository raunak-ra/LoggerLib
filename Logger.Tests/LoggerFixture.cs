using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests
{
    public class LoggerFixture
    {
        private readonly ITxsLogger logger = new TxsLogger();
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }

        [Fact]
        public void Logger_Should_Be_Write_ApiLog_In_File()
        {
            var log = new ApiLog();
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            logger.WriteLogAsync(log);
            Assert.Equal(5, log.GetData().Count);
        }

        [Fact]
        public void Logger_Should_Be_Write_Log_Additional_Logs_In_File()
        {

            var log = new ApiLog();
            PropertyA = "propertyA";
            PropertyB = "propertyB";
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            log.keyValuePair.Add(new KeyValuePair<string, object>("property_a", this.PropertyA));
            log.keyValuePair.Add(new KeyValuePair<string, object>("property_b", this.PropertyB));
            logger.WriteLogAsync(log);
            Assert.Equal(7, log.GetData().Count);
        }

        [Fact]
        public void Logger_Should_Be_Write_Log_ErrorLogs_In_File()
        {

            var log = new ErrorLog();
            Exception ex = new NotImplementedException();
            log.exception = ex;
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            logger.WriteLogAsync(log);
            Assert.Equal(9, log.GetData().Count);
        }

        [Fact]
        public void Logger_Should_Be_Write_Log_TraceLogs_In_File()
        {

            var log = new TraceLog();
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            log.Message = "calling sorting method";
            log.Method = "method A";
            log.TimeElapsedInMilliSeconds = "12ms";
            logger.WriteLogAsync(log);
            Assert.Equal(8, log.GetData().Count);
        }
    }
}
