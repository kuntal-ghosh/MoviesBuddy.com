using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Vidly.persistance.Repository
{
    public class BaseRepository<Entity> where Entity:class
    {
        protected readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public Entity Add(Entity entity)
        {
           return _context.Set<Entity>().Add(entity);
        }

        public Entity Remove(Entity entity)
        {
            return _context.Set<Entity>().Remove(entity);
        }

        public Entity Get(int id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity,bool>> predicate)
        {
            return _context.Set<Entity>().Where(predicate).ToList();
        }
    }
}