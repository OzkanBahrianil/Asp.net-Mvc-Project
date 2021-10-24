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
    public class CustomerManeger : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManeger(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void CategoryAdd(Customer customer)
        {
            _customerDal.Insert(customer);
            
        }

        public void CustomerDelete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public void CustomerUpdate(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public Customer GetByID(int id)
        {
            return _customerDal.Get(x => x.CustomerId == id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.List();
        }
    }
}
