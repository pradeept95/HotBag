using Newtonsoft.Json.Linq;

namespace HotBag.Plugins.GraphQL.Middleware
{
    public class GraphQlRequest
    {
        private JObject _veriables;

        public string OperationName { get; set; }
        public string Query { get; set; }

        public JObject Veriables
        {
            get => _veriables ?? new JObject(new { });
            set => _veriables = value;
        }
    }
}
