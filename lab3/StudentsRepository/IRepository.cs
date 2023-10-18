using lab3.Models;
using lab3.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.StudentsRepository
{
    internal interface IRepository : IDisposable
    {
        IEnumerable<object> GetStudentList(GetStudentsRequest getStudentsRequest);

        Models.Student GetStudent(int id);
        void Create(Models.Student item);
        void Update(int id, string newName, string newNumber);
        void Delete(Models.Student item);
        void Save();
    }
}
