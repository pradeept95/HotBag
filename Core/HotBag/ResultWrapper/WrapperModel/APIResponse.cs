using System.Runtime.Serialization;

namespace HotBag.ResultWrapper.WrapperModel
{
    [DataContract]
    public class APIResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError ResponseException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        public APIResponse(int statusCode, string message = "", object result = null, bool IsSuccess = true, ApiError apiError = null, string apiVersion = "1.0.0.0")
        {
            this.StatusCode = statusCode;
            this.IsSuccess = IsSuccess;
            this.Message = message;
            this.Result = result;
            this.ResponseException = apiError;
            this.Version = apiVersion;
        }
    }
}
