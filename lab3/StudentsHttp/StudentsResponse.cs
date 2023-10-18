using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Student
{
    public record StudentsResponse(List<object> Students, List<Models.Link> Links)
    {
        StudentsResponse() : this(new List<object>(), new List<Models.Link>())
        {}
    }  
}