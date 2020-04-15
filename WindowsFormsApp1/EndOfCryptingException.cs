using System;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class EndOfCryptingException : Exception
    {
        public EndOfCryptingException()
        {
        }

        public EndOfCryptingException(string message) : base(message)
        {
        }

        public EndOfCryptingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EndOfCryptingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}