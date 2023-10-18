using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Exceptions
{
    public class BadFormatException : BaseException
    {
        public BadFormatException(string formatName) : base("Bad format: " + formatName)
        {

        }

        public BadFormatException() : base("Bad format: ")
        {

        }

        public override int SubCode => 2;

        public override string Description => "Bad format of response provided in query string";
    }
}