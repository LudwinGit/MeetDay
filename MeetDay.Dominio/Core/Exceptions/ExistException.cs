using System.Runtime.Serialization;

namespace MeetDay.Dominio.Core.Exceptions
{
    [Serializable]
    public class ExistException : Exception
    {
        public ExistException(string message) : base(message)
        {
        }
        public ExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}