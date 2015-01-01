using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace AddisCode.SolidPrinciple.Dip
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Dcocuments\\Document1.csv ");
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Input Dcocuments\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Ouput Dcocuments\\Document1.json ");
            //var sorceFileName = "http:\\localhost\Values";
            //var targetFileName = "http:\\localhpst\values";
            var container = GetContainer();
            

            var formatConverter = container.Resolve<FormatConverter>();
            if (!formatConverter.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("Conversion Failed");
                Console.ReadKey();
            }
        }

        private static IUnityContainer GetContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDocumentSerializer, JsonDocumentSerializer>();
            container.RegisterType<InputParser, XmlInputParser>();
            return container;
        }

    }
}
