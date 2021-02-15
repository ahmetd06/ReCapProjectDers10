using System;
namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) //data vermedi default yazarak tipi neyse varsayılan olarak onu geçti
        {

        }
        public ErrorDataResult() : base(default, false)//data vermedi default yazarak tipi neyse varsayılan olarak onu geçti
        {

        }
    }
}
