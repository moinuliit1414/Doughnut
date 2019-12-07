using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doughnut.Types.Responses
{
    public class SuccessResponse<T>:BaseResponse
    {
        public T data { get; set; }
        //public SuccessResponse() {
            //this.isSuccess = true;
        //}

        public SuccessResponse(T data)    
        {
            this.data = data;
            this.isSuccess = true;
        }
    }
}
