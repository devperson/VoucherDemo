﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoucherDemo.Models
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        //public string ExceptionType { get; set; }


        public bool HasErrorMessage
        {
            get
            {
                return !string.IsNullOrEmpty(this.Message) || !string.IsNullOrEmpty(this.ExceptionMessage);
            }
        }

        public string ErrorMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Message))
                    return this.Message;
                else
                    return this.ExceptionMessage;
            }
        }
    }
}
