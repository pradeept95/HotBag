using System.Collections.Generic;

namespace HotBag.ResultWrapper.WrapperModel
{
    public class ApiException : System.Exception
    {
        public int statusCode { get; set; }

        public IEnumerable<ValidationError> errors { get; set; }

        public string referenceErrorCode { get; set; }
        public string referenceDocumentLink { get; set; }

        public ApiException(string message,
                            int statusCode = 500,
                            IEnumerable<ValidationError> errors = null,
                            string errorCode = "",
                            string refLink = "") :
            base(message)
        {
            this.statusCode = statusCode;
            this.errors = errors;
            this.referenceErrorCode = errorCode;
            this.referenceDocumentLink = refLink;
        }

        public ApiException(System.Exception ex, int httpStatusCode = 500) : base(ex.Message)
        {
            statusCode = httpStatusCode;
        }
    }
}
