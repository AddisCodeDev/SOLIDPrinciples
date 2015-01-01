using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddisCode.SolidPrinciple.Lsp.Principles.Entities
{
    public class OutOfFuelException : Exception
    {
        protected string _message;

        public override string Message
        {
            get { return _message; }
        }

        public OutOfFuelException (string message)
        {
            _message = message;

        }
    }
}
