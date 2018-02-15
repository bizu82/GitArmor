using System;
using System.IO;

namespace Core.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly string m_appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public ILogger CreateForRunner()
        {
            return new Logger(Path.Combine(m_appData, @"GitArmor\Logs\Runner.log"));
        }

        public ILogger CreateForConfigurator()
        {
            return new Logger(Path.Combine(m_appData, @"GitArmor\Logs\Configurator.log"));
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateForRunner();
        ILogger CreateForConfigurator();
    }

    internal class Logger : ILogger
    {
        private readonly string m_path;

        public Logger(string path)
        {
            m_path = path;
        }

        public void Error(string message)
        {
            Log("ERROR", message);
        }

        public void Warning(string message)
        {
            Log("WARNING", message);
        }

        public void Error(Exception exception)
        {
            Error(exception.ToString());
        }

        public void Info(string message)
        {
            Log("INFO", message);
        }

        private void Log(string level, string message)
        {
            try
            {
                using (var tw = File.CreateText(m_path))
                {
                    tw.WriteLine($"{DateTime.Now:G} - [{level}] - {message}");
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public interface ILogger
    {
        void Error(string message);
        void Info(string message);
        void Warning(string message);
        void Error(Exception exception);
    }
}
