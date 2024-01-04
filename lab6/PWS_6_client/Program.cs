using System;
using System.Linq;
using WSKVSModel;

namespace PWS_6_client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int choice = 1;
                while (choice != 0)
                {
                    Console.WriteLine("1.Add Student\n" +
                                      "2.Update Student Name\n" +
                                      "3.Delete Student\n" +
                                      "4.Print Students\n" +
                                      "5.Add Note\n" +
                                      "6.Update Note\n" +
                                      "7.Delete Note\n" +
                                      "8.Print Notes\n" +
                                      "0.Exit");

                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: AddStudent(); break;
                        case 2: UpdateStudent(); break;
                        case 3: DeleteStudent(); break;
                        case 4: PrintStudents(); break;
                        case 5: AddNote(); break;
                        case 6: UpdateNote(); break;
                        case 7: DeleteNote(); break;
                        case 8: PrintNotes(); break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        static void PrintStudents()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            foreach (var student in service.Student.AsEnumerable())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Id: {student.id}\nName: {student.name}");
                Console.WriteLine();
                foreach (var note in service.Note.Where(i => i.student_id == student.id).AsEnumerable())
                {
                    Console.WriteLine($"  Subj: {note.subject}, Note: {note.note1}");
                }
                Console.WriteLine("----------------------");
            }
            Console.WriteLine("\n\n\n");
        }

        static void AddStudent()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            Student student = new Student();
            Console.Write("Enter Name: ");
            student.name = Console.ReadLine();
            service.AddToStudent(student);
            service.SaveChanges();
        }

        static void UpdateStudent()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());
            var student = service.Student.AsEnumerable().FirstOrDefault(i => i.id == id);

            if (student != null)
            {
                Console.Write("New Name: ");
                student.name = Console.ReadLine();
                service.UpdateObject(student);
                service.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DeleteStudent()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));
            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());
            var student = service.Student.AsEnumerable().FirstOrDefault(i => i.id == id);

            if (student != null)
            {
                service.DeleteObject(student);
                service.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void PrintNotes()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            foreach (var note in service.Note.AsEnumerable())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Id: {note.id}\nSubject: {note.subject}\nNote: {note.note1}");
                Console.WriteLine("----------------------");
            }
            Console.WriteLine("\n\n\n");
        }

        static void AddNote()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            Note note = new Note();
            Console.Write("Enter Student Id: ");
            note.student_id = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject: ");
            note.subject = Console.ReadLine();
            Console.Write("Enter Note: ");
            note.note1 = int.Parse(Console.ReadLine());

            service.AddToNote(note);
            service.SaveChanges();
        }

        static void UpdateNote()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));
            Console.Write("Enter Note Id: ");
            int id = int.Parse(Console.ReadLine());
            var note = service.Note.AsEnumerable().FirstOrDefault(i => i.id == id);

            if (note != null)
            {
                Console.Write("Enter New Subject: ");
                note.subject = Console.ReadLine();
                Console.Write("Enter New Note: ");
                note.note1 = int.Parse(Console.ReadLine());

                service.UpdateObject(note);
                service.SaveChanges();
            }
            else
            {
                Console.WriteLine("Note not found.");
            }
        }

        static void DeleteNote()
        {
            WSKVSEntities service = new WSKVSEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));
            Console.Write("Enter Note Id: ");
            int id = int.Parse(Console.ReadLine());
            var note = service.Note.AsEnumerable().FirstOrDefault(i => i.id == id);

            if (note != null)
            {
                service.DeleteObject(note);
                service.SaveChanges();
                Console.WriteLine("Note deleted successfully.");
            }
            else
            {
                Console.WriteLine("Note not found.");
            }
        }
    }
}

