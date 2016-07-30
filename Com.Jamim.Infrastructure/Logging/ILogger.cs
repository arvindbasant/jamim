
namespace Com.Jamim.Infrastructure.Logging
{
    public interface ILogger
    {
        void Log(LogType logType, string message, MessageType messageType = MessageType.Notice);
    }
}
