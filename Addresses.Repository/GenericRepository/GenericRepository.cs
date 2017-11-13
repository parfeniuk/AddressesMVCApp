using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addresses.Repository
{
    public abstract class GenericRepository<TDAL, TBOL, TContext> : IGenericRepository<TDAL, TBOL>
        where TDAL : class, new()
        where TBOL : class, new()
        where TContext : DbContext
    {
        TContext dbContext;
        IDbSet<TDAL> dbSetSource;
        IList<TBOL> listResult;

        public GenericRepository(DbContext context)
        {
            this.dbContext = context as TContext;
            dbSetSource = dbContext.Set<TDAL>();
            listResult = new List<TBOL>();
            Map();
            CreateBolList();
        }

        protected virtual void Map()
        {
            // Create Map of TBOL type from TDAL type
            Mapper.Initialize(cfg => cfg.CreateMap<TDAL, TBOL>());
        }

        private void CreateBolList()
        {
            // Create List of TBOL type instances
            dbSetSource.ToList().ForEach(src => listResult.Add(Mapper.Map<TBOL>(src)));
        }

        public virtual IQueryable<TBOL> GetAll(Expression<Func<TBOL, bool>> predicate = null)
        {
            return predicate != null? listResult.AsQueryable().Where(predicate)
                :listResult.AsQueryable();
        }

        public virtual TBOL GetOne(Expression<Func<TBOL, bool>> predicate = null)
        {
            return predicate!=null? listResult.AsQueryable().Where(predicate).FirstOrDefault()
                : listResult.AsQueryable().FirstOrDefault();
        }
    }
}
