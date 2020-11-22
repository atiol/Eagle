using System;
using System.Collections.Generic;
using System.Text;

namespace Eagle.Common.ResponseModels
{
    public class ResponseModel
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public ResponseModel(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Result { get; set; }

        public ResponseModel(bool succeeded, string message, T result) 
            : base(succeeded, message)
        {
            Result = result;
        }
    }
}
