using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            Message = String.Empty;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool sucess)
        {
            Success = sucess;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

    }
}
