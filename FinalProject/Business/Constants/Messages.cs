using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages//sürekli new yapmmak için çünkü basit bir mesaj değişkeni static yapıyorum
    {
        public static string ProductAdded="Ürün Eklendi.";//Static bir sabit
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string ProductListed="Ürünler Listelendi";
        public static string ProductCountofCategoryError = "Kategory için en fazla on ürün olabilir";
        public static string ProductNameAlreadyExist="Mevcut ürün ismi ikinci kere eklenemez";
    }

}
