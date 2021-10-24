using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
   public interface IProducService
    {
        List<Product> GetListProduct();
        void ProductAdd(Product product);

        Product GetByIDProduct(int id);

        void ProductDelete(Product product);

        void ProductUpdate(Product product);
    }
}
