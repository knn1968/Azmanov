using System;
//using System.Runtime.Serialization;

namespace Core
{
//    [Serializable]
    public class PagingException : Exception
    {
        public PagingException()
        {
        }

        public PagingException(string message) : base(message)
        {
        }

        public PagingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //protected PagingException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}