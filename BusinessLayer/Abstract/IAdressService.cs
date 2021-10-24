using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
  public interface IAdressService
    {
        List<Address> GetListAddress();
        void AddressAdd(Address address);

        Address GetByIDAddress(int id);

        void AddressDelete(Address address);

        void AddressUpdate(Address address);
    }
}
