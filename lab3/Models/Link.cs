using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public record Link(string Href, string Method, string Rel)
    {
        public Link() : this("", "", "") { }
    }
}