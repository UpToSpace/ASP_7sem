using lab3.Models;
using lab3.Student;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Reflection;
using System.Web;

namespace lab3.StudentsRepository
{
    public class StudentsRepository : IRepository
    {
        private Models.Context context;

        public StudentsRepository(Models.Context context)
        {
            this.context = context;
        }

        public Models.Student GetStudent(int id)
        {
            return context.Students.Find(id);
        }
        public void Create(Models.Student item)
        {
            context.Students.Add(item);
        }

        public void Update(int id, string newName, string newNumber)
        {
            Models.Student student = context.Students.FirstOrDefault(x => x.Id == id);
            student.Name = newName;
            student.Phone = newNumber;
        }
        public void Delete(Models.Student item)
        {
            context.Students.Remove(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<object> CreateAnonymousObjects(List<object> studentsList, List<string> propertyNames)
        {
            var list = new List<object>();

            foreach (var student in studentsList)
            {
                var studentDict = new Dictionary<string, object>();

                foreach (var prop in propertyNames)
                {
                    var propertyInfo = student
                        .GetType()
                        .GetProperty
                            (prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo == null) continue;

                    var value = propertyInfo.GetValue(student);

                    studentDict.Add(prop, value);
                }

                list.Add(studentDict);
            }

            return list;
        }

        public IEnumerable<object> GetStudentList(GetStudentsRequest getStudentsRequest)
        {
            var students = context.Students.Where(s =>
            s.Id >= getStudentsRequest.MinId &&
            s.Id <= getStudentsRequest.MaxId);

            if (!getStudentsRequest.Like.IsNullOrWhiteSpace())
            {
                students = students.Where(s => s.Name.ToLower().Contains(getStudentsRequest.Like.ToLower()));
            }

            if (!getStudentsRequest.GlobalLike.IsNullOrWhiteSpace())
            {
                students = students.Where(s =>
                    (s.Phone
                     + SqlFunctions.StringConvert((decimal)s.Id)
                     + s.Name)
                    .Contains(getStudentsRequest.GlobalLike));
            }

            if (!getStudentsRequest.Sort.IsNullOrWhiteSpace())
            {
                if (getStudentsRequest.Sort.ToLower() == "name")
                {
                    students = students.OrderBy(s => s.Name);
                }
                else
                {
                    students = students.OrderBy(s => s.Id);
                }  
            }
            else
            {
                students = students.OrderBy(s => s.Id);
            }

            students = students.Skip(getStudentsRequest.Offset);

            if (getStudentsRequest.Limit != 0)
            {
                students = students.Take(getStudentsRequest.Limit);
            }

            return students.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}