using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //tələbələr
    public class Student
    {
        public int Id { get; set; }

        //ad

        //soyad

        //ataadı
        public string Fullname { get; set; }

        //istifadəçi adı
        public string Username { get; set; }

        //parol
        public string Password { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public List<Evaluationtable> Evaluationtables { get; set; }

        public List<Colloquium> Colloquiums { get; set; }

        public List<Laboratory> Laboratories { get; set; }

        public List<Exam> Exams { get; set; }

        public List<Freework> Freeworks { get; set; }





    }
}