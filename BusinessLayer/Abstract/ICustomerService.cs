using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
   public interface ICustomerService
    {
        List<Customer> GetList();
        void CategoryAdd(Customer customer);

        Customer GetByID(int id);

        void CustomerDelete(Customer customer);

        void CustomerUpdate(Customer customer);
    }
}
