using Doughnut.Types.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Types.Responses
{
    public class ErrorResponse: BaseResponse
    {
        public string code { get; }
        public string errorMessage { get; }

        public ErrorResponse() {
            this.code = "DOEX5000";
            this.isSuccess = false;
        }

        public ErrorResponse(string message):this()
        {
            this.errorMessage = message;
        }
        public ErrorResponse(DoughnutException exception) : this()
        {
            this.errorMessage = exception.Message;
            this.code = exception.Code;
        }
    }
}
