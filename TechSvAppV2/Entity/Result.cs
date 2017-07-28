using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entity
{
    [DataContract]
    public partial class Result
    {

        public bool IsError { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public string HelpLink { get; set; }
        public string Source { get; set; }
        public object Model { get; set; }

        public Result()
        {

        }

        public Result(bool isError = false, int code = 0, string source = "", string message = "", string helpLink = "", object model = null)
        {
            IsError = isError;
            Code = code;
            Source = source;
            Message = message;
            HelpLink = helpLink;
            Model = model;
        }
        public static Result set(bool isError = false, int code = 0, string source = "", string message = "", string helpLink = "",object model=null)
        {
            return new Result(isError, code, source, message, helpLink, model);
        }

    }
}
