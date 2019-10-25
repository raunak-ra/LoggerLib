using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests
{
    public class LoggerFixture
    {
        private readonly ITxsLogger logger = new TxsLogger();

        [Fact]
        public void Logger_Should_Write_Api_Logs_In_File()
        {
            var log = new ApiLog();
            log.ApplicationName = "apiName";
            log.MethodName = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            logger.WriteLogAsync(log);
            Assert.Equal(7, log.GetLogData().Count);
        }

        // just for testing purposes 
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }

        [Fact]
        public void Logger_Should_Write_Additional_Logs_In_File()
        {

            var log = new ApiLog();
            PropertyA = "propertyA";
            PropertyB = "propertyB";
            log.ApplicationName = "apiName";
            log.MethodName = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            log.keyValuePair.Add(new KeyValuePair<string, object>("property_a", this.PropertyA));
            log.keyValuePair.Add(new KeyValuePair<string, object>("property_b", this.PropertyB));
            logger.WriteLogAsync(log);
            Assert.Equal(9, log.GetLogData().Count);
        }

        [Fact]
        public void Logger_Should_Write_Error_Logs_In_File()
        {

            var log = new ExceptionLog();
            Exception ex = new NotImplementedException();
            log.exception = ex;
            log.ApplicationName = "apiName";
            log.MethodName = "getvalue";
            log.SessionId = "12ert345rgftfsb877";

            logger.WriteLogAsync(log);
            Assert.Equal(8, log.GetLogData().Count);
        }

        [Fact]
        public void Logger_Should_Write_Trace_Logs_In_File()
        {

            var log = new TraceLog();
            log.ApplicationName = "apiName";
            log.MethodName = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            log.Message = "calling sorting method";
            log.Status = "OK";
            log.TimeElapsedInMilliSeconds = "12ms";
            logger.WriteLogAsync(log);
            Assert.Equal(7, log.GetLogData().Count);
        }
    }
}
