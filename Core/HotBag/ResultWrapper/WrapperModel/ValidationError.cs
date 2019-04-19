using Newtonsoft.Json;

namespace HotBag.ResultWrapper.WrapperModel
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string field { get; }

        public string message { get; }

        public ValidationError(string errorField, string errorMessage)
        {
            field = errorField != string.Empty ? errorField : null;
            message = errorMessage;
        }
    }
}
