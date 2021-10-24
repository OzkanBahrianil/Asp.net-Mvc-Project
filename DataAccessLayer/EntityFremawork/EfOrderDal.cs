using DataAccessLayer.Abstract;
using DataAccessLayer.concrete.Repository;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFremawork
{
   public class EfOrderDal: GenericRepository<Order>, IOrderDal
    {

    }
}
