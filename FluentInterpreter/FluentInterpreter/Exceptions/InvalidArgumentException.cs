#region

using System;

#endregion

namespace FluentInterpreter.Exceptions
{
    public class InvalidArgumentException : Exception
    {
        private const string DEFAULT_MESSAGE = "The argument is null or empty!";

        public InvalidArgumentException() : base(DEFAULT_MESSAGE)
        {
        }
    }
}