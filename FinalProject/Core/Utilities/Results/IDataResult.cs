using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //Interfaceler bu şekilde implemente edilir. Bunun sonucunda IDataResult Hem success hem message hemde istenilen
        //datayı dödürünyor.
        T Data { get; }
    }
}
