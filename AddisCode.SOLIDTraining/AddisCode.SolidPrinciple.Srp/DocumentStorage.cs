using System.IO;

namespace AddisCode.SolidPrinciple.Srp
{
    public class DocumentStorage
    {
        internal string GetData(string sourceFileName)
        {
            string output;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }

        public void PersistDocument(object serializedDoc, string targetFileName)
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