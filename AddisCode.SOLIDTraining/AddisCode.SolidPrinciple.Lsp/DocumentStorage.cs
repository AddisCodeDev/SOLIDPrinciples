using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace AddisCode.SolidPrinciple.Lsp
{
    public abstract class DocumentStorage
    {
        public abstract string GetData(string sourceFileName);

        public abstract void PersistDocument(object serializedDoc, string targetFileName);
    }

    public class FileDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            string output;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }

        public override void PersistDocument(object serializedDoc, string targetFileName)
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }
    }

    public class HttpInputRetriever : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            if (!sourceFileName.StartsWith("http:"))
                throw new TargetException();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(sourceFileName);
            request.Method = "GET";
            String input = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                input = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            return input;
        }

        public override void PersistDocument(object serializedDoc, string targetFileName)
        {
            throw new System.NotImplementedException();
        }
    }
}