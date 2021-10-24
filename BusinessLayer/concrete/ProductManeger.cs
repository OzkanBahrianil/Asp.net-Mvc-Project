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
   public class ProductManeger: IProducService
    {
        IProductDal _ProductDal;

        public ProductManeger(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public void ProductAdd(Product product)
        {
            _ProductDal.Insert(product);

        }

        public void ProductDelete(Product product)
        {
            _ProductDal.Delete(product);
        }

        public void ProductUpdate(Product product)
        {
            _ProductDal.Update(product);
        }

        public Product GetByIDProduct(int id)
        {
            return _ProductDal.Get(x => x.Id == id);
        }

        public List<Product> GetListProduct()
        {
            return _ProductDal.List();
        }
    }
}
