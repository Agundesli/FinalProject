using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message):base(true,message)
        {
            Data = data;
        }
        public DataResult(T data,bool succes):base(true)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
