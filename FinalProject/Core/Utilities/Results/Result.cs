using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message):this(success)//Bu ctor kullanılırken aşağıdaki ctor dan success i al
                                                                //constructor'un baseler ile çalışmasına örnek
            //Ctor(Yapısal blok) ile iki parametre verebiliyorum metoduma
        {
            Message = message;
            //Aşağıdaki mesajı mesaj olarak set et!!!
            //Get olayo readonly bir ifadedir. Ama readonşy ifadeleri constructor içerisinde set edilebilir.
            //Madem böyle niye başta set koymadık da böyle bir ctor kullanma gereği duyduk
            //Kullanııc kafasına göre return döndüremesin. Yani biz kullanıcıya sınırlama getirdik.
            //Benim belirlediğim ifadeyi set edebilirsin.
            //Success = success;
            //Bu ifade hem burade hemde aşağıdaki Ctor ieçrisinde çalışıyor. Kenidimi tekrar ediyorum. Kurala aykırı, 
            //Bu parametreyi aşağıdan ödünç alsın çalışacağı zaman
        }
        public Result(bool success)//Ctor(Yapısal blok) sadece bool da döndürmek isteyebilirdim.Overloading yapıyorum
        {

            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
