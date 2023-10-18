using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class Student
    {
        public Student(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public Student() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}