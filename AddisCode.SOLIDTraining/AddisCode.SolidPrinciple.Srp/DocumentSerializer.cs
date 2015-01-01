using Newtonsoft.Json;

namespace AddisCode.SolidPrinciple.Srp
{
    public class DocumentSerializer
    {
        public object Serilize(object doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
}