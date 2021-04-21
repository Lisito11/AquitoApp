using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasantesBackendApi.Models.Response
{
    public class BaseResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


        public BaseResponse() { }

        public BaseResponse(string message, object data, bool ok = false)
        {
            this.Ok = ok;
            this.Message = message;
            this.Data = data;
        }
    }
}
