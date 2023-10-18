using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace lab3.Exceptions
{
    public abstract class BaseException : Exception
    {
        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public abstract int SubCode { get; }

        public abstract string Description { get; }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException()
        {
        }
    }
}