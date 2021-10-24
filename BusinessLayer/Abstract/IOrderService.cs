using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
   public interface IOrderService
    {
        List<Order> GetListOrder();
        void OrderAdd(Order order);

        Order GetByIDOrder(int id);

        void OrderDelete(Order order);

        void OrderUpdate(Order order);
    }
}
