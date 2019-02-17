using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UIModels
{
    public class ResponseModel
    {
        public ResponseModel(object data = null, bool isSuccess = true, string message = "", Exception exception = null)
        {
            this.Data = data;
            this.IsSuceess = isSuccess;
            this.Message = message;
            this.Exception = exception;
        }

        public Exception Exception { get; set; }
        public string Message { get; set; }
        public bool IsSuceess { get; set; }
        public Object Data { get; set; }
    }
}
