using ClassLibrary1.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.concrete.Repository;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.concrete
{
    public class AdressManeger : IAdressService
    {

        IAddressDal _AdressrDal;

        public AdressManeger(IAddressDal addressDal)
        {
            _AdressrDal = addressDal;
        }

        public void AddressAdd(Address address)
        {
            _AdressrDal.Insert(address);

        }

        public void AddressDelete(Address address)
        {
            _AdressrDal.Delete(address);
        }

        public void AddressUpdate(Address address)
        {
            _AdressrDal.Update(address);
        }

        public Address GetByIDAddress(int id)
        {
            return _AdressrDal.Get(x => x.AddressId == id);
        }

        public List<Address> GetListAddress()
        {
            return _AdressrDal.List();
        }

    }
}
