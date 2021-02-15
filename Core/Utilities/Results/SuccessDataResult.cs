using System;
namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        public SuccessDataResult(string message):base(default,true,message) //data vermedi default yazarak tipi neyse varsayılan olarak onu geçti
        {

        }
        public SuccessDataResult():base(default,true)//data vermedi default yazarak tipi neyse varsayılan olarak onu geçti
        {

        }
    }
}
