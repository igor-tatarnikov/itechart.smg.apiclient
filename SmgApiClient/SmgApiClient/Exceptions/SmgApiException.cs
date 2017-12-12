using System;

namespace SmgApiClient.Exceptions
{
    public class SmgApiException : Exception
    {
        public SmgApiException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
