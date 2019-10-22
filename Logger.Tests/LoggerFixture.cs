using System;
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
            var log = new ApiLogger();
            log.ApplicationName = "apiName";
            log.Method = "getvalue";
            log.SessionId = "12ert345rgftfsb877";
            l.WriteLogAsync(log);
            Assert.Equal(5, log.GetData().Count);
        }
    }
}
