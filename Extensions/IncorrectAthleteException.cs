using System;
using System.Runtime.Serialization;

namespace LW1.Models
{
    public class IncorrectAthleteException : SystemException
    {
        public IncorrectAthleteException()
        {
        }

        public IncorrectAthleteException(string message) : base(message)
        {
        }

        public IncorrectAthleteException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IncorrectAthleteException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}