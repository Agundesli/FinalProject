using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utilities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message)//Ctor(Yapısal blok) ile iki parametre verebiliyorum metoduma
        {
            Message = message;
            //Aşağıdaki mesajı mesaj olarak set et!!!
            //Get olayo readonly bir ifadedir. Ama readonşy ifadeleri constructor içerisinde set edilebilir.
            //Madem böyle niye başta set koymadık da böyle bir ctor kullanma gereği duyduk
            //Kullanııc kafasına göre return döndüremesin. Yani biz kullanıcıya sınırlama getirdik.
            //Benim belirlediğim ifadeyi set edebilirsin.
            Success = success;
        }
        public Result(bool success)//Ctor(Yapısal blok) sadece bool da döndürmek isteyebilirdim.Overloading yapıyorum
        {

            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
