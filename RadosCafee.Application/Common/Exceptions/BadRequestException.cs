﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public string[] Errors { get; set; }

        public BadRequestException() : base() 
        {
            
        }

        public BadRequestException(string message) :base(message)
        {
            
        }

        public BadRequestException(string message, Exception innerException):base(message, innerException) 
        {
            
        }
        public BadRequestException(string[] errors) : base("following erros have been occured")
        {
            Errors = errors;
        }
    }
}
