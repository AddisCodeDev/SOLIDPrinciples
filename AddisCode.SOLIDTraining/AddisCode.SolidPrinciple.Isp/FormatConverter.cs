using System;
using System.IO;

namespace AddisCode.SolidPrinciple.Isp
{
    class FormatConverter
    {
        private readonly InputParser _inputParser;
        private readonly IDocumentSerializer _documentSerializer;

        public FormatConverter()
        { 
            //_documentSerializer = new CamleCaseJsonSerializer();
            _documentSerializer = new JsonDocumentSerializer();
            //_inputParser = new InputParser();
            _inputParser = new XmlInputParser();       
        }
        internal bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;
            var inputRetriver = GetInputRetriever(sourceFileName);
            var inputPersister = GetInputPersister(targetFileName);
            try
            {
                input = inputRetriver.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            var doc = _inputParser.ParseInput(input);
            var serializedDoc = _documentSerializer.Serilize(doc);

            try
            {
                inputPersister.PersistDocument(serializedDoc, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }
            return true;
        }

        internal IInputRetriever GetInputRetriever(string sourceFileName)
        {
            if (sourceFileName.StartsWith("http"))
                return new HttpInputRetriever();
            return new FileDocumentStorage();
        }
        internal IInputPersister GetInputPersister(string targetFileName)
        {
            return new FileDocumentStorage();
        }

    }
}
