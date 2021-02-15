using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       
        
        public Result(bool success, string message):this(success) //this tek parametreli conscructoru çalıştırmak için
        {
            Message = message;
           
        }
        public Result(bool success)
        {
            Success = success;
        }
        //Readonly ler constructorda set edilebilirler
        public bool Success { get; }

        public string Message { get; }
    }
}
