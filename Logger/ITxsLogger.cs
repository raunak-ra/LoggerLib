using System;
using System.Threading.Tasks;

namespace Logger
{
    public interface ITxsLogger
    {
        void InitLogger();
        Task WriteLogAsync(LogBase logger);
    }
}
