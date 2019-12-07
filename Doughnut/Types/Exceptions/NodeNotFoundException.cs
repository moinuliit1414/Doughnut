using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Types.Exceptions
{
    public class NodeNotFoundException:DoughnutException
    {
        public string Code { get; }

        public NodeNotFoundException() : this("DOEX404", "Node Does Not Exist!!")
        {
        }

        public NodeNotFoundException(string message) : this("DOEX404", message)
        {
        }

        public NodeNotFoundException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public NodeNotFoundException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public NodeNotFoundException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public NodeNotFoundException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
