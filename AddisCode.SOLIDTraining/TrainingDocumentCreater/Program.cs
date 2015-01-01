using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace TrainingDocumentCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Dcocuments\\Document1.csv ");
            List<Student> students = new List<Student>();
            Student student1 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Derartu",
                LastName = "Tulu",
                Age = 20
            }; 
            Student student2 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Teddy",
                LastName = "Afro",
                Age = 21
            }; 
            Student student3 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Mesfin",
                LastName = "Negash",
                Age = 22
            };
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            string output = "";
            for (int index = 0; index < 3; index++)
            {
                output += students.ElementAt(index).StudentId.ToString() + ",";
                output += students.ElementAt(index).FirstName + ",";
                output += students.ElementAt(index).LastName + ",";
                output += students.ElementAt(index).Age.ToString();
                if (index!=2)
                    output += '\n';
            }
            using (var stream = File.Open(sourceFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(output);
                sw.Close();
            }
        }
    }
}
