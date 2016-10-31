using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace SRC.Library.RestClient
{
    public class RestRequestInfo<TRequest, TResult>
    {
        public TRequest RequestData { get; set; }
        public string Url { get; set; }
        public TResult Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? RequestDate { get; set; }

        [JsonIgnore]
        public IRestResponse Response { get; set; }

        [JsonIgnore]
        public string ResultStr { get; set; }

        [JsonIgnore]
        public string SerializedInfo
        {
            get { return JsonConvert.SerializeObject(this); }
        }
    }
}
