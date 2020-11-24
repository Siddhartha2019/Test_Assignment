using System;
using System.Runtime.Serialization;

namespace EmployeeSalary
{
    [Serializable]
    internal class TaskCancellationException : Exception
    {
        public TaskCancellationException()
        {
        }

        public TaskCancellationException(string message) : base(message)
        {
        }

        public TaskCancellationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskCancellationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}