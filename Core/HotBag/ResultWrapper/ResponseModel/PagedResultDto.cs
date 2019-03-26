using System.Collections.Generic;

namespace HotBag.ResultWrapper.ResponseModel
{
    public class PagedResultDto<T> 
    {
        public int TotalCount { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public string Summary { get; set; }
        public bool HasMore { get; set; }

        public PagedResultDto(int totalCount, List<T> data, bool HasMore = true, string summary = "")
        {
            this.TotalCount = totalCount;
            this.Data = data;
            this.HasMore = HasMore;
            this.Summary = !string.IsNullOrEmpty(summary)? summary
                         : $"Showing {data.Count} of {totalCount}";
        }
    }
}
