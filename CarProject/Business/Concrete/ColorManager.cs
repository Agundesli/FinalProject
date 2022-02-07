using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Numaralı Ürün Eklendi");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(color.ColorId + " Numaralı Ürün Silindi");
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }


        public List<Color> GetCarByColorId(int id)
        {
            return _colorDal.GetAll(p => p.ColorId == id);
        }
        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(color.ColorId + " Numaralı Ürün Güncellendi");
        }
    }
}
