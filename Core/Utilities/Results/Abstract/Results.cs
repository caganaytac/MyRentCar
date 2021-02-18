using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public class Results : IResult
    {
        public Results(bool success, string message) : this(success)
        {
            
            Message = message;
        }
        public Results(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
