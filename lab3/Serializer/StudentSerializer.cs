using lab3.Student;
using lab3.StudentsHttp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace lab3.Serializer
{
    public class StudentSerializer
    {
        public StringContent JsonSerialize(StudentsResponse studentsResponse)
        {
            return new StringContent(
                    JsonConvert.SerializeObject(studentsResponse),
                    Encoding.UTF8,
                    "application/json"
                );
        }

        public StringContent JsonSerialize(StudentResponse studentsResponse)
        {
            return new StringContent(
                    JsonConvert.SerializeObject(studentsResponse),
                    Encoding.UTF8,
                    "application/json"
                );
        }

        public StringContent XmlSerialize(StudentsResponse studentsResponse)
        {
            var jsonTest = JsonConvert.SerializeObject(studentsResponse);

            var xmlTest = JsonConvert.DeserializeXmlNode(jsonTest, "root");
            return new StringContent(xmlTest.OuterXml,
                                     Encoding.UTF8,
                                     "application/xml"
            );
        }

    }
}