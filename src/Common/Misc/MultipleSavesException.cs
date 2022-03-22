namespace Common.Misc
{
    using System;

    public class MultipleSavesException : Exception
    {
        public MultipleSavesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MultipleSavesException(string message)
            : base(message)
        {
        }

        public MultipleSavesException()
        {
        }
    }
}