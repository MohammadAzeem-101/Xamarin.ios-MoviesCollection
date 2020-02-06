using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MoviesCollection
{
    public class ResponseModel
    {
        public string Status { get; set; }

        public Codes Code { get; set; }

        public object Body { get; set; }

        public string Message { get; set; }

        public string AccessToken { get; set; }
    }

    public enum Codes
    {
        SuccessCode = 200,
        FailureCode = 400
    }
}
