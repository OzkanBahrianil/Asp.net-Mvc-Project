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
  public  class OrderManeger: IOrderService
    {
        IOrderDal _OrderDal;

        public OrderManeger(IOrderDal orderDal)
        {
            _OrderDal = orderDal;
        }

        public void OrderAdd(Order product)
        {
            _OrderDal.Insert(product);

        }

        public void OrderDelete(Order product)
        {
            _OrderDal.Delete(product);
        }

        public void OrderUpdate(Order product)
        {
            _OrderDal.Update(product);
        }

        public Order GetByIDOrder(int id)
        {
            return _OrderDal.Get(x => x.OrderId == id);
        }

        public List<Order> GetListOrder()
        {
            return _OrderDal.List();
        }
    }
}
