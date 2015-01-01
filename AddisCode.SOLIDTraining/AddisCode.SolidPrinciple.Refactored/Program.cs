using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataModel;

namespace AddisCode.SolidPrinciple.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Dcocuments\\Document1.csv ");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Ouput Dcocuments\\Document1.json ");
            var input = GetInput(sourceFileName);
            var students = GetStudents(input);
            var serializedDoc = SerializeStudents(students);
            PersistStudents(serializedDoc, targetFileName);
        }

        private static string GetInput (string sourceFileName)
        {
            string output;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }
        private static Student[] GetStudents(string input) 
        {
            string[] studentsRead = input.Split('\n');
            List<Student> students = new List<Student>();
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
            return students.ToArray();
        }
        private static string SerializeStudents(Student[] students) 
        {
            return JsonConvert.SerializeObject(students);
        }
        private static void PersistStudents(string serializedDoc, string targetFileName) 
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }
    }
}
