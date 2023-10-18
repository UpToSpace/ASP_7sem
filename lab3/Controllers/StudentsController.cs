using lab3.Exceptions;
using lab3.Models;
using lab3.Serializer;
using lab3.Student;
using lab3.StudentsHttp;
using lab3.StudentsRepository;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml.Serialization;

namespace lab3.Controllers
{
    [ApiException]
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private StudentsRepository.StudentsRepository repository;
        StudentSerializer studentSerializer;
        private const string URI = "http://localhost:56665/";

        public StudentsController()
        {
            repository = new StudentsRepository.StudentsRepository(new Models.Context());
            studentSerializer = new StudentSerializer();
        }


        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get([FromUri] GetStudentsRequest request)
        {
            request ??= new GetStudentsRequest();
            List<object> students = repository.GetStudentList(request).ToList();
            var columns = request.Columns.IsNullOrWhiteSpace() ? "id,name,phone".Split(',') : request.Columns.Split(',');
            List<string> selectedColumns = new List<string>(columns);
            students = repository.CreateAnonymousObjects(students, selectedColumns);

            var response = new StudentsResponse(students, new List<Link>
                {
                    new Link(URI, "GET", "self"),
                    new Link(URI + "{id}", "GET", "get"),
                    new Link(URI, "POST", "create student"),
                    new Link(URI + "{id}", "PUT", "update"),
                    new Link(URI + "{id}", "DELETE", "delete"),
                });

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            };

            var content = request.Format switch
            {
                "json" => studentSerializer.JsonSerialize(response),
                "xml" => studentSerializer.XmlSerialize(response),
                _ => throw new BadFormatException(request.Format)
            };
            responseMessage.Content = content;

            return responseMessage;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var student = repository.GetStudent(id);
            if (student== null)
            {
                throw new StudentNotFoundException();
            }
            var response = new StudentResponse(student, new List<Link>
                {
                    new Link(URI, "GET", "self"),
                    new Link(URI, "POST", "create"),
                    new Link(URI + $"{student.Id}", "PUT", "update"),
                    new Link(URI + $"{student.Id}", "DELETE", "delete"),
                });

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = studentSerializer.JsonSerialize(response)
            };

            return responseMessage;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage Post([FromBody] CreateStudentRequest request)
        {
            Models.Student student = new Models.Student(request.Name, request.Phone);
            repository.Create(student);
            repository.Save();

            var response = new StudentResponse(student, new List<Link>
                {
                    new Link(URI, "GET", "self"),
                    new Link(URI + $"{student.Id}", "GET", "get"),
                    new Link(URI, "POST", "create student"),
                    new Link(URI + $"{student.Id}", "PUT", "update"),
                    new Link(URI + $"{student.Id}", "DELETE", "delete"),
                });

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = studentSerializer.JsonSerialize(response)
            };
            return responseMessage;
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] UpdateStudentRequest request)
        {
            Models.Student student = repository.GetStudent(id);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }
            repository.Update(id, request.Name, request.Phone);
            repository.Save();
            student = repository.GetStudent(id);
            var response = new StudentResponse(student, new List<Link>
                {
                    new Link(URI, "GET", "self"),
                    new Link(URI + $"{student.Id}", "GET", "get"),
                    new Link(URI, "POST", "create"),
                    new Link(URI + $"{student.Id}", "PUT", "update"),
                    new Link(URI + $"{student.Id}", "DELETE", "delete"),
                });

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = studentSerializer.JsonSerialize(response)
            };
            return responseMessage;
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Models.Student student = repository.GetStudent(id);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }
            repository.Delete(student);
            repository.Save();

            var response = new StudentResponse(student, new List<Link>
                {
                    new Link(URI, "GET", "self"),
                    new Link(URI, "POST", "create")
                });

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = studentSerializer.JsonSerialize(response)
            };
            return responseMessage;
        }
    }
}