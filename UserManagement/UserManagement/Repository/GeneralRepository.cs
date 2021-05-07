using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Repository.Interface;
using UserManagement.View_Model;

namespace UserManagement.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        public MyContext conn;
        private readonly DbSet<Entity> entities;
        
        public GeneralRepository(MyContext conn)
        {
            this.conn = conn;
            entities = conn.Set<Entity>();
        }

        public IEnumerable<Entity> Get()
        {
            
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key); 
        }

        public int Insert(Entity entity)
        {
            entities.Add(entity);
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            conn.Entry(entity).State = EntityState.Modified;
            var result = conn.SaveChanges();
            return result;
        }
        public int Delete(Key key)
        {
            var entity = entities.Find(key);
            entities.Remove(entity);
            var result = conn.SaveChanges();
            return result;

        }
    }
}
