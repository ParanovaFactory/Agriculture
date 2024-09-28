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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contanctDal;

        public ContactManager(IContactDal contanctDal)
        {
            _contanctDal = contanctDal;
        }

        public void Delete(Contact t)
        {
            _contanctDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            return _contanctDal.GetById(id);
        }

        public List<Contact> GetListAll()
        {
            return _contanctDal.GetListAll();
        }

        public void Insert(Contact t)
        {
            _contanctDal.Insert(t);
        }

        public void Update(Contact t)
        {
            _contanctDal.Update(t);
        }
    }
}
