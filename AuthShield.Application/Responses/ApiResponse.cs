using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Application.Responses
{
    public class ApiResponse: BaseResponse
    {
        public ApiResponse() { }
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
