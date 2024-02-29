﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Common.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException() :base() 
        {
            
        }

        public ApplicationException(string message) :base(message)
        {
            
        }

        public ApplicationException(string message, Exception innerException) :base(message, innerException) 
        {
            
        }
        public ApplicationException( string message, params object[] args) :base(String.Format(CultureInfo.CurrentCulture, message, args)) 
        {
            
        }
    }
}
