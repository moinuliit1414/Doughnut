using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Types.Exceptions
{
    public class DoughnutException :Exception
    {
        public string Code { get; }

        public DoughnutException() : this("DOEX500", "Something Went Wrong!!")
        {
        }

        public DoughnutException(string message):this("DOEX500", message)
        {
        }

        public DoughnutException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public DoughnutException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public DoughnutException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public DoughnutException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
