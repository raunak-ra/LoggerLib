using System;

namespace Logger
{
    public interface ITxsLogger
    {
        void InitLogger();
        Task WriteLogAsync(LogBase logger);
    }
}
