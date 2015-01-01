using System;
using System.Collections.Generic;
using DataModel;

namespace AddisCode.SolidPrinciple.Srp
{
    public class InputParser
    {
        public Student[] ParseInput(string input)
        {
            string[] studentsRead = input.Split('\n');
            List<Student> students = new List<Student>();
            try
            {
                foreach (var studentRead in studentsRead)
                {
                    string[] studentData = studentRead.Split(',');
                    Student student = new Student()
                    {
                        StudentId = Guid.Parse(studentData[0]),
                        FirstName = studentData[1],
                        LastName = studentData[2],
                        Age = int.Parse(studentData[3])
                    };
                    students.Add(student);
                }
            }
            catch (Exception e)
            {
                throw new InvalidInputFormatException();
            }
            return students.ToArray();
        
        }
    }
}