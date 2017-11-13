using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Addresses.Repository
{
    public interface IGenericRepository<TDAL,TBOL>
        where TDAL: class,new()
        where TBOL : class, new()
    {
        IQueryable<TBOL> GetAll(Expression<Func<TBOL,bool>> predicate=null);
        TBOL GetOne(Expression<Func<TBOL, bool>> predicate = null);
    }
}
