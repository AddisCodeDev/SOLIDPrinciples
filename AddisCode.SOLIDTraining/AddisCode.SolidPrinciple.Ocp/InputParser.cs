using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataModel;

namespace AddisCode.SolidPrinciple.Ocp
{
    public class InputParser
    {
        public virtual Student[] ParseInput(string input)
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

    public class XmlInputParser : InputParser
    {
        public override Student[] ParseInput(string input)
        {
            try
            {
                var xDoc = XDocument.Parse(input);
                IEnumerable<XElement> rootElements;
                rootElements = xDoc.Root.Elements();
                Student[] students = new Student[rootElements.Count()];
                for (int index = 0; index < students.Length; index++)
                {
                    var xStudent = rootElements.ElementAt(index).Elements().ToArray();
                    Student student = new Student()
                    {
                        StudentId = Guid.Parse(xStudent[3].Value),
                        FirstName = xStudent[1].Value,
                        LastName = xStudent[2].Value,
                        Age = int.Parse(xStudent[0].Value)
                    };
                    students[index] = student;
                }
                return students;
            }
            catch (Exception)
            {
                throw new InvalidInputFormatException() ;
            }
        }
    }
}