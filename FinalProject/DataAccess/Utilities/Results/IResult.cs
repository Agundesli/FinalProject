using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utilities.Results
{
    public interface IResult
    {
        //Interface görevleri;
        //Interface özellik tutan classların yönetimi konusunda kullanılır.Referans yönetimi.
        //Temel voidler için başlanfıç. Voidleri bu Interface ile süsleyeceğiz
         bool Success { get;}
         string Message { get; }
    }
}
