using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class Message
    {
        public static string ImageNotFound = "Resim Bulunamadı";
        public static string DeletedImage = "Resim Silindi";
        public static string CarImageLimitPassed = "Fazla Resim Yüklendi";
        public static string InvalidProductName = "Ürün ismi Geçersiz";
        public static string NoPriceEntried = "Fiyat girilmedi";
        public static string AddedSuccesful = "Eklendi";
        public static string Maintenancetime = "Bakım Zamanı";
        public static string DeletedProduct = "Ürün Silindi";
        public static string UpdatedProduct = "Ürün Güncellendi";
        public static string NotReturn = "Teslim Alınmadı";
        public static string FailAdded = "Ekleme Başarısız";
        public static string AuthorizationDenied="Gerekli Yetkiniz Yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Parola Hatalı";
        public static string SuccessfulLogin="Kayıt Başarılı";
        public static string UserAlreadyExists="Var Olan Kullanıcı";
        public static string AccessTokenCreated="Geçerli Token Yaratıldı";
    }
}
