using System.Runtime.Serialization;

namespace HotBag.ResultWrapper.WrapperModel
{
    [DataContract]
    public class APIResponse
    {
        [DataMember]
        public string version { get; set; }

        [DataMember]
        public bool isSuccess { get; set; }

        [DataMember]
        public int statusCode { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError responseException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object result { get; set; }

        public APIResponse(int statusCode, string message = "", object result = null, bool IsSuccess = true, ApiError apiError = null, string apiVersion = "1.0.0.0")
        {
            this.statusCode = statusCode;
            this.isSuccess = IsSuccess;
            this.message = message;
            this.result = result;
            this.responseException = apiError;
            this.version = apiVersion;
        }
    }
}
