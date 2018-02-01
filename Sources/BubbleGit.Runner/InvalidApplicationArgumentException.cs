using System;

namespace BubbleGit.Runner
{
    public class InvalidApplicationArgumentException : Exception
    {
        public InvalidApplicationArgumentException(string message) : base(message)
        {
        }
    }
}