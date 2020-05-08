using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    public class ResponseBase
    {
        public int Status { get; set; }

        public string ResponseMessage { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public string RequestedResource { get; set; }
    }
}
