using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddisCode.SolidPrinciple.Lsp.Principles.Entities
{
    public class MetYourMakerException : Exception
    {
        protected string _message;

        public override string Message
        {
            get { return _message; }
        }

        public MetYourMakerException (string message)
        {
            _message = message;

        }
    }
}
