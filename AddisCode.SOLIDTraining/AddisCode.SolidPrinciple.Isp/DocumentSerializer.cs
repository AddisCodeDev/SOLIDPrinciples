using DataModel;
using Newtonsoft.Json;

namespace AddisCode.SolidPrinciple.Isp
{
    public interface IDocumentSerializer
    {
        string Serilize(Student[] doc);
    }

    public class JsonDocumentSerializer : IDocumentSerializer
    {
        public string Serilize(Student[] doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }

    public class CamleCaseJsonSerializer : IDocumentSerializer
    {
        public string Serilize(Student[] doc)
        {
            return new CamleCaseJsonSerializer().Serilize(doc);
        }
    }
}