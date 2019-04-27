using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace HotBag.ResultWrapper.WrapperModel
{
    public class ApiError
    {
        public bool isError { get; set; }
        public bool isValidationError { get; set; }
        public string exceptionMessage { get; set; }
        public string details { get; set; }
        public string referenceErrorCode { get; set; }
        public string referenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> validationErrors { get; set; }

        public ApiError(string message)
        {
            this.exceptionMessage = message;
            this.isError = true;
            this.isValidationError = false;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this.isError = true;
            this.isValidationError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                this.exceptionMessage = "Please correct the specified validation errors and try again.";
                this.validationErrors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();

            }
            else
            {
                this.exceptionMessage = "Please correct the specified validation errors and try again.";
            }
        } 
    }
}
