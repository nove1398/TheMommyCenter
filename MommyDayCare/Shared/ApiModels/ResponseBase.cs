using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    public class ResponseBase
    {
        public HttpStatusCode Status { get; set; }

        public string ResponseMessage { get; set; }

        public string[] Errors { get; set; }

        public string RequestedResource { get; set; }
    }
}
