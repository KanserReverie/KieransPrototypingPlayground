namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public interface IMessageLogger
    {
        void Log(string _message, MessageSeverity _messageSeverity);
    }
}