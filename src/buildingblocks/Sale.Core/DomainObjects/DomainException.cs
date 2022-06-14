using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Core.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception exception) : base(message, exception) { }
    }
}
