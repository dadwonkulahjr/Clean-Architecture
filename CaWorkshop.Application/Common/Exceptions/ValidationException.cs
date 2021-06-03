using System;
using System.Collections.Generic;

namespace CaWorkshop.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; set; }
        public ValidationException()
           :base("One or more validation error occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }

    }

   
}
