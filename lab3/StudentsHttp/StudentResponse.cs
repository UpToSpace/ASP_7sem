using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.StudentsHttp
{
    public record StudentResponse(Models.Student student, List<Models.Link> Links);
}