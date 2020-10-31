using System;
using System.Collections.Generic;

namespace Mediator
{
    //The purpose of this pattern is to let different systems meet each other.
    //Communication of the tower with five aircraft can be given as an example.
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator=new Mediator();
            
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "engin";
            mediator.Teacher = teacher;
            Student student=new Student(mediator);
            student.Name = "derin";
            

            Student student2=new Student(mediator);
            student2.Name = "bali";

            mediator.Students = new List<Student> {student, student2};
            teacher.SendNewImageUrl("slide.jpg");
            teacher.RecieveQuestion("is it true",student2);
            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator; //Access modifier changed from private to protected.
        //To reach derived classes.In addition, instead of starting with _, the name is
        //It just started with a capital letter In accordance with naming rules.

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher:CourseMember
    {
       

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}",student.Name,question);
        }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}",url);
            Mediator.UpdateImage(url);//Image is thus sent to all students.
        }

        public void AnswerQuestions(string answer,Student student)
        {
            Console.WriteLine("Teacher answered questions: {0},{1}",student.Name,answer);
        }

        public string Name { get; set; }
    }

    class Student:CourseMember
    {
        public void RecieveImage(string url)
        {
            Console.WriteLine("Student recieved image: {0}",url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer :{0}",answer);
        }

        public string Name { get; set; }

        public Student(Mediator mediator) : base(mediator)
        {
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
