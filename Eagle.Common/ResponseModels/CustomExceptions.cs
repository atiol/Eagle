using System;
using System.Collections.Generic;
using System.Text;

namespace Eagle.Common.ResponseModels
{
    public class CustomException : Exception
    {
        public string Key { get; set; }
        public int StatusCode { get; set; }

        public CustomException() { }

        public CustomException(string key, int statusCode)
        {
            Key = key;
            StatusCode = statusCode;
        }
    }

    public class CustomException<T> : CustomException
    {
        public T Errors { get; set; }
        public CustomException(CustomException exception, T errors)
            : base(exception.Key, exception.StatusCode)
        {
            Errors = errors;
        }
    }

    public static class CustomExceptions
    {
        public static CustomException Unknown = new CustomException
        {
            Key = "Unknown",
            StatusCode = 500
        };

        public static CustomException BadRequest = new CustomException
        {
            Key = "BadRequest",
            StatusCode = 400
        };

        public static CustomException RecordNotFound = new CustomException
        {
            Key = "RecordNotFound",
            StatusCode = 404
        };

        public static CustomException RecordExists = new CustomException
        {
            Key = "RecordExists",
            StatusCode = 409
        };

        public static class UserTypes
        {
            public static CustomException EmailExists = new CustomException
            {
                Key = "EmailExists",
                StatusCode = 409
            };

            public static CustomException InvalidPassword = new CustomException
            {
                Key = "InvalidPassword",
                StatusCode = 401
            };

            public static CustomException AccessDenied = new CustomException
            {
                Key = "AccessDenied",
                StatusCode = 401
            };
        }
    }
}
