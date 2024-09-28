using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imgaeDal;

        public ImageManager(IImageDal imgaeDal)
        {
            _imgaeDal = imgaeDal;
        }

        public void Delete(Image t)
        {
            _imgaeDal.Delete(t);
        }

        public Image GetById(int id)
        {
            return _imgaeDal.GetById(id);
        }

        public List<Image> GetListAll()
        {
            return _imgaeDal.GetListAll();
        }

        public void Insert(Image t)
        {
            _imgaeDal.Insert(t);
        }

        public void Update(Image t)
        {
            _imgaeDal.Update(t);
        }
    }
}
