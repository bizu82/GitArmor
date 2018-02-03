using System;

namespace Runner
{
    public class InvalidApplicationArgumentException : Exception
    {
        public InvalidApplicationArgumentException(string message) : base(message)
        {
        }
    }
}