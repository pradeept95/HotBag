using System.Collections.Generic;

namespace HotBag.ResultWrapper.ResponseModel
{
    public class PagedResultDto<T> 
    {
        public int TotalCount { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public string Summary { get; set; }

        public PagedResultDto(int totalCount, List<T> data, string summary = "")
        {
            this.TotalCount = totalCount;
            this.Data = data;
            this.Summary = summary;
        }
    }
}
