using AquitoWebApp.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasantesBackendApi.Models.Response
{
    public class BaseResponse<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        public BaseResponse() { }

        public BaseResponse(string message, T data, bool ok = false)
        {
            this.Ok = ok;
            this.Message = message;
            this.Data = data;
        }
    }
}
